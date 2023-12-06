namespace Solvers.Tests;

public class Day5Part2SolverTest
{
    [Fact]
    public async Task Example()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day5Part2Example.txt");
        var sut = new Day5Part2Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("46", solution);
    }

    [Fact(Skip = "Brute force")]
    public async Task Actual()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day5Part2.txt");
        var sut = new Day5Part2Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("27992443", solution);
    }
}
