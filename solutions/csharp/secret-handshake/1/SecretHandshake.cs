public static class SecretHandshake
{
    public static string[] Commands(int commandValue)
    {
        List <string> action = new List<string>();
        if ((commandValue & 1) == 1) {
            action.Add("wink");
        }
        if ((commandValue & 2) == 2) {
            action.Add("double blink");
        }
        if ((commandValue & 4) == 4) {
            action.Add("close your eyes");
        }
        if ((commandValue & 8) == 8) {
            action.Add("jump");
        }
        if ((commandValue & 16) == 16) {
            action.Reverse();
        }
        return action.ToArray();
    }
}
