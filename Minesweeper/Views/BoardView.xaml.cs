namespace Minesweeper.Views;

public partial class BoardView : UserControl {
  public int BoardWidth { get; set; } = 10;

  public int BoardHeight { get; set; } = 10;

  public int BombCount { get; set; } = 20;

  public List<BoardTileView> Tiles { get; set; } = new();

  public BoardView() => InitializeComponent();

  private void BoardView_Loaded(object sender, RoutedEventArgs e) {
    List<string> bombs = Enumerable.Repeat(Constants.Bomb, BombCount).ToList();

    List<string> valid = Enumerable.Repeat(
      Constants.Valid, BoardWidth * BoardHeight - BombCount).ToList();

    List<string> tiles = bombs.Concat(valid).ToList();
    tiles.FisherYatesShuffle();

    AddRowDefinitions();
    AddColumnDefinitions();

    // Add tiles to board grid
    for (int row = 0; row < BoardWidth; row++) {
      var isLeftEdge = row == 0;
      var isRightEdge = row == BoardWidth - 1;

      for (int col = 0; col < BoardHeight; col++) {
        int index = row * (col + 1);

        BoardTileView boardTile = new() {
          Name = $"Tile{index}",
        };

        if (tiles[index].Equals(
          Constants.Bomb,
          StringComparison.InvariantCultureIgnoreCase)) {
          boardTile.testName.Background = Brushes.HotPink;
          boardTile.IsBomb = true;
        }

        Grid.SetRow(boardTile, row);
        Grid.SetColumn(boardTile, col);

        boardGrid.Children.Add(boardTile);
        Tiles.Add(boardTile);
        // Check for adjacent bomb count
      }
    }
  }

  private void AddRowDefinitions() {
    for (int i = 0; i < BoardWidth; i++) {
      boardGrid.RowDefinitions.Add(new RowDefinition());
    }
  }

  private void AddColumnDefinitions() {
    for (int i = 0; i < BoardHeight; i++) {
      boardGrid.ColumnDefinitions.Add(new ColumnDefinition());
    }
  }

  private bool IsBomb(string tile) =>
    tile.Equals(Constants.Bomb, StringComparison.InvariantCultureIgnoreCase);
}
