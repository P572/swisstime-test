namespace Core;

public interface IBowlingScoreFactory
{
    GameScoreResult Create((int firstThrowPinsCleared, int? secondThrowPinsCleared, int? thirdThrowPinsCleared)[] inputs);
}