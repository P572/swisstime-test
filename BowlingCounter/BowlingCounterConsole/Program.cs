using BetterConsoleTables;
using Core;
using Microsoft.Extensions.DependencyInjection;

namespace BowlingCounterConsole;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Input frame scores, one frame at a time, results separated by spaces:");

        var frameInputs =
            Enumerable.Range(1, 10)
                .Select(frameNo =>
                {
                    Console.WriteLine($"Input frame {frameNo} scores:");
                    var frameInput = Console.ReadLine();
                    var throwValues = frameInput!.Split(' ').Select(int.Parse).ToArray();
                    var firstThrow = throwValues.First();
                    int? secondThrow = throwValues.Length > 1 ? throwValues[1] : null;
                    int? thirdThrow = throwValues.Length > 2 ? throwValues[2] : null;
                    return (firstThrow, secondThrow, thirdThrow);
                })
                .ToArray();

        var scoreResult = GetBowlingScoreCounter().Create(frameInputs);

        var table = CreateTable(scoreResult);

        Console.Write(table);
        Console.ReadKey();
    }

    private static IBowlingScoreFactory GetBowlingScoreCounter()
    {
        var serviceProvider = new ServiceCollection()
            .AddBowlingCounterServices()
            .BuildServiceProvider();

        return serviceProvider.GetRequiredService<IBowlingScoreFactory>();
    }

    private static string CreateTable(GameScoreResult scoreResult)
    {
        var table =
            new Table(scoreResult.FrameScores.Select((_, index) =>
                new ColumnHeader($"Frame {index + 1}")).Append("Total").ToArray());

        var throwsValues = scoreResult.FrameScores.Select(frameScore => frameScore.GetScoreValue()).ToArray();
        var totalScoreValues =
            scoreResult.FrameScores
                .Select(frameScore => frameScore.FrameScore.ToString())
                .Append(scoreResult.TotalScore.ToString())
                .ToArray();

        table.AddRow(throwsValues);
        table.AddRow(totalScoreValues);

        return table.ToString();
    }
}