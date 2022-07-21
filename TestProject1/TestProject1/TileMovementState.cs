namespace TicTacToeOOP;

public enum TileMovementState {
    ErrorFirstMovementNotAvailable,
    ErrorMovementEqualToPrior,
    ErrorTileBusy,
    MovementOk,
    ThreeInARowCongrats,
    Tie
}