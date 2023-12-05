using System.Collections.Immutable;
using Solvers.Helpers;

namespace Solvers;

public class Day4Part1Solver : ISolver
{
    public async Task<string> Solve(string input)
    {
        var sum = 0;

        await foreach (var line in InputHelper.Lines(input))
        {
            var card = Parse(line);
            var winAmount = card.MyNumbers.Where(n => card.WinningNumbers.Contains(n)).Count();

            sum += winAmount switch
            {
                0 => 0,
                var number => Enumerable.Repeat(1, number).Aggregate((a, b) => a * 2)
            };
        }

        return sum.ToString();
    }

    private record Card(ISet<int> WinningNumbers, IEnumerable<int> MyNumbers);

    private static Card Parse(string line)
    {
        var (cardString, numbersString) = line.Split(": ") switch { var r => (r[0], r[1]) };
        var (winningNumbersString, myNumbersString) = numbersString.Split(" | ") switch { var r => (r[0], r[1]) };

        var winningNumbers = winningNumbersString.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToHashSet();
        var myNumbers = myNumbersString.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);

        return new Card(winningNumbers, myNumbers);
    }
}
