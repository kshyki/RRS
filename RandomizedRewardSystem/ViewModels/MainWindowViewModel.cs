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
    public int roundMultiplier
    {
        get => _roundMultiplier;
        set => this.RaiseAndSetIfChanged(ref _roundMultiplier, value);
    }

    
}
