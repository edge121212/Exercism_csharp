public static class ResistorColorDuo
{
    public static readonly string[] ColorMap =
    {
        "black", "brown", "red", "orange", "yellow", 
        "green", "blue", "violet", "grey", "white"
    };
    public static int Value(string[] colors)
    {
        int first = Array.IndexOf(ColorMap, colors[0]);
        int second = Array.IndexOf(ColorMap, colors[1]);
        return first*10+second;
    }
}
