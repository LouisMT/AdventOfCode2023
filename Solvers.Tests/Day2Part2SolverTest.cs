namespace Solvers.Tests;

public class Day2Part2SolverTest
{
    [Fact]
    public async Task Example()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day2Part2Example.txt");
        var sut = new Day2Part2Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("2286", solution);
    }

    [Fact]
    public async Task Actual()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day2Part2.txt");
        var sut = new Day2Part2Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("68638", solution);
    }
}
