namespace Core;

public class FrameThrowResult
{
    public static FrameThrowResult CreateResult(int firstThrowPinsCleared, int? secondThrowPinsCleared, int? thirdThrowPinsCleared) =>
        new()
        {
            FirstThrowPinsCleared = firstThrowPinsCleared,
            SecondThrowPinsCleared = secondThrowPinsCleared,
            ThirdThrowPinsCleared = thirdThrowPinsCleared,
            FrameResultType =
                firstThrowPinsCleared == 10
                    ? secondThrowPinsCleared == null ? FrameResultType.Strike : FrameResultType.TenthFrameWithStrike
                    : firstThrowPinsCleared + secondThrowPinsCleared == 10
                        ? thirdThrowPinsCleared == null ? FrameResultType.Spare : FrameResultType.TenthFrameWithSpare
                        : FrameResultType.TwoThrows
        };

    public int FirstThrowPinsCleared { get; set; }
    public int? SecondThrowPinsCleared { get; set; }
    public int? ThirdThrowPinsCleared { get; set; }

    public FrameResultType FrameResultType { get; set; }
}