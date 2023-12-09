using System.Text.RegularExpressions;

namespace Solvers;

public class Day8Part2Solver : ISolver
{
    public Task<string> Solve(string input)
    {
        var (instructions, nodesString) = input.Split(DoubleLineSeparator, StringSplitOptions.RemoveEmptyEntries) switch
        {
            [var i, var n] => (i.ToCharArray(), n),
            _ => throw new Exception("Invalid input")
        };

        var nodes = ParseNodes(nodesString);

        var currentNodeNames = nodes.Keys.Where(k => k.EndsWith('A')).ToArray();
        var stepCounts = new long[currentNodeNames.Length];

        for (var i = 0; i < currentNodeNames.Length; i++)
        {
            var currentNodeName = currentNodeNames[i];

            while (!currentNodeName.EndsWith('Z'))
            {
                var instruction = instructions[stepCounts[i] % instructions.Length];

                currentNodeName = instruction switch
                {
                    'L' => nodes[currentNodeName].Left,
                    'R' => nodes[currentNodeName].Right,
                    _ => throw new Exception("Invalid step")
                };

                stepCounts[i]++;
            }
        }

        var lcm = stepCounts.Aggregate(1L, Lcm);

        return Task.FromResult(lcm.ToString());
    }

    private static readonly string[] DoubleLineSeparator = ["\r\n\r\n", "\n\n"];

    private static readonly string[] LineSeparator = ["\r\n", "\n"];

    private static readonly Regex NodeRegex = new(@"(?<Name>\w{3}) = \((?<Left>\w{3}), (?<Right>\w{3})\)");

    private record Node(string Left, string Right);

    private static Dictionary<string, Node> ParseNodes(string nodesString)
    {
        return nodesString.Split(LineSeparator, StringSplitOptions.RemoveEmptyEntries)
            .Select(n => NodeRegex.Match(n))
            .ToDictionary(n => n.Groups["Name"].Value, n => new Node(n.Groups["Left"].Value, n.Groups["Right"].Value));

    }

    private static long Lcm(long a, long b)
    {
        return a * b / Gcd(a, b);
    }

    private static long Gcd(long a, long b)
    {
        return b == 0 ? a : Gcd(b, a % b);
    }
}
