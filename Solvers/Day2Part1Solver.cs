using Solvers.Helpers;

namespace Solvers;

public class Day2Part1Solver : ISolver
{
    public async Task<string> Solve(string input)
    {
        var sum = 0;

        await foreach (var line in InputHelper.Lines(input))
        {
            var game = ParseGame(line);

            if (game.CubeSets.All(cubeSet => cubeSet.Red <= _maxCubeSet.Red && cubeSet.Green <= _maxCubeSet.Green && cubeSet.Blue <= _maxCubeSet.Blue))
            {
                sum += game.Id;
            }
        }

        return sum.ToString();
    }

    private record CubeSet(int Red, int Green, int Blue);

    private record Game(int Id, ICollection<CubeSet> CubeSets);

    private readonly CubeSet _maxCubeSet = new(12, 13, 14);

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
