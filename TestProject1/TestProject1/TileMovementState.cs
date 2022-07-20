namespace TicTacToeOOP;

public enum TileMovementState {
    WithOutState,
    FirstMovementNotAvailable,
    MovementOk,
    ErrorTileBusy,
    ThreeInARowCongrats,
    Tie
}