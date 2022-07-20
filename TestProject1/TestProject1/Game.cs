namespace TicTacToeOOP;

public class Game
{
    private readonly Board board;
    public Game(Board board)
    {
        this.board = board;
    }

    public void Start() {
        board.Start();
    }

    public bool BoardIsEmpty => board.IsEmpty();

    public TileMovementState Turn(Position firstPosition, BoardSquareState state)
    {
        if (board.IsEmpty() && state == BoardSquareState.StateO)
        {
            return TileMovementState.ErrorFirstMovementNotAvailable;
        }

        return TileMovementState.WithOutState;
    }
}