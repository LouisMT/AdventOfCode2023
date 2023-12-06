namespace Solvers;

public class Day6Part1Solver : ISolver
{
    public Task<string> Solve(string input)
    {
        var marginOfError = 1;

        var races = ParseRaces(input);

        foreach (var race in races)
        {
            var beatRecordCount = 0;

            for (var time = 0; time < race.Time; time++)
            {
                var timeLeft = race.Time - time;
                var distance = timeLeft * time;

                if (distance > race.Distance)
                {
                    beatRecordCount++;
                }
            }

            marginOfError *= beatRecordCount;
        }


        return Task.FromResult(marginOfError.ToString());
    }

    private record Race(int Time, int Distance);

    private static ICollection<Race> ParseRaces(string input)
    {
        var (timesString, distancesString) = input.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries) switch
        {
            [var t, var d] => (t, d),
            _ => throw new Exception("Invalid input format")
        };

        var times = timesString.Split(' ', StringSplitOptions.RemoveEmptyEntries) switch
        {
            ["Time:", .. var t] => t.Select(int.Parse),
            _ => throw new Exception("Invalid times format")
        };

        var distances = distancesString.Split(' ', StringSplitOptions.RemoveEmptyEntries) switch
        {
            ["Distance:", .. var d] => d.Select(int.Parse),
            _ => throw new Exception("Invalid distances format")
        };

        var races = times.Zip(distances, (t, d) => new Race(t, d)).ToList();

        return races;
    }
}
