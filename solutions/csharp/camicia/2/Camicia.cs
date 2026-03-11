using System;
using System.Collections.Generic;
using System.Linq;

public static class Camicia
{
    
    public enum GameStatus { Finished, Loop }

    public record GameResult(GameStatus Status, int Tricks, int Cards);

    public static GameResult SimulateGame(string[] playerA, string[] playerB)
    {
        Queue<string> qA = new Queue<string>(playerA);
        Queue<string> qB = new Queue<string>(playerB);
        HashSet<string> history = new HashSet<string>();
        int totalTricks = 0;
        int totalCards = 0;
        int turn = 0;
        var penaltyMap = new Dictionary<string, int> { {"J",1},{"Q",2},{"K",3},{"A",4} };
    
        history.Add(GetState(qA, qB, turn));
    
        while (true)
        {
            List<string> pile = new List<string>();
            int winner = -1;
    
            while (winner == -1)
            {
                var activeQ = turn == 0 ? qA : qB;
                if (activeQ.Count == 0) { winner = 1 - turn; break; }
    
                string card = activeQ.Dequeue();
                pile.Add(card);
                totalCards++;
    
                if (penaltyMap.ContainsKey(card))
                {
                    turn = 1 - turn; // 換對手付罰款
                    int toPay = penaltyMap[card];
    
                    for (int i = 0; i < toPay; i++)
                    {
                        activeQ = turn == 0 ? qA : qB;
                        if (activeQ.Count == 0) { winner = 1 - turn; break; }
    
                        string payCard = activeQ.Dequeue();
                        pile.Add(payCard);
                        totalCards++;
    
                        if (penaltyMap.ContainsKey(payCard))
                        {
                            // 反擊：換邊，重設罰款
                            turn = 1 - turn;
                            toPay = penaltyMap[payCard];
                            i = -1;
                        }
                    }
                    // 付清後：winner 是最後打出 payment card 的那方
                    // turn 現在是付款方，所以出牌方是 1 - turn
                    if (winner == -1) winner = 1 - turn;
                }
                else
                {
                    turn = 1 - turn;
                }
            }
    
            totalTricks++;
            var winnerQ = winner == 0 ? qA : qB;
            foreach (var c in pile) winnerQ.Enqueue(c);
            turn = winner;
    
            // ✅ Bug 3 修正：不寫死 52
            if (qA.Count == 0 || qB.Count == 0)
                return new GameResult(GameStatus.Finished, totalTricks, totalCards);
    
            // ✅ Bug 2 修正：用 # 代替 number card
            string state = GetState(qA, qB, turn);
            if (history.Contains(state))
                return new GameResult(GameStatus.Loop, totalTricks, totalCards);
    
            history.Add(state);
        }
    }

    private static string GetState(Queue<string> qA, Queue<string> qB, int turn)
    {
        static string Normalize(Queue<string> q) =>
            string.Join(",", q.Select(c => "JQKA".Contains(c) ? c : "#"));
        
        return $"{Normalize(qA)}|{Normalize(qB)}|{turn}";
    }
}