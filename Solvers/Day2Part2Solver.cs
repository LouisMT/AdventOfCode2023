using Solvers.Helpers;

namespace Solvers;

public class Day2Part2Solver : ISolver
{
    public async Task<string> Solve(string input)
    {
        var sum = 0;

        await foreach (var line in InputHelper.Lines(input))
        {
            var game = ParseGame(line);
            var maxCubeSet = new CubeSet(0, 0, 0);

            foreach (var cubeSet in game.CubeSets)
            {
                maxCubeSet = new CubeSet(Math.Max(cubeSet.Red, maxCubeSet.Red), Math.Max(cubeSet.Green, maxCubeSet.Green), Math.Max(cubeSet.Blue, maxCubeSet.Blue));
            }

            sum += maxCubeSet.Red * maxCubeSet.Green * maxCubeSet.Blue;
        }

        return sum.ToString();
    }

    private record CubeSet(int Red, int Green, int Blue);

    private record Game(int Id, ICollection<CubeSet> CubeSets);

    private static Game ParseGame(string line)
    {
        var (gameString, cubeSetStrings) = line.Split(": ") switch { var r => (r[0], r[1]) };

        var game = gameString.Split(' ') switch
        {
            ["Game", var id] => new Game(int.Parse(id), new List<CubeSet>()),
            _ => throw new Exception("Invalid game string")
        };

        foreach (var cubeSetString in cubeSetStrings.Split("; "))
        {
            var cubeSet = new CubeSet(0, 0, 0);

            foreach (var cubeString in cubeSetString.Split(", "))
            {
                cubeSet = cubeString.Split(' ') switch
                {
                    [var amount, "red"] => cubeSet with { Red = int.Parse(amount) },
                    [var amount, "green"] => cubeSet with { Green = int.Parse(amount) },
                    [var amount, "blue"] => cubeSet with { Blue = int.Parse(amount) },
                    _ => throw new Exception("Invalid cube string")
                };
            }

            game.CubeSets.Add(cubeSet);
        }

        return game;
    }
}
