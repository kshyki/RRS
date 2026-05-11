using ReactiveUI;
using System.Windows.Input;
using System.Collections.ObjectModel;
using RandomizedRewardSystem.Models;

namespace RandomizedRewardSystem.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<Symbol?> Symbols { get; } = new();
    private GameSession _game = new GameSession();
    public ICommand PlayCommand { get; }
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

           UpdateSymbolList();
        });
    }

    private void UpdateSymbolList()
    {
        Symbols.Clear();
        for(int r = 0; r < 6; r++)
        {
            for(int c = 0; c < 5; c++)
            {
                Symbols.Add(_game.board.Grid[r,c]);
            }
        }
    }
}
