using System;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using DynamicData;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json.Linq;
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


    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        
    }
    
}