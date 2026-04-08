using System;
using System.Collections.Generic;
using System.Linq;

public class Anagram
{
    private readonly string _lowerBaseWord;
    private readonly string _sortedBaseWord;
    
    public Anagram(string baseWord)
    {
        _lowerBaseWord = baseWord.ToLower();
        _sortedBaseWord = GetSortedString(_lowerBaseWord);
    }

    public string[] FindAnagrams(string[] potentialMatches)
    {
        var validAnagrams = new List<string>();

        foreach (var candidate in potentialMatches){
            string lowerCandidate = candidate.ToLower();
            if (lowerCandidate == _lowerBaseWord){
                continue;
            }

            if (lowerCandidate.Length == _lowerBaseWord.Length && 
                GetSortedString(lowerCandidate) == _sortedBaseWord){
                validAnagrams.Add(candidate);    
            }
        }
        return validAnagrams.ToArray();
    }

    private string GetSortedString(string input){
        return string.Concat(input.OrderBy(c => c));
    }
}