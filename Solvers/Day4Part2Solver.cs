using System.Collections.Immutable;
using Solvers.Helpers;

namespace Solvers;

public class Day4Part2Solver : ISolver
{
    public async Task<string> Solve(string input)
    {
        var cardCount = new Dictionary<int, int>();

        await foreach(var line in InputHelper.Lines(input))
        {
            var card = Parse(line);

            cardCount.TryAdd(card.Number, 0);
            cardCount[card.Number] += 1;

            var copyCount = cardCount.GetValueOrDefault(card.Number);
            var winAmount = card.MyNumbers.Where(n => card.WinningNumbers.Contains(n)).Count();

            for(var inc = winAmount; inc > 0; inc--)
            {
                cardCount.TryAdd(card.Number + inc, 0);
                cardCount[card.Number + inc] += cardCount[card.Number];
            }
        }

        return cardCount.Values.Sum().ToString();
    }

    private record Card(int Number, ISet<int> WinningNumbers, IEnumerable<int> MyNumbers);

    private static Card Parse(string line)
    {
        var (cardString, numbersString) = line.Split(": ") switch { var r => (r[0], r[1]) };
        var (winningNumbersString, myNumbersString) = numbersString.Split(" | ") switch { var r => (r[0], r[1]) };
        var cardNumber = cardString.Split(' ', StringSplitOptions.RemoveEmptyEntries) switch
        {
            ["Card", var number] => int.Parse(number),
            _ => throw new Exception("Invalid card identifier")
        };

        var winningNumbers = winningNumbersString.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToHashSet();
        var myNumbers = myNumbersString.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);

        return new Card(cardNumber, winningNumbers, myNumbers);
    }
}
