namespace Solvers.Tests;

public class Day4Part1SolverTest
{
    [Fact]
    public async Task Example()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day4Part1Example.txt");
        var sut = new Day4Part1Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("13", solution);
    }

    [Fact]
    public async Task Actual()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day4Part1.txt");
        var sut = new Day4Part1Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("20667", solution);
    }
}
