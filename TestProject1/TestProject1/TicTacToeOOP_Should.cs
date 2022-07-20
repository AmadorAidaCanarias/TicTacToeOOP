namespace TicTacToeOOP {
    public class Tests {

        private Board board;
        private Game game;

        [SetUp]
        public void Setup() {
            board = new Board();
            game = new Game(board);
        }

        [Test]
        public void board_is_empty_when_start_the_game()
        {
            game.Start();
            Assert.IsTrue( game.BoardIsEmpty );
        }

        [Test]
        public void player_with_x_allways_is_first()
        {
            game.Start();
            Position firstPosition = Position.CreatePosition(1, 0);
            TileMovementState stateTurn = game.Turn(firstPosition, BoardSquareState.StateO);
            Assert.That(stateTurn, Is.EqualTo(TileMovementState.ErrorFirstMovementNotAvailable));
        }
    }
}