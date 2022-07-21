namespace TicTacToeOOP;

public enum GameState {
    ErrorFirstMovementNotAvailable,
    ErrorMovementEqualToPrior,
    ErrorTileBusy,
    MovementOk,
    ThreeInARowCongrats,
    Tie
}