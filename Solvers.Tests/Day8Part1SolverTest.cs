namespace Solvers.Tests;

public class Day8Part1SolverTest
{
    [Fact]
    public async Task Example()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day8Part1Example.txt");
        var sut = new Day8Part1Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("6", solution);
    }

    [Fact]
    public async Task Actual()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day8Part1.txt");
        var sut = new Day8Part1Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("20093", solution);
    }
}
