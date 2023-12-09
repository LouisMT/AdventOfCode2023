using System.Text.RegularExpressions;

namespace Solvers;

public class Day8Part1Solver : ISolver
{
    public Task<string> Solve(string input)
    {
        var (instructions, nodesString) = input.Split(DoubleLineSeparator, StringSplitOptions.RemoveEmptyEntries) switch
        {
            [var i, var n] => (i.ToCharArray(), n),
            _ => throw new Exception("Invalid input")
        };

        var nodes = ParseNodes(nodesString);

        var currentNodeName = "AAA";
        var stepCount = 0;

        while (currentNodeName != "ZZZ")
        {
            var instruction = instructions[stepCount % instructions.Length];

            currentNodeName = instruction switch
            {
                'L' => nodes[currentNodeName].Left,
                'R' => nodes[currentNodeName].Right,
                _ => throw new Exception("Invalid step")
            };

            stepCount++;
        }

        return Task.FromResult(stepCount.ToString());
    }

    private static readonly string[] DoubleLineSeparator = ["\r\n\r\n", "\n\n"];

    private static readonly string[] LineSeparator = ["\r\n", "\n"];

    private static readonly Regex NodeRegex = new(@"(?<Name>[A-Z]{3}) = \((?<Left>[A-Z]{3}), (?<Right>[A-Z]{3})\)");

    private record Node(string Left, string Right);

    private static Dictionary<string, Node> ParseNodes(string nodesString)
    {
        return nodesString.Split(LineSeparator, StringSplitOptions.RemoveEmptyEntries)
            .Select(n => NodeRegex.Match(n))
            .ToDictionary(n => n.Groups["Name"].Value, n => new Node(n.Groups["Left"].Value, n.Groups["Right"].Value));

    }
}
