namespace Solvers.Tests;

public class Day5Part1SolverTest
{
    [Fact]
    public async Task Example()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day5Part1Example.txt");
        var sut = new Day5Part1Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("35", solution);
    }

    [Fact]
    public async Task Actual()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day5Part1.txt");
        var sut = new Day5Part1Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("379811651", solution);
    }
}
