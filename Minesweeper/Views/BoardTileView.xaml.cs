namespace Minesweeper.Views;

public partial class BoardTileView : UserControl {
  public bool IsBomb { get; set; } = false;
  
  public int AdjacentBombs { get; set; } = 0;

  public BoardTileView() => InitializeComponent();
}
