using System.Text;
using Solvers.Helpers;

namespace Solvers;

public class Day1Part2Solver : ISolver
{
    public async Task<string> Solve(string input)
    {
        var total = 0;

        await foreach (var line in InputHelper.Lines(input))
        {
            var normalizedLine = Normalize(line);
            var digits = normalizedLine.Where(char.IsDigit);
            var number = $"{digits.First()}{digits.Last()}";

            total += int.Parse(number);
        }

        return total.ToString();
    }

    private readonly Dictionary<string, int> _digitMappings = new()
    {
        ["one"] = 1,
        ["two"] = 2,
        ["three"] = 3,
        ["four"] = 4,
        ["five"] = 5,
        ["six"] = 6,
        ["seven"] = 7,
        ["eight"] = 8,
        ["nine"] = 9
    };

    private string Normalize(string line)
    {
        var builder = new StringBuilder(line);

        foreach (var (name, digit) in _digitMappings)
        {
            builder.Replace(name, $"{name}{digit}{name}");
        }

        return builder.ToString();
    }
}
