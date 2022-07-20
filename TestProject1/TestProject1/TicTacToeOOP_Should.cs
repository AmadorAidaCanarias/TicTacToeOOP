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

        [Test]
        public void player_with_thre_on_row_horizontal_win()
        {
            game.Start();
            Position firstPositionX = Position.CreatePosition(1, 0);
            Position secondPositionX = Position.CreatePosition(1, 1);
            Position thirdPositionX = Position.CreatePosition(1, 2);

            Position firstPositionO = Position.CreatePosition(2, 0);
            Position secondPositionO = Position.CreatePosition(2, 1);
            Position thirdPositionO = Position.CreatePosition(2, 2);
            TileMovementState firstStateTurnX = game.Turn(firstPositionX, BoardSquareState.StateX);
            TileMovementState firstStateTurnO = game.Turn(firstPositionO, BoardSquareState.StateO);
            
            TileMovementState secondStateTurnX = game.Turn(secondPositionX, BoardSquareState.StateX);
            TileMovementState secondStateTurnO = game.Turn(secondPositionO, BoardSquareState.StateO);
            
            TileMovementState thirdStateTurnX = game.Turn(thirdPositionO, BoardSquareState.StateO);
            
            Assert.That(thirdStateTurnX, Is.EqualTo(TileMovementState.ThreeInARowCongrats));
        }
    }
}