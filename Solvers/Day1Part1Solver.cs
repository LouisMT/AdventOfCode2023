using Solvers.Helpers;

namespace Solvers;

public class Day1Part1Solver : ISolver
{
    public async Task<string> Solve(string input)
    {
        var total = 0;

        await foreach (var line in InputHelper.Lines(input))
        {
            var digits = line.Where(char.IsDigit);
            var number = $"{digits.First()}{digits.Last()}";

            total += int.Parse(number);
        }

        return total.ToString();
    }
}
