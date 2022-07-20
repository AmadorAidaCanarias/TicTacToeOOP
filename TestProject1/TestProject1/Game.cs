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

    public TileMovementState Turn(Position firstPosition, BoardSquareState stateO)
    {
        throw new NotImplementedException();
    }
}