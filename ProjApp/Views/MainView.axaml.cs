using Avalonia.Controls;
using ProjApp.ViewModels;

namespace ProjApp.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        MainViewModel mainViewModel = new MainViewModel();
        DataContext = mainViewModel;
    }
}