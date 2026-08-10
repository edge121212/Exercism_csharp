public static class LogAnalysis 
{
    // TODO: define the 'SubstringAfter()' extension method on the `string` type
    public static string SubstringAfter(this string str, string delimiter)
    {
        int cutFrom = str.IndexOf(delimiter);
        int startIdx = cutFrom + delimiter.Length;
        return str.Substring(startIdx);
    }
    // TODO: define the 'SubstringBetween()' extension method on the `string` type
    public static string SubstringBetween(this string str, string delimiter1, string delimiter2)
    {
        int startIdx = str.IndexOf(delimiter1) + delimiter1.Length;
        int endIdx = str.IndexOf(delimiter2);
        return str.Substring(startIdx, endIdx - startIdx);
    }
    
    // TODO: define the 'Message()' extension method on the `string` type
    public static string Message(this string str) => str.SubstringAfter(": ");

    // TODO: define the 'LogLevel()' extension method on the `string` type
    public static string LogLevel(this string str) => str.SubstringBetween("[", "]"); 

}