using System.Collections.Generic;

public static class BottleSong
{
    public static IEnumerable<string> Recite(int startBottles, int takeDown)
    {
        List<string> song = new List<string>();
        for (int i = 0; i < takeDown; i++) {
            string currentNum = NtoW(startBottles);
            string nextNum = NtoW(startBottles - 1).ToLower();
            string currentBottle = startBottles == 1 ? "bottle" : "bottles";
            string nextBottle = (startBottles - 1) == 1 ? "bottle" : "bottles";
            song.Add($"{currentNum} green {currentBottle} hanging on the wall,");
            song.Add($"{currentNum} green {currentBottle} hanging on the wall,");
            song.Add("And if one green bottle should accidentally fall,");
            song.Add($"There'll be {nextNum} green {nextBottle} hanging on the wall.");
            if (i < takeDown - 1) song.Add("");
            startBottles--;
        }
        return song;
    }
    public static string NtoW(int number)
    {
        switch (number)
        {
            case 10 : return "Ten";
            case 9 : return "Nine";
            case 8 : return "Eight";
            case 7 : return "Seven";
            case 6 : return "Six";
            case 5 : return "Five";
            case 4 : return "Four";
            case 3 : return "Three";
            case 2 : return "Two";
            case 1 : return "One";
            case 0 : return "No";
            default : return "";
        }
    }
}
