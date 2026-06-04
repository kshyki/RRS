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

    private int _gameMultiplier;
    public int GameMultiplier
    {
        get => _gameMultiplier;
        set => this.RaiseAndSetIfChanged(ref _gameMultiplier, value);
    }

    public MainWindowViewModel()
    {
        UpdateSymbolList();

        PlayCommand = new SimpleCommand(() =>
        {
            _game.PlayRound();

            TotalScore = _game.totalScore;
            CurrentRound = _game.currentRound;
            GameMultiplier = _game.gameMultiplier;

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
