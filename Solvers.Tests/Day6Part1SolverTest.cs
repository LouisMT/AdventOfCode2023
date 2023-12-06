namespace Solvers.Tests;

public class Day6Part1SolverTest
{
    [Fact]
    public async Task Example()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day6Part1Example.txt");
        var sut = new Day6Part1Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("288", solution);
    }

    [Fact]
    public async Task Actual()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day6Part1.txt");
        var sut = new Day6Part1Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("219849", solution);
    }
}
