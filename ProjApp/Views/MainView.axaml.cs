using Avalonia.Controls;
using Avalonia.Interactivity;
using ProjApp.ViewModels;

namespace ProjApp.Views;

public partial class MainView : UserControl
{
    // создаем экземпляр MainViewModel для связи с MainView
    public MainView()
    {
        InitializeComponent();
        MainViewModel mainViewModel = new MainViewModel();
        DataContext = mainViewModel;
    }
}