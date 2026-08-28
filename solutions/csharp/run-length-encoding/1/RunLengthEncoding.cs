using System.Text;
public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        if (string.IsNullOrEmpty(input)) {
            return "";
        }

        StringBuilder result = new StringBuilder();
        int count = 1;

        for (int i = 1; i < input.Length; i++) {
            if (input[i] == input[i - 1]) {
                count++;
            }
            else {
                if (count > 1) {
                    result.Append(count);
                }
                result.Append(input[i - 1]);
                count = 1;
            }
        }

        if (count > 1) {
            result.Append(count);
        }
        result.Append(input[input.Length - 1]);

        return result.ToString();
    }

    public static string Decode(string input)
    {
        StringBuilder result = new StringBuilder();
        string count = "";

        foreach (char c in input) {
            if (char.IsDigit(c)) {
                count += c;
            }
            else {
                int countNum = (count == "") ? 1 : int.Parse(count);
                result.Append(c, countNum);
                count = "";
            }
        }
        return result.ToString();
    }
}
