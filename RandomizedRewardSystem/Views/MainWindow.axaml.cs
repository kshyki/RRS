using Avalonia.Controls;

namespace RandomizedRewardSystem.Views;
using RandomizedRewardSystem.ViewModels;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        DataContext = new MainWindowViewModel();
    }
}