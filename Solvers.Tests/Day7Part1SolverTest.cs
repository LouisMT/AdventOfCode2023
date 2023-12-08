namespace Solvers.Tests;

public class Day7Part1SolverTest
{
    [Fact]
    public async Task Example()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day7Part1Example.txt");
        var sut = new Day7Part1Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("6440", solution);
    }

    [Fact]
    public async Task Actual()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day7Part1.txt");
        var sut = new Day7Part1Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("248113761", solution);
    }
}
