using Xunit;
using RandomizedRewardSystem.Models;
namespace RandomizedRewardSystem.Tests;

public class GameSessionTests
{
    [Fact]
    public void GameSession_ShouldInitializeCorrectly() // check initialization of the board
    {
        var game = new GameSession();
        Assert.Equal(0, game.currentRound);
        Assert.Equal(0, game.totalScore);
        Assert.Equal(1, game.gameMultiplier);
    }

    [Fact]
    public void PlayRound_ShouldIncreaseRound() // check whether the number of rounds is increasing
    {
        var game = new GameSession();
        game.PlayRound();
        Assert.Equal(1, game.currentRound);
    }

    [Fact]
    public void PlayRound_ShouldNotExceedMaxRounds() // check whether the number of rounds is <= 15
    {
        var game = new GameSession();
        for (int i = 0; i < 20; i++)
        {
            game.PlayRound();
        }
        Assert.True(game.currentRound <= 15);
    }

    [Fact]
    public void GameMultiplier_ShouldNeverDropBelowOne() // check whether multiplier >= 1
    {
        var game = new GameSession();

        game.PlayRound();

        Assert.True(game.gameMultiplier >= 1);

        for (int i = 0; i < 10; i++)
        {
            game.PlayRound();

            Assert.True(game.gameMultiplier >= 1);
        }
    }
}