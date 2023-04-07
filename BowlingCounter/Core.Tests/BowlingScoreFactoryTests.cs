using Moq;

namespace Core.Tests
{
    public class BowlingScoreFactoryTests
    {
        private readonly Mock<IFrameWithConsecutiveFramesFactory> _mockFrameWithConsecutiveFramesFactory = new();
        private readonly Mock<IFrameScoreResultFactory> _mockFrameScoreResultFactory = new();
        private readonly Mock<IFrameThrowResultFactory> _mockFrameThrowResultFactory = new();

        [Test]
        public void CreatesScore()
        {
            const int testScoreValue = 12;

            var testFrameThrowResults = TestData.ThrowResults;

            _mockFrameThrowResultFactory
                .Setup(mock =>
                    mock.CreateFrameThrowResults(It.IsAny<(int, int?, int?)[]>()))
                .Returns(testFrameThrowResults);

            _mockFrameWithConsecutiveFramesFactory
                .Setup(mock =>
                    mock.CreateFrame(It.IsAny<FrameThrowResult>(), It.IsAny<FrameThrowResult[]>()))
                .Returns(new FrameWithConsecutiveFrames
                {
                    MainFrame = testFrameThrowResults[0],
                    FirstConsecutiveFrame = testFrameThrowResults[1],
                    SecondConsecutiveFrame = testFrameThrowResults[2],
                    ConsecutiveFramesType = ConsecutiveFramesType.HasTwoConsecutiveFrames
                });

            _mockFrameScoreResultFactory
                .Setup(mock =>
                    mock.CreateFrameScoreResult(It.IsAny<FrameThrowResult>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new FrameScoreResult
                    { FrameScore = testScoreValue, FrameThrowResult = testFrameThrowResults[0] });


            var bowlingScoreFactory =
                new BowlingScoreFactory(
                    _mockFrameWithConsecutiveFramesFactory.Object,
                    _mockFrameScoreResultFactory.Object,
                    _mockFrameThrowResultFactory.Object);

            var result = bowlingScoreFactory.Create(new[] { (0, (int?)null, (int?)null) });

            Assert.AreEqual(testFrameThrowResults.Length, result.FrameScores.Length);
            Assert.AreEqual(testScoreValue * testFrameThrowResults.Length, result.TotalScore);
            Assert.True(result.FrameScores.All(score => score.FrameScore == testScoreValue));
        }
    }
}