namespace Core;

internal class FrameWithConsecutiveFramesFactory : IFrameWithConsecutiveFramesFactory
{
    public FrameWithConsecutiveFrames CreateFrame(FrameThrowResult mainFrame, FrameThrowResult[] consecutiveFrames) =>
        FrameWithConsecutiveFrames.CreateFrameWithConsecutiveFrames(mainFrame, consecutiveFrames);
}