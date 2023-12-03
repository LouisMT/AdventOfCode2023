namespace Solvers.Tests;

public class Day3Part1SolverTest
{
    [Fact]
    public async Task Example()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day3Part1Example.txt");
        var sut = new Day3Part1Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("4361", solution);
    }

    [Fact]
    public async Task Actual()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day3Part1.txt");
        var sut = new Day3Part1Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("546563", solution);
    }
}
