namespace Core.Tests
{
    public static class TestData
    {
        public static FrameThrowResult[] ThrowResults => new[]
        {
            new FrameThrowResult
            {
                FirstThrowPinsCleared = 1, SecondThrowPinsCleared = 4, FrameResultType = FrameResultType.TwoThrows
            },
            new FrameThrowResult
            {
                FirstThrowPinsCleared = 4, SecondThrowPinsCleared = 5, FrameResultType = FrameResultType.TwoThrows
            },
            new FrameThrowResult
            {
                FirstThrowPinsCleared = 6, SecondThrowPinsCleared = 4, FrameResultType = FrameResultType.Spare
            },
            new FrameThrowResult
            {
                FirstThrowPinsCleared = 5, SecondThrowPinsCleared = 5, FrameResultType = FrameResultType.Spare
            },
            new FrameThrowResult
            {
                FirstThrowPinsCleared = 10, FrameResultType = FrameResultType.Strike
            },
            new FrameThrowResult
            {
                FirstThrowPinsCleared = 0, SecondThrowPinsCleared = 1, FrameResultType = FrameResultType.TwoThrows
            },
            new FrameThrowResult
            {
                FirstThrowPinsCleared = 7, SecondThrowPinsCleared = 3, FrameResultType = FrameResultType.Spare
            },
            new FrameThrowResult
            {
                FirstThrowPinsCleared = 6, SecondThrowPinsCleared = 4, FrameResultType = FrameResultType.Spare
            },
            new FrameThrowResult
            {
                FirstThrowPinsCleared = 10, FrameResultType = FrameResultType.Strike
            },
            new FrameThrowResult
            {
                FirstThrowPinsCleared = 2, SecondThrowPinsCleared = 8, ThirdThrowPinsCleared = 6, FrameResultType = FrameResultType.TenthFrameWithSpare
            }
        };
    }
}
