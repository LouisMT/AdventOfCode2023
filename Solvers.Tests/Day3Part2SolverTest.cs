namespace Solvers.Tests;

public class Day3Part2SolverTest
{
    [Fact]
    public async Task Example()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day3Part2Example.txt");
        var sut = new Day3Part2Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("467835", solution);
    }

    [Fact]
    public async Task Actual()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day3Part2.txt");
        var sut = new Day3Part2Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("91031374", solution);
    }
}
