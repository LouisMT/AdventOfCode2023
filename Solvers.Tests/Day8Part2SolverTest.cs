namespace Solvers.Tests;

public class Day8Part2SolverTest
{
    [Fact]
    public async Task Example()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day8Part2Example.txt");
        var sut = new Day8Part2Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("6", solution);
    }

    [Fact]
    public async Task Actual()
    {
        var input = await File.ReadAllTextAsync("Inputs/Day8Part2.txt");
        var sut = new Day8Part2Solver();

        var solution = await sut.Solve(input);

        Assert.Equal("22103062509257", solution);
    }
}
