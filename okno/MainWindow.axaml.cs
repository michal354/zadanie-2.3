using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace okno;

public partial class MainWindow : Window
{
    private readonly ObservableCollection<string> _orders = new();

    public MainWindow()
    {
        InitializeComponent();
        OrdersList.ItemsSource = _orders;
    }

    private void OnAddOrderClicked(object? sender, RoutedEventArgs e)
    {
        var text = RepairNameInput.Text?.Trim();
        if (!string.IsNullOrWhiteSpace(text))
        {
            _orders.Add($"#{_orders.Count + 1}: {text}");
            RepairNameInput.Clear();
            CounterLabel.Text = $"Liczba zleceń w toku: {_orders.Count}";
        }
    }

    private void OnRemoveOrderClicked(object? sender, RoutedEventArgs e)
    {
        if (OrdersList.SelectedItem is string selected)
        {
            _orders.Remove(selected);
            CounterLabel.Text = $"Liczba zleceń w toku: {_orders.Count}";
        }
    }
}