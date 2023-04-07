namespace Core;

public class FrameScoreResult
{
    public FrameThrowResult FrameThrowResult { get; set; }
    public int FrameScore { get; set; }

    public static FrameScoreResult CreateResult(FrameThrowResult frameThrowResult, int firstConsecutiveThrowScore, int secondConsecutiveThrowScore)
    {
        var result = new FrameScoreResult
        {
            FrameThrowResult = frameThrowResult
        };

        var frameScore = frameThrowResult.FrameResultType switch
        {
            FrameResultType.Strike => 10 + firstConsecutiveThrowScore + secondConsecutiveThrowScore,
            FrameResultType.Spare => 10 + firstConsecutiveThrowScore,
            FrameResultType.TwoThrows =>
                frameThrowResult.FirstThrowPinsCleared +
                frameThrowResult.SecondThrowPinsCleared!.Value,
            FrameResultType.TenthFrameWithStrike or FrameResultType.TenthFrameWithSpare =>
                10 + frameThrowResult.ThirdThrowPinsCleared!.Value,
            _ => throw new ArgumentOutOfRangeException()
        };


        result.FrameScore = frameScore;

        return result;
    }

    public string GetScoreValue()
    {
        const char spareSign = '▲';
        const char strikeSign = '■';

        var strikeValue = $"10 {strikeSign}";
        var spareValue = $"{FrameThrowResult.FirstThrowPinsCleared} {spareSign}";
        return FrameThrowResult.FrameResultType switch
        {
            FrameResultType.Strike => strikeValue,
            FrameResultType.Spare => spareValue,
            FrameResultType.TwoThrows => $"{FrameThrowResult.FirstThrowPinsCleared} {FrameThrowResult.SecondThrowPinsCleared}",
            FrameResultType.TenthFrameWithStrike => $"{strikeValue} {FrameThrowResult.ThirdThrowPinsCleared}",
            FrameResultType.TenthFrameWithSpare => $"{spareValue} {FrameThrowResult.ThirdThrowPinsCleared}",
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}