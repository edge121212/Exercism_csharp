using System;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);

        return new string(charArray);
    }
}