namespace TicTacToeOOP;

public class Board {
    private BoardSquareState[,] board;
    private int boardSizeX = 3;
    private int boardSizeY = 3;

    public Board() {
        board = new BoardSquareState[boardSizeX, boardSizeY];
    }

    public void Start() {
        Initialize();
    }

    private void Initialize() {
        for (int coordinateX = 0; coordinateX < boardSizeX; coordinateX++) {
            for (int coordinateY = 0; coordinateY < boardSizeY; coordinateY++) {
                board[coordinateX, coordinateY] = BoardSquareState.StateEmpty;
            }
        }
    }

    public void FillTile(Position position, BoardSquareState state) {
        board[position.x, position.y] = state;
    }

    public bool IsEmpty() {
        return board.Cast<BoardSquareState>().All(state => state == BoardSquareState.StateEmpty);
    }


    public bool CheckIsBoardBusy() {
        return board.Cast<BoardSquareState>().All(state => state != BoardSquareState.StateEmpty);
    }

    public bool IsBusy(Position position) => board[position.x, position.y] != BoardSquareState.StateEmpty;

    public bool CheckWinState(BoardSquareState state) {
        return CheckStateHorizontal(state) || CheckStateVertical(state) || CheckStateDiagonal(state);
    }

    private bool CheckStateDiagonal(BoardSquareState state) {
        int row = 0;
        int column = 0;
        bool isStateInLeftDiagonal = true;
        bool isStateInRightDiagonal = true;
        while (column < boardSizeY && row < boardSizeX && isStateInLeftDiagonal) {
            isStateInLeftDiagonal = board[row, column] == state;
            row++;
            column++;
        }
        row = 0;
        column = boardSizeY - 1;
        while (column >= 0 && row < boardSizeX && isStateInRightDiagonal) {
            isStateInRightDiagonal = board[row, column] == state;
            row++;
            column--;
        }
        return isStateInLeftDiagonal || isStateInRightDiagonal;
    }

    private bool CheckStateVertical(BoardSquareState state) {
        int row;
        bool isStateInVertical = true;
        int column = 0;
        while (column < boardSizeY) {
            if (isStateInVertical == false && column < boardSizeY) {
                isStateInVertical = true;
            }

            row = 0;
            while (row < boardSizeX && isStateInVertical) {
                isStateInVertical = board[row, column] == state;
                row++;
            }
            column++;
            if (isStateInVertical) break;
        }
        return isStateInVertical;
    }

    private bool CheckStateHorizontal(BoardSquareState state) {
        int row = 0;
        bool isStateInHorizontal = true;
        int column;
        while (row < boardSizeX) {
            if (isStateInHorizontal == false && row < boardSizeX) {
                isStateInHorizontal = true;
            }

            column = 0;
            while (column < boardSizeY && isStateInHorizontal) {
                isStateInHorizontal = board[row, column] == state;
                column++;
            }
            row++;
            if (isStateInHorizontal) break;
        }
        return isStateInHorizontal;
    }

}