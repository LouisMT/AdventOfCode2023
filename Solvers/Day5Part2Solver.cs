namespace Solvers;

public class Day5Part2Solver : ISolver
{
    public async Task<string> Solve(string input)
    {
        var (seedsString, categoryStrings) = input.Split(new[] { "\r\n\r\n", "\n\n" }, StringSplitOptions.RemoveEmptyEntries) switch
        {
            [var s, .. var c] => (s, c),
            _ => throw new Exception("Invalid input")
        };

        var intervals = seedsString.Split(' ') switch
        {
            ["seeds:", .. var s] => ParseIntervals(s),
            _ => throw new Exception("Invalid seeds string")
        };

        var categories = categoryStrings.Select(ParseCategory).ToArray();

        var smallestValues = await Task.WhenAll(intervals.Select(i => SmallestValue(i, categories)));

        return smallestValues.Min().ToString();
    }

    private record Range(long DestinationStart, long SourceStart, long Length);

    private record Category(string Name, Range[] Ranges);

    private Category ParseCategory(string categoryString)
    {
        var (nameString, rangeStrings) = categoryString.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries) switch
        {
            [var n, .. var r] => (n, r),
            _ => throw new Exception("Invalid category string")
        };

        var name = nameString.Split(' ')[0];

        var ranges = rangeStrings.Select(r => r.Split(' ') switch
        {
            [var d, var s, var l] => new Range(long.Parse(d), long.Parse(s), long.Parse(l)),
            _ => throw new Exception("Invalid range string")
        }).ToArray();

        return new Category(name, ranges);
    }

    private record Interval(long Start, long Length)
    {
        public IEnumerable<long> Seeds()
        {
            for (var count = 0; count < Length; count++)
            {
                yield return Start + count;
            }
        }
    }

    private static IEnumerable<Interval> ParseIntervals(string[] seedStrings)
    {
        return seedStrings.Select(long.Parse).Chunk(2).Select(c => new Interval(c[0], c[1]));
    }

    private static Task<long> SmallestValue(Interval interval, Category[] categories)
    {
        return Task.Run(() =>
        {
            var smallestValue = long.MaxValue;

            foreach (var seed in interval.Seeds())
            {
                var currentValue = seed;

                for (var i = 0; i < categories.Length; i++)
                {
                    var category = categories[i];

                    for (var j = 0; j < category.Ranges.Length; j++)
                    {
                        var range = category.Ranges[j];
                        var difference = currentValue - range.SourceStart;

                        if (difference >= 0 && difference < range.Length)
                        {
                            currentValue = range.DestinationStart + difference;
                            break;
                        }
                    }
                }

                smallestValue = Math.Min(smallestValue, currentValue);
            }

            return smallestValue;
        });
    }
}
