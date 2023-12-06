namespace Solvers;

public class Day6Part2Solver : ISolver
{
    public Task<string> Solve(string input)
    {
        var beatRecordCount = 0L;
        var race = ParseRace(input);

        for (var time = 0L; time < race.Time; time++)
        {
            var timeLeft = race.Time - time;
            var distance = timeLeft * time;

            if (distance > race.Distance)
            {
                beatRecordCount++;
            }
        }

        return Task.FromResult(beatRecordCount.ToString());
    }

    private record Race(long Time, long Distance);

    private static Race ParseRace(string input)
    {
        var (timesString, distancesString) = input.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries) switch
        {
            [var t, var d] => (t, d),
            _ => throw new Exception("Invalid input format")
        };

        var time = timesString.Split(' ', StringSplitOptions.RemoveEmptyEntries) switch
        {
            ["Time:", .. var t] => long.Parse(string.Join("", t)),
            _ => throw new Exception("Invalid times format")
        };

        var distance = distancesString.Split(' ', StringSplitOptions.RemoveEmptyEntries) switch
        {
            ["Distance:", .. var d] => long.Parse(string.Join("", d)),
            _ => throw new Exception("Invalid distances format")
        };

        return new Race(time, distance);
    }
}
