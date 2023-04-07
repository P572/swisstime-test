namespace Core;

public class GameScoreResult
{
    public GameScoreResult(FrameThrowResult[] throws, IFrameWithConsecutiveFramesFactory frameWithConsecutiveFramesFactory, IFrameScoreResultFactory frameScoreResultFactory)
    {
        var frameThrowsWithTwoConsecutiveFrames =
            throws.Select((frameThrowResult, index) =>
                frameWithConsecutiveFramesFactory.CreateFrame(
                    frameThrowResult,
                    throws.Skip(index + 1).Take(2).ToArray()));

        FrameScores =
            frameThrowsWithTwoConsecutiveFrames
                .Select(frameThrow =>
                {
                    var firstConsecutiveThrowScore = frameThrow.ConsecutiveFramesType switch
                    {
                        ConsecutiveFramesType.HasOneConsecutiveFrame or ConsecutiveFramesType.HasTwoConsecutiveFrames =>
                            frameThrow.FirstConsecutiveFrame!.FirstThrowPinsCleared,
                        _ => 0
                    };

                    var secondConsecutiveThrowScore = frameThrow.ConsecutiveFramesType switch
                    {
                        ConsecutiveFramesType.HasOneConsecutiveFrame or ConsecutiveFramesType.HasTwoConsecutiveFrames
                            when frameThrow.FirstConsecutiveFrame!.FrameResultType is not FrameResultType.Strike =>
                            frameThrow.FirstConsecutiveFrame.SecondThrowPinsCleared!.Value,
                        ConsecutiveFramesType.HasTwoConsecutiveFrames
                            when frameThrow.FirstConsecutiveFrame!.FrameResultType is FrameResultType.Strike =>
                            frameThrow.SecondConsecutiveFrame!.FirstThrowPinsCleared,
                        _ => 0
                    };

                    return frameScoreResultFactory.CreateFrameScoreResult(frameThrow.MainFrame, firstConsecutiveThrowScore, secondConsecutiveThrowScore);
                })
                .ToArray();
    }


    public FrameScoreResult[] FrameScores { get; }

    public int TotalScore => FrameScores.Sum(frameScore=>frameScore.FrameScore);
}