namespace TicTacToeOOP;

public class Game
{
    private readonly Board board;
    private BoardSquareState lastTurnState;
    public Game(Board board)
    {
        this.board = board;
        lastTurnState = BoardSquareState.StateEmpty;
    }

    public void Start() {
        board.Start();
    }

    public bool BoardIsEmpty => board.IsEmpty();

    public TileMovementState Turn(Position position, BoardSquareState state)
    {
        if (board.IsEmpty() && state == BoardSquareState.StateO)
        {
            return TileMovementState.ErrorFirstMovementNotAvailable;
        }

        if (state.Equals(lastTurnState))
        {
            return TileMovementState.ErrorMovementEqualToPrior;
        }

        if (board.IsBusy(position))
        {
            return TileMovementState.ErrorTileBusy;
        }

        lastTurnState = state;
        board.FillTile(position, state);

        return CheckTileMovementState(state);
    }

    private TileMovementState CheckTileMovementState(BoardSquareState state)
    {
        if ( board.CheckWinState(state) ) return TileMovementState.ThreeInARowCongrats;
        if (board.CheckIsBoardBusy()) return TileMovementState.Tie;
        return TileMovementState.MovementOk;
    }
}