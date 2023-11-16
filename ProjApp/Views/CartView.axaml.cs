using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ProjApp.ViewModels;

namespace ProjApp.Views;

public partial class CartView : UserControl
{
    public CartView()
    {
        InitializeComponent();
        DataContext = new CartViewModel(); 
    }
}