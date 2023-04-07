namespace Core;

public interface IFrameWithConsecutiveFramesFactory
{
    public FrameWithConsecutiveFrames CreateFrame(FrameThrowResult mainFrame, FrameThrowResult[] consecutiveFrames);
}