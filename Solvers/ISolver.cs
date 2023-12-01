namespace Solvers;

public interface ISolver
{
    Task<string> Solve(string input);
}
