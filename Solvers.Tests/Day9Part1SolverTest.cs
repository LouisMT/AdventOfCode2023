namespace Solvers.Tests;

public class Day9Part1SolverTest
{
    [Fact]
    public async Task Example()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day9Part1Example.txt");
        var sut = new Day9Part1Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("114", solution);
    }

    [Fact]
    public async Task Actual()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day9Part1.txt");
        var sut = new Day9Part1Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("2101499000", solution);
    }
}
