namespace Core;

internal class FrameScoreResultFactory : IFrameScoreResultFactory
{
    public FrameScoreResult CreateFrameScoreResult(
        FrameThrowResult frameThrowResult,
        int firstConsecutiveThrowScore,
        int secondConsecutiveThrowScore) =>
        FrameScoreResult.CreateResult(frameThrowResult, firstConsecutiveThrowScore, secondConsecutiveThrowScore);
}