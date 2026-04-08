public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        int numOfString = subjects.Length;
        if (subjects.Length == 0){
            return Array.Empty<string>();
        }
        string[] result = new string[numOfString];
        for (int i = 0; i < numOfString - 1; i++){
            result[i] = $"For want of a {subjects[i]} the {subjects[i + 1]} was lost.";
        }    
        result[numOfString - 1] = $"And all for the want of a {subjects[0]}.";
        return result;
    }
}