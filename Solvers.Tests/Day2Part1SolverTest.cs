namespace Solvers.Tests;

public class Day2Part1SolverTest
{
    [Fact]
    public async Task Example()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day2Part1Example.txt");
        var sut = new Day2Part1Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("8", solution);
    }

    [Fact]
    public async Task Actual()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day2Part1.txt");
        var sut = new Day2Part1Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("2776", solution);
    }
}
