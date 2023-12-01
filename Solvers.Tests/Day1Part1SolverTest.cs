namespace Solvers.Tests;

public class Day1Part1SolverTest
{
    [Fact]
    public async Task Example()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day1Part1Example.txt");
        var sut = new Day1Part1Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("142", solution);
    }

    [Fact]
    public async Task Actual()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day1Part1.txt");
        var sut = new Day1Part1Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("", solution);
    }
}
