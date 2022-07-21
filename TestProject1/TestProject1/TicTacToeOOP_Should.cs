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
        public void board_is_empty_when_start_the_game() {
            game.Start();
            Assert.IsTrue(game.BoardIsEmpty);
        }

        [Test]
        public void player_with_x_allways_is_first() {
            game.Start();
            Position firstPosition = Position.CreatePosition(1, 0);
            GameState stateTurn = game.Turn(firstPosition, BoardSquareState.StateO);
            Assert.That(stateTurn, Is.EqualTo(GameState.ErrorFirstMovementNotAvailable));
        }

        [Test]
        public void can_not_do_the_same_move_twice() {
            game.Start();
            Position firstPosition = Position.CreatePosition(1, 0);
            Position secondPosition = Position.CreatePosition(1, 1);
            GameState firstStateTurn = game.Turn(firstPosition, BoardSquareState.StateX);
            GameState secondStateTurn = game.Turn(secondPosition, BoardSquareState.StateX);
            Assert.That(firstStateTurn, Is.EqualTo(GameState.MovementOk));
            Assert.That(secondStateTurn, Is.EqualTo(GameState.ErrorMovementEqualToPrior));
        }

        [Test]
        public void can_not_do_the_same_position_twice() {
            game.Start();
            Position firstPosition = Position.CreatePosition(1, 0);
            GameState firstStateTurn = game.Turn(firstPosition, BoardSquareState.StateX);
            GameState secondStateTurn = game.Turn(firstPosition, BoardSquareState.StateO);
            Assert.That(firstStateTurn, Is.EqualTo(GameState.MovementOk));
            Assert.That(secondStateTurn, Is.EqualTo(GameState.ErrorTileBusy));
        }

        [Test]
        public void player_with_thre_on_row_horizontal_win() {
            game.Start();
            Position firstPositionX = Position.CreatePosition(1, 0);
            Position secondPositionX = Position.CreatePosition(1, 1);
            Position thirdPositionX = Position.CreatePosition(1, 2);

            Position firstPositionO = Position.CreatePosition(2, 0);
            Position secondPositionO = Position.CreatePosition(2, 1);
            Position.CreatePosition(2, 2);
            game.Turn(firstPositionX, BoardSquareState.StateX);
            game.Turn(firstPositionO, BoardSquareState.StateO);

            game.Turn(secondPositionX, BoardSquareState.StateX);
            game.Turn(secondPositionO, BoardSquareState.StateO);

            GameState thirdStateTurnX = game.Turn(thirdPositionX, BoardSquareState.StateX);

            Assert.That(thirdStateTurnX, Is.EqualTo(GameState.ThreeInARowCongrats));
        }

        [Test]
        public void player_with_thre_on_row_vertical_win() {
            game.Start();
            Position firstPositionX = Position.CreatePosition(0, 0);
            Position secondPositionX = Position.CreatePosition(1, 0);
            Position thirdPositionX = Position.CreatePosition(2, 0);

            Position firstPositionO = Position.CreatePosition(0, 1);
            Position secondPositionO = Position.CreatePosition(1, 1);
            Position.CreatePosition(2, 1);
            game.Turn(firstPositionX, BoardSquareState.StateX);
            game.Turn(firstPositionO, BoardSquareState.StateO);

            game.Turn(secondPositionX, BoardSquareState.StateX);
            game.Turn(secondPositionO, BoardSquareState.StateO);

            GameState thirdStateTurnX = game.Turn(thirdPositionX, BoardSquareState.StateX);

            Assert.That(thirdStateTurnX, Is.EqualTo(GameState.ThreeInARowCongrats));
        }

        [Test]
        public void player_with_thre_on_row_left_diagonal_win() {
            game.Start();
            Position firstPositionX = Position.CreatePosition(0, 0);
            Position secondPositionX = Position.CreatePosition(1, 1);
            Position thirdPositionX = Position.CreatePosition(2, 2);

            Position firstPositionO = Position.CreatePosition(0, 1);
            Position secondPositionO = Position.CreatePosition(0, 2);
            Position.CreatePosition(2, 1);
            game.Turn(firstPositionX, BoardSquareState.StateX);
            game.Turn(firstPositionO, BoardSquareState.StateO);

            game.Turn(secondPositionX, BoardSquareState.StateX);
            game.Turn(secondPositionO, BoardSquareState.StateO);

            GameState thirdStateTurnX = game.Turn(thirdPositionX, BoardSquareState.StateX);

            Assert.That(thirdStateTurnX, Is.EqualTo(GameState.ThreeInARowCongrats));
        }

        [Test]
        public void player_with_thre_on_row_right_diagonal_win() {
            game.Start();
            Position firstPositionX = Position.CreatePosition(0, 2);
            Position secondPositionX = Position.CreatePosition(1, 1);
            Position thirdPositionX = Position.CreatePosition(2, 0);

            Position firstPositionO = Position.CreatePosition(0, 0);
            Position secondPositionO = Position.CreatePosition(0, 1);
            Position.CreatePosition(2, 1);
            game.Turn(firstPositionX, BoardSquareState.StateX);
            game.Turn(firstPositionO, BoardSquareState.StateO);

            game.Turn(secondPositionX, BoardSquareState.StateX);
            game.Turn(secondPositionO, BoardSquareState.StateO);

            GameState thirdStateTurnX = game.Turn(thirdPositionX, BoardSquareState.StateX);

            Assert.That(thirdStateTurnX, Is.EqualTo(GameState.ThreeInARowCongrats));
        }

        [Test]
        public void game_finish_tie() {
            game.Start();
            Position firstPositionX = Position.CreatePosition(0, 0);
            Position secondPositionX = Position.CreatePosition(1, 0);
            Position thirdPositionX = Position.CreatePosition(1, 2);
            Position fourthPositionX = Position.CreatePosition(2, 2);
            Position fifthPositionX = Position.CreatePosition(2, 1);

            Position firstPositionO = Position.CreatePosition(0, 1);
            Position secondPositionO = Position.CreatePosition(0, 2);
            Position thirdPositionO = Position.CreatePosition(1, 1);
            Position fourthPositionO = Position.CreatePosition(2, 0);
            game.Turn(firstPositionX, BoardSquareState.StateX);
            game.Turn(firstPositionO, BoardSquareState.StateO);

            game.Turn(secondPositionX, BoardSquareState.StateX);
            game.Turn(secondPositionO, BoardSquareState.StateO);

            game.Turn(thirdPositionX, BoardSquareState.StateX);
            game.Turn(thirdPositionO, BoardSquareState.StateO);

            game.Turn(fourthPositionX, BoardSquareState.StateX);
            game.Turn(fourthPositionO, BoardSquareState.StateO);

            GameState fifthStateTurnX = game.Turn(fifthPositionX, BoardSquareState.StateX);

            Assert.That(fifthStateTurnX, Is.EqualTo(GameState.Tie));
        }
    }
}