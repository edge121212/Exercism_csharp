using System;
using System.Linq;
public static class Bob
{
    public static string Response(string statement)
    {
        if (string.IsNullOrWhiteSpace(statement)){
            return "Fine. Be that way!";
        }
        string trimmedStatement = statement.Trim();
        bool isQuestion = trimmedStatement.EndsWith("?");
        bool hasLetters = trimmedStatement.Any(char.IsLetter);
        bool isYelling = hasLetters && trimmedStatement.ToUpper() == trimmedStatement;
        if (isYelling && isQuestion){
            return "Calm down, I know what I'm doing!";
        }
        else if (isYelling){
            return "Whoa, chill out!";
        }
        else if (isQuestion) {
            return "Sure.";
        }
        else {
            return "Whatever.";
        }
    }
}