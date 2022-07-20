namespace TicTacToeOOP {
    public class Tests {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void board_is_empty_when_start_the_game()
        {
            Board board = new Board();
            board.Start();
            Assert.IsTrue( board.IsEmpty() );
        }
    }

    public class Board
    {
        public void Start()
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty()
        {
            throw new NotImplementedException();
        }
    }
}