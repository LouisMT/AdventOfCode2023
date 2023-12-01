namespace Solvers.Helpers;

public static class InputHelper
{
    public static async IAsyncEnumerable<string> Lines(string input)
    {
        var reader = new StringReader(input);

        string? line;

        while ((line = await reader.ReadLineAsync()) != null)
        {
            yield return line;
        }
    }
}