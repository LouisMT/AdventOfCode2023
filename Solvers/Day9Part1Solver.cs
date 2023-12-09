namespace Solvers;

public class Day9Part1Solver : ISolver
{
    public Task<string> Solve(string input)
    {
        var sum = 0;
        var lines = input.Split(LineSeparator, StringSplitOptions.RemoveEmptyEntries);
        var histories = lines.Select(l => l.Split(' ').Select(int.Parse).ToList()).ToList();

        foreach (var history in histories)
        {
            var sequences = new List<List<int>> { history };
            var previousSequence = history;

            while (!previousSequence.All(d => d == 0))
            {
                var currentSequence = new List<int>();

                for (var i = 0; i < previousSequence.Count - 1; i++)
                {
                    currentSequence.Add(previousSequence[i + 1] - previousSequence[i]);
                }

                sequences.Add(currentSequence);
                previousSequence = currentSequence;
            }

            var previousValue = 0;

            for (var i = sequences.Count - 1; i >= 0; i--)
            {
                previousValue += sequences[i][^1];
            }

            sum += previousValue;
        }

        return Task.FromResult(sum.ToString());
    }

    private static readonly string[] LineSeparator = ["\r\n", "\n"];
}
