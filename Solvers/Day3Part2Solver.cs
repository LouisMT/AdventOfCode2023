namespace Solvers;

public class Day3Part2Solver : ISolver
{
    public Task<string> Solve(string input)
    {
        var sum = 0;

        var grid = input.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries).Select(l => l.ToCharArray()).ToArray();

        for (var lineIndex = 0; lineIndex < grid.Length; lineIndex++)
        {
            for (var colIndex = 0; colIndex < grid[lineIndex].Length; colIndex++)
            {
                if (grid[lineIndex][colIndex] == '*')
                {
                    sum += ComputeGearRatio(grid, lineIndex, colIndex);
                }
            }
        }

        return Task.FromResult(sum.ToString());
    }

    private static int ComputeGearRatio(char[][] grid, int lineIndex, int colIndex)
    {
        var numbers = new List<int>();

        for (var searchLineIndex = lineIndex - 1; searchLineIndex <= lineIndex + 1; searchLineIndex++)
        {
            if (searchLineIndex < 0 || searchLineIndex > grid.Length - 1)
            {
                continue;
            }

            var startColIndex = colIndex;

            for (var searchColIndex = colIndex - 1; searchColIndex >= 0; searchColIndex--)
            {
                if (char.IsDigit(grid[searchLineIndex][searchColIndex]))
                {
                    startColIndex = searchColIndex;
                }
                else
                {
                    break;
                }
            }

            for (var searchColIndex = startColIndex; searchColIndex < grid[searchLineIndex].Length + 1; searchColIndex++)
            {
                // Add a fake character after the last column, to make sure numbers at the end are processed.
                var character = searchColIndex == grid[searchLineIndex].Length ? '.' : grid[searchLineIndex][searchColIndex];

                if (!char.IsDigit(character))
                {
                    if (startColIndex != searchColIndex)
                    {
                        numbers.Add(int.Parse(grid[searchLineIndex][startColIndex..searchColIndex]));
                    }

                    if (searchColIndex == colIndex)
                    {
                        // Process possible second adjecent number in this line.
                        startColIndex = colIndex + 1;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        return numbers.Count == 2 ? numbers[0] * numbers[1] : 0;
    }
}
