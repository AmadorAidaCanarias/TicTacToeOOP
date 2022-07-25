namespace TicTacToeOOP;

public class Board {
    private BoardSquareState[,] board;
    private readonly int sideOfTheSquare = 3;

    public Board() {
        board = new BoardSquareState[sideOfTheSquare, sideOfTheSquare];
    }

    public void Start() {
        Initialize();
    }

    private void Initialize() {
        for (int coordinateX = 0; coordinateX < sideOfTheSquare; coordinateX++) {
            for (int coordinateY = 0; coordinateY < sideOfTheSquare; coordinateY++) {
                board[coordinateX, coordinateY] = BoardSquareState.StateEmpty;
            }
        }
    }

    public void FillTile(Position position, BoardSquareState state) => board[position.x, position.y] = state;

    public bool IsEmpty() => board.Cast<BoardSquareState>().All(state => state == BoardSquareState.StateEmpty);


    public bool CheckIsBoardBusy() => board.Cast<BoardSquareState>().All(state => state != BoardSquareState.StateEmpty);

    public bool IsBusy(Position position) => board[position.x, position.y] != BoardSquareState.StateEmpty;

    public bool CheckWinState(BoardSquareState state) => CheckStateHorizontal(state) || CheckStateVertical(state) || CheckStateDiagonal(state);

    private bool CheckStateDiagonal(BoardSquareState state) {
        var isLeftToRightDiagonal = CheckLeftToRightDiagonal(state);
        var isRightToLeftDiagonal = CheckRigthToLeftDiagonal(state);
        return isLeftToRightDiagonal || isRightToLeftDiagonal;
    }

    private bool CheckRigthToLeftDiagonal(BoardSquareState state)
    {
        int row = 0;
        int column = sideOfTheSquare - 1;
        var states = new List<BoardSquareState>();
        states.Clear();
        while (column >= 0 && row < sideOfTheSquare)
        {
            states.Add(board[row, column]);
            row++;
            column--;
        }

        return states.All(row => row.Equals(state));
    }

    private bool CheckLeftToRightDiagonal(BoardSquareState state) {
        var states = new List<BoardSquareState>();
        int column = 0;
        int row = 0;
        states.Clear();
        while (column < sideOfTheSquare && row < sideOfTheSquare) {
            states.Add(board[row, column]);
            row++;
            column++;
        }

        return states.All(row => row.Equals(state));
    }

    private bool CheckStateVertical(BoardSquareState state) {
        bool isStateInVertical = false;
        int column = 0;
        var states = new List<BoardSquareState>();
        while (column < sideOfTheSquare && !isStateInVertical) {
            states.Clear();
            for (int row = 0; row < sideOfTheSquare; row++) {
                states.Add(board[row, column]);
            }
            isStateInVertical = states.All(row => row.Equals(state));
            column++;
        }

        return isStateInVertical;
    }

    private bool CheckStateHorizontal(BoardSquareState state) {
        var isStateInHorizontal = false;
        var states = board.Cast<BoardSquareState>().ToList();
        var row = 0;
        while (row < sideOfTheSquare && !isStateInHorizontal) {
            isStateInHorizontal = states
                .GetRange(row * sideOfTheSquare, sideOfTheSquare)
                .All(row => row.Equals(state));
            row++;
        }

        return isStateInHorizontal;
    }

}