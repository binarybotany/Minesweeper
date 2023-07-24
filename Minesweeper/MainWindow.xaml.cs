using Minesweeper.Views;

namespace Minesweeper;

public partial class MainWindow : Window {
  public MainWindow() => InitializeComponent();

  // After content loaded

  // Create board

  // 1.) for index in width * width 

  // 2.) 

  private void MainWindow_KeyDown(object sender, KeyEventArgs e) {
    if (e.Key == Key.Escape) {
      Close();
    }
  }

  private void MainWindow_Loaded(object sender, RoutedEventArgs e) {
    const int width = 10;

    for (var index = 0; index < width * width; index++) {

    }
  }
}
