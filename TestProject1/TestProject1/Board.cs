namespace TicTacToeOOP;

public class Board
{
    private BoardSquareState[,] board;
    private int boardSizeX = 3;
    private int boardSizeY = 3;

    public Board() {
        board = new BoardSquareState[boardSizeX, boardSizeY];
    }

    public void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        for (int coordinateX = 0; coordinateX < boardSizeX; coordinateX++)
        {
            for (int coordinateY = 0; coordinateY < boardSizeY; coordinateY++)
            {
                board[coordinateX, coordinateY] = BoardSquareState.StateEmpty;
            }
        }
    }

    public bool IsEmpty()
    {
        return board.Cast<BoardSquareState>().All(state => state == BoardSquareState.StateEmpty);
    }
}