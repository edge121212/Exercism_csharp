using System;
using System.Collections.Generic;
using System.Linq;

public static class Camicia
{
    public enum GameStatus { Finished, Loop }

    public record GameResult(GameStatus Status, int Tricks, int Cards);

    private static readonly Dictionary<string, int> PenaltyMap =
        new Dictionary<string, int> { {"J",1},{"Q",2},{"K",3},{"A",4} };

    public static GameResult SimulateGame(string[] playerA, string[] playerB)
    {
        Queue<string> qA = new Queue<string>(playerA);
        Queue<string> qB = new Queue<string>(playerB);
        HashSet<string> history = new HashSet<string>();
        int totalTricks = 0;
        int totalCards = 0;
        int turn = 0;
    
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
    
                if (PenaltyMap.ContainsKey(card))
                {
                    turn = 1 - turn; // Switch to opponent to pay the penalty
                    int toPay = PenaltyMap[card];
    
                    for (int i = 0; i < toPay; i++)
                    {
                        activeQ = turn == 0 ? qA : qB;
                        if (activeQ.Count == 0) { winner = 1 - turn; break; }
    
                        string payCard = activeQ.Dequeue();
                        pile.Add(payCard);
                        totalCards++;
    
                        if (PenaltyMap.ContainsKey(payCard))
                        {
                            // Counter-attack: switch sides and reset the penalty count
                            turn = 1 - turn;
                            toPay = PenaltyMap[payCard];
                            i = -1;
                        }
                    }
                    // After paying: the winner is the player who played the last penalty card
                    // turn is now the paying side, so the winner is the other side (1 - turn)
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
    
            // Bug fix: use dynamic card counts instead of hardcoded 52
            if (qA.Count == 0 || qB.Count == 0)
                return new GameResult(GameStatus.Finished, totalTricks, totalCards);
    
            // Bug fix: normalize number cards to '#' to properly detect loops
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
