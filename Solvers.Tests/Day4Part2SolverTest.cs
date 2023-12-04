namespace Solvers.Tests;

public class Day4Part2SolverTest
{
    [Fact]
    public async Task Example()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day4Part2Example.txt");
        var sut = new Day4Part2Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("30", solution);
    }

    [Fact]
    public async Task Actual()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day4Part2.txt");
        var sut = new Day4Part2Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("5833065", solution);
    }
}
