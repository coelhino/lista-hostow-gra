using Avalonia.Controls;
using Avalonia.Interactivity;
using DayZGameHostListFixed.ViewModels;

namespace DayZGameHostListFixed.Views;

public partial class MainWindow : Window
{
    private readonly MainViewModel _viewModel;

    public MainWindow()
    {
        InitializeComponent();
        _viewModel = new MainViewModel();
        DataContext = _viewModel;
    }

    private void SortujPoAdresie_Click(object? sender, RoutedEventArgs e)
    {
        _viewModel.SortujPoAdresie();
    }

    private void SortujPoGraczach_Click(object? sender, RoutedEventArgs e)
    {
        _viewModel.SortujPoGraczach();
    }
}