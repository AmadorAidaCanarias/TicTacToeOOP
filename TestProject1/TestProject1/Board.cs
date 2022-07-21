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

    public bool IsBusy(Position position) => board[position.x, position.y] != BoardSquareState.StateEmpty;

    public bool CheckWinState(BoardSquareState state) {
        return CheckStateHorizontal(state) || CheckStateVertical(state) || CheckStateDiagonal(state);
    }

    private bool CheckStateDiagonal(BoardSquareState state) {
        int row = 0;
        int column = 0;
        bool winLeftDiagonal = true;
        bool winRightDiagonal = true;
        while (column < boardSizeY && row < boardSizeX && winLeftDiagonal) {
            winLeftDiagonal = board[row, column] == state;
            row++;
            column++;
        }
        row = boardSizeX - 1;
        column = boardSizeY - 1;
        while (column >= 0 && row >= 0 && winRightDiagonal) {
            winRightDiagonal = board[row, column] == state;
            row--;
            column--;
        }
        return winLeftDiagonal || winRightDiagonal;
    }

    private bool CheckStateVertical(BoardSquareState state) {
        int row = 0;
        bool win = true;
        int column = 0;
        while (column < boardSizeY) {
            if (win == false && column < boardSizeY) {
                win = true;
            }
            while (row < boardSizeX && win) {
                win = board[row, column] == state;
                row++;
            }
            column++;
        }
        return win;
    }

    private bool CheckStateHorizontal(BoardSquareState state) {
        int row = 0;
        bool win = true;
        int column = 0;
        while (row < boardSizeX) {
            if (win == false && row < boardSizeX) {
                win = true;
            }

            while (column < boardSizeY && win) {
                win = board[row, column] == state;
                column++;
            }
            row++;
        }
        return win;
    }

    public bool CheckIsBoardBusy() {
        int row = 0;
        bool busy = true;
        int column = 0;
        while (row < boardSizeX && busy) {
            while (column < boardSizeY && busy) {
                busy = board[row, column] != BoardSquareState.StateEmpty;
                column++;
            }
            row++;
        }
        return busy;
    }
}