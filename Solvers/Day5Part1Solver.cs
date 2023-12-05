namespace Solvers;

public class Day5Part1Solver : ISolver
{
    public Task<string> Solve(string input)
    {
        var smallestValue = long.MaxValue;

        var (seedsString, categoryStrings) = input.Split(new[] { "\r\n\r\n", "\n\n" }, StringSplitOptions.RemoveEmptyEntries) switch
        {
            [var s, .. var c] => (s, c),
            _ => throw new Exception("Invalid input")
        };

        var seeds = seedsString.Split(' ') switch
        {
            ["seeds:", .. var s] => s.Select(long.Parse).ToList(),
            _ => throw new Exception("Invalid seeds string")
        };

        var categories = categoryStrings.Select(ParseCategory).ToList();

        foreach (var seed in seeds)
        {
            var currentValue = seed;

            foreach (var category in categories)
            {
                foreach (var range in category.Ranges)
                {
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

        return Task.FromResult(smallestValue.ToString());
    }

    private record Range(long DestinationStart, long SourceStart, long Length);

    private record Category(string Name, ICollection<Range> Ranges);

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
        }).ToList();

        return new Category(name, ranges);
    }
}
