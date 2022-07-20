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

        [Test]
        public void can_not_do_the_same_move_twice()
        {
            game.Start();
            Position firstPosition = Position.CreatePosition(1, 0);
            Position secondPosition = Position.CreatePosition(1, 1);
            TileMovementState firstStateTurn = game.Turn(firstPosition, BoardSquareState.StateX);
            TileMovementState secondStateTurn = game.Turn(secondPosition, BoardSquareState.StateX);
            Assert.That(firstStateTurn, Is.EqualTo(TileMovementState.MovementOk));
            Assert.That(secondStateTurn, Is.EqualTo(TileMovementState.ErrorMovementEqualToPrior));
        }

        [Test]
        public void can_not_do_the_same_position_twice()
        {
            game.Start();
            Position firstPosition = Position.CreatePosition(1, 0);
            TileMovementState firstStateTurn = game.Turn(firstPosition, BoardSquareState.StateX);
            TileMovementState secondStateTurn = game.Turn(firstPosition, BoardSquareState.StateO);
            Assert.That(firstStateTurn, Is.EqualTo(TileMovementState.MovementOk));
            Assert.That(secondStateTurn, Is.EqualTo(TileMovementState.ErrorTileBusy));
        }
    }
}