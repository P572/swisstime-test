namespace Core;

public interface IFrameThrowResultFactory
{
    FrameThrowResult[] CreateFrameThrowResults(
        (int firstThrowPinsCleared, int? secondThrowPinsCleared, int? thirdThrowPinsCleared)[] inputs);
}

internal class FrameThrowResultFactory : IFrameThrowResultFactory
{
    public FrameThrowResult[] CreateFrameThrowResults(
        (int firstThrowPinsCleared, int? secondThrowPinsCleared, int? thirdThrowPinsCleared)[] inputs)
    {
        return inputs
            .Select(input =>
                FrameThrowResult.CreateResult(input.firstThrowPinsCleared, input.secondThrowPinsCleared, input.thirdThrowPinsCleared))
            .ToArray();
    }
}