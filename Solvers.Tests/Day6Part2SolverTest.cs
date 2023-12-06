namespace Solvers.Tests;

public class Day6Part2SolverTest
{
    [Fact]
    public async Task Example()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day6Part2Example.txt");
        var sut = new Day6Part2Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("71503", solution);
    }

    [Fact]
    public async Task Actual()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day6Part2.txt");
        var sut = new Day6Part2Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("29432455", solution);
    }
}
