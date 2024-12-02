using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace G24W1401WPFMenu;

public partial class MainWindow : Window
{
    private readonly List<MenuItem> _menuItems;

    public MainWindow()
    {
        InitializeComponent();

        _menuItems = new List<MenuItem> { ItemRed, ItemGreen, ItemBlue, ItemWhite };

        SetColor(Brushes.White, ItemWhite);

        CommandBinding bind = new CommandBinding(ApplicationCommands.Open);

        bind.Executed += OpenDocument;

        CommandBindings.Add(bind);
    }

    private void OpenDocument(object sender,ExecutedRoutedEventArgs e)
    {
        var dialog = new Microsoft.Win32.OpenFileDialog();
        dialog.FileName = "Document"; // Default file name
        dialog.DefaultExt = ".jpg"; // Default file extension
        dialog.Filter = "Images (.jpg)|*.jpg"; // Filter files by extension

        bool? result = dialog.ShowDialog();

        if (result != true) return;

        string filename = dialog.FileName;
        MessageBox.Show(filename);

        
    }

    private void SetColor(Brush color, MenuItem activeItem)
    {
        BackPanel.Background = color;

        foreach (var item in _menuItems)
        {
            item.IsChecked = false;
            item.IsEnabled = true;
        }

        activeItem.IsChecked = true;
        activeItem.IsEnabled = false;
    }

    private void SetRed(object sender, RoutedEventArgs e)
    {
        SetColor(Brushes.Red, ItemRed);
    }

    private void SetGreen(object sender, RoutedEventArgs e)
    {
        SetColor(Brushes.Green, ItemGreen);
    }

    private void SetBlue(object sender, RoutedEventArgs e)
    {
        SetColor(Brushes.Blue, ItemBlue);
    }

    private void SetWhite(object sender, RoutedEventArgs e)
    {
        SetColor(Brushes.White, ItemWhite);
    }
}
