namespace Solvers.Tests;

public class Day9Part2SolverTest
{
    [Fact]
    public async Task Example()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day9Part2Example.txt");
        var sut = new Day9Part2Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("2", solution);
    }

    [Fact]
    public async Task Actual()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day9Part2.txt");
        var sut = new Day9Part2Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("1089", solution);
    }
}
