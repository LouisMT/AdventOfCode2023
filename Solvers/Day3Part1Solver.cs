using Solvers.Helpers;

namespace Solvers;

public class Day3Part1Solver : ISolver
{
    public Task<string> Solve(string input)
    {
        var sum = 0;

        var grid = input.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries).Select(l => l.ToCharArray()).ToArray();

        for (var lineIndex = 0; lineIndex < grid.Length; lineIndex++)
        {
            var startColIndex = -1;

            for (var colIndex = 0; colIndex < grid[lineIndex].Length + 1; colIndex++)
            {
                // Add a fake character after the last column, to make sure numbers at the end are processed.
                var character = colIndex == grid[lineIndex].Length ? '.' : grid[lineIndex][colIndex];

                if (char.IsDigit(character) && startColIndex == -1)
                {
                    startColIndex = colIndex;
                }
                else if (!char.IsDigit(character) && startColIndex != -1)
                {
                    if (IsPart(grid, lineIndex, startColIndex, colIndex))
                    {
                        var number = int.Parse(grid[lineIndex][startColIndex..colIndex]);
                        sum += number;
                    }

                    startColIndex = -1;
                }
            }
        }

        return Task.FromResult(sum.ToString());
    }

    private static bool IsPart(char[][] grid, int lineIndex, int startColumnIndex, int endColumnIndex)
    {
        var searchStartColIndex = Math.Max(startColumnIndex - 1, 0);
        var searchEndColIndex = Math.Min(endColumnIndex + 1, grid[lineIndex].Length);

        for (var searchLineIndex = lineIndex - 1; searchLineIndex <= lineIndex + 1; searchLineIndex++)
        {
            if (searchLineIndex < 0 || searchLineIndex > grid.Length - 1)
            {
                continue;
            }

            var characters = grid[searchLineIndex][searchStartColIndex..searchEndColIndex];

            if (characters.Any(c => !char.IsDigit(c) && c != '.'))
            {
                return true;
            }
        }

        return false;
    }
}
