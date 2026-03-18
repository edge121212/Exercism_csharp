public static class PigLatin
{
    public static string Translate(string sentence)
    {
        // 1. 將句子按空白拆分成單字
        string[] words = sentence.Split(' ');
        
        // 2. 對每個單字分別執行翻譯邏輯
        // 使用 LINQ 的 Select 或是簡單的 for 迴圈
        string[] translatedWords = words.Select(w => TranslateWord(w)).ToArray();
        
        // 3. 將翻譯後的單字用空白拼回去
        return string.Join(" ", translatedWords);
    }
    public static string TranslateWord(string word)
    {
        char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

        // 規則 1: 母音開頭 或 xr/yt
        // 使用 "aeiou".Contains(word[0]) 是很聰明的做法！
        if ("aeiou".Contains(word[0]) || word.StartsWith("xr") || word.StartsWith("yt"))
        {
            return word + "ay";
        }

        // 規則 3: 處理 "qu" (例如 square -> aresquay)
        int quIndex = word.IndexOf("qu");
        // 確保 qu 之前沒有母音
        if (quIndex != -1 && word.Substring(0, quIndex).IndexOfAny(vowels) == -1)
        {
            int splitPoint = quIndex + 2; // 切在 qu 之後
            return word.Substring(splitPoint) + word.Substring(0, splitPoint) + "ay";
        }

        // 規則 4: 子音群後接 "y" (例如 rhythm -> ythmrhay)
        int yIndex = word.IndexOf('y');
        if (yIndex > 0 && word.Substring(0, yIndex).IndexOfAny(vowels) == -1)
        {
            return word.Substring(yIndex) + word.Substring(0, yIndex) + "ay";
        }

        // 規則 2: 一般子音開頭，搬移至第一個母音前
        int firstVowelIndex = word.IndexOfAny(vowels);
        if (firstVowelIndex != -1)
        {
            return word.Substring(firstVowelIndex) + word.Substring(0, firstVowelIndex) + "ay";
        }
        else
        {
            // 如果單字完全沒有母音（雖然英文極少見），直接加 ay
            return word + "ay";
        }
    }
}