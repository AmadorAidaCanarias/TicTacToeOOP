namespace TicTacToeOOP;

public class Position {
    public int x;
    public int y;

    private Position(int x, int y) {
        this.x = x;
        this.y = y;
    }

    public static Position CreatePosition(int x, int y)
    {
        return new Position(x, y);
    }
}