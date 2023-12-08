namespace Solvers;

public class Day7Part2Solver : ISolver
{
    public Task<string> Solve(string input)
    {
        var hands = ParseHands(input);
        var orderedHands = hands.Order();
        var sum = orderedHands.Select((h, i) => (i + 1) * h.Bid).Sum();

        return Task.FromResult(sum.ToString());
    }

    private static readonly string[] LineSeparator = ["\r\n", "\n"];

    private static readonly IDictionary<char, int> Strength = new[]
    {
        'J', '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'Q', 'K', 'A'
    }.Select((c, s) => (c, s)).ToDictionary(g => g.c, g => g.s);

    private record Hand(char[] Cards, int Bid) : IComparable<Hand>
    {
        public int[] Groups { get; init; } = ComputeGroups(Cards);

        public int CompareTo(Hand? other)
        {
            if (other == null)
            {
                return 1;
            }

            var maxGroupsLength = Math.Max(Groups.Length, other.Groups.Length);

            for (var i = 0; i < maxGroupsLength; i++)
            {
                var groupSize = Groups.ElementAtOrDefault(i);
                var otherGroupSize = other.Groups.ElementAtOrDefault(i);
                var difference = groupSize.CompareTo(otherGroupSize);

                if (difference != 0)
                {
                    return difference;
                }
            }

            for (var i = 0; i < Cards.Length; i++)
            {
                var card = Cards[i];
                var otherCard = other.Cards[i];
                var difference = Strength[card].CompareTo(Strength[otherCard]);

                if (difference != 0)
                {
                    return difference;
                }
            }

            return 0;
        }

        private static int[] ComputeGroups(char[] cards)
        {
            var groups = cards.GroupBy(c => c).ToDictionary(c => c.Key, c => c.Count());
            var wildcardCount = groups.GetValueOrDefault('J');
            groups.Remove('J');
            var groupSizes = groups.Values.OrderDescending().ToArray();

            if (groupSizes.Length == 0)
            {
                // All J.
                return [5];
            }

            groupSizes[0] += wildcardCount;

            return groupSizes;
        }
    }

    private static List<Hand> ParseHands(string input)
    {
        var handStrings = input.Split(LineSeparator, StringSplitOptions.RemoveEmptyEntries);

        return handStrings.Select(h => h.Split(' ') switch
        {
            [var c, var b] => new Hand(c.ToCharArray(), int.Parse(b)),
            _ => throw new Exception("Invalid hand string")
        }).ToList();
    }
}
