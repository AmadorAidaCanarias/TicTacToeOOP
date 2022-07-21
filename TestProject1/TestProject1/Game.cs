namespace TicTacToeOOP;

public class Game {
    private readonly Board board;
    private BoardSquareState lastTurnState;
    public Game(Board board) {
        this.board = board;
        lastTurnState = BoardSquareState.StateEmpty;
    }

    public void Start() => board.Start();

    public bool BoardIsEmpty => board.IsEmpty();

    public GameState Turn(Position position, BoardSquareState state) {
        var error = CheckMovementErrors(position, state);
        if (error != GameState.MovementOk) return error;

        lastTurnState = state;
        board.FillTile(position, state);
        return CheckState(state);
    }

    private GameState CheckMovementErrors(Position position, BoardSquareState state) {
        var isFirstMovementAvailable = board.IsEmpty() && state == BoardSquareState.StateO;
        if (isFirstMovementAvailable) return GameState.ErrorFirstMovementNotAvailable;

        var isLastMovementSame = state.Equals(lastTurnState);
        if (isLastMovementSame) return GameState.ErrorMovementEqualToPrior;

        var isCellBusy = board.IsBusy(position);
        if (isCellBusy) return GameState.ErrorTileBusy;
        
        return GameState.MovementOk;
    }

    private GameState CheckState(BoardSquareState state) {
        if (board.CheckWinState(state)) return GameState.ThreeInARowCongrats;
        if (board.CheckIsBoardBusy()) return GameState.Tie;
        return GameState.MovementOk;
    }
}