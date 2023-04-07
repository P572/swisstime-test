namespace Core;

public class BowlingScoreFactory : IBowlingScoreFactory
{
    private readonly IFrameWithConsecutiveFramesFactory _frameWithConsecutiveFramesFactory;
    private readonly IFrameScoreResultFactory _scoreResultFactory;
    private readonly IFrameThrowResultFactory _frameThrowResultFactory;

    public BowlingScoreFactory(
        IFrameWithConsecutiveFramesFactory frameWithConsecutiveFramesFactory,
        IFrameScoreResultFactory scoreResultFactory,
        IFrameThrowResultFactory frameThrowResultFactory)
    {
        _frameWithConsecutiveFramesFactory = frameWithConsecutiveFramesFactory;
        _scoreResultFactory = scoreResultFactory;
        _frameThrowResultFactory = frameThrowResultFactory;
    }

    public GameScoreResult Create((int firstThrowPinsCleared, int? secondThrowPinsCleared, int? thirdThrowPinsCleared)[] inputs)
    {
        var throws = _frameThrowResultFactory.CreateFrameThrowResults(inputs);
        return new GameScoreResult(throws, _frameWithConsecutiveFramesFactory, _scoreResultFactory);
    }
}