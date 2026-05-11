using ReactiveUI;
using System.Reactive;
namespace RandomizedRewardSystem.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private long _totalScore;
    public long TotalScore
    {
        get => _totalScore;
        set => this.RaiseAndSetIfChanged(ref _totalScore, value);
    }

    private int _currentRound;
    public int CurrentRound
    {
        get => _currentRound;
        set => this.RaiseAndSetIfChanged(ref _currentRound, value);
    }

    private int _roundMultiplier;
    public int RoundMultiplier
    {
        get => _roundMultiplier;
        set => this.RaiseAndSetIfChanged(ref _roundMultiplier, value);
    }

    public MainWindowViewModel()
    {
        PlayCommand = ReactiveCommand.Create(() =>
        {
           _game.PlayRound();
           TotalScore = _game.totalScore;
           CurrentRound = _game.currentRound;
           RoundMultiplier = _game.roundMultiplier; 
        });
    }
}
