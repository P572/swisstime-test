namespace Core;

public interface IFrameScoreResultFactory
{
    FrameScoreResult CreateFrameScoreResult(
        FrameThrowResult frameThrowResult,
        int firstConsecutiveThrowScore,
        int secondConsecutiveThrowScore);
}