namespace Solvers.Tests;

public class Day1Part2SolverTest
{
    [Fact]
    public async Task Example()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day1Part2Example.txt");
        var sut = new Day1Part2Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("281", solution);
    }

    [Fact]
    public async Task Actual()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day1Part2.txt");
        var sut = new Day1Part2Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("54770", solution);
    }
}
