namespace Solvers.Tests;

public class Day7Part2SolverTest
{
    [Fact]
    public async Task Example()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day7Part2Example.txt");
        var sut = new Day7Part2Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("5905", solution);
    }

    [Fact]
    public async Task Actual()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day7Part2.txt");
        var sut = new Day7Part2Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("246285222", solution);
    }
}
