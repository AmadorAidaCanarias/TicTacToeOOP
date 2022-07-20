namespace TicTacToeOOP;

public enum TileMovementState {
    WithOutState,
    ErrorFirstMovementNotAvailable,
    ErrorMovementEqualToPrior,
    ErrorTileBusy,
    MovementOk,
    ThreeInARowCongrats,
    Tie
}