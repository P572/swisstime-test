namespace Core;

public class FrameWithConsecutiveFrames
{
    public FrameThrowResult MainFrame { get; set; }
    public FrameThrowResult? FirstConsecutiveFrame { get; set; }
    public FrameThrowResult? SecondConsecutiveFrame { get; set; }

    public ConsecutiveFramesType ConsecutiveFramesType { get; set; }

    public FrameWithConsecutiveFrames(){}

    public static FrameWithConsecutiveFrames CreateFrameWithConsecutiveFrames(FrameThrowResult mainFrame, FrameThrowResult[] consecutiveFrames)
    {
        var result = new FrameWithConsecutiveFrames
        {
            MainFrame = mainFrame
        };

        var hasFirstConsecutiveFrame = consecutiveFrames.Length > 0;
        var hasSecondConsecutiveFrame = consecutiveFrames.Length > 1;

        result.ConsecutiveFramesType =
            hasSecondConsecutiveFrame
                ? ConsecutiveFramesType.HasTwoConsecutiveFrames
                : hasFirstConsecutiveFrame
                    ? ConsecutiveFramesType.HasOneConsecutiveFrame
                    : ConsecutiveFramesType.HasNoConsecutiveFrames;

        if (hasFirstConsecutiveFrame)
        {
            result.FirstConsecutiveFrame = consecutiveFrames.First();
        }

        if (hasSecondConsecutiveFrame)
        {
            result.SecondConsecutiveFrame = consecutiveFrames.Skip(1).First();
        }

        return result;
    }

}