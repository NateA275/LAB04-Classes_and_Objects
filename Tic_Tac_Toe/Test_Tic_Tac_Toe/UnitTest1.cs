using System;
using Xunit;
using Tic_Tac_Toe;
using Tic_Tac_Toe.Classes;


namespace Test_Tic_Tac_Toe
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("1", "2", "3")]
        [InlineData("4", "5", "6")]
        [InlineData("2", "5", "8")]
        [InlineData("1", "5", "9")]
        public void CanDetectAWin(string pos1, string pos2, string pos3)
        {
            //Arrange
            Player player1 = new Player('x', true);
            player1.moves.Append(pos1);
            player1.moves.Append(pos2);
            player1.moves.Append(pos3);

            //Act
            bool isWin = player1.CheckForWin();

            //Assert
            Assert.True(isWin);
        }


        [Fact]
        public void ProgramCanSwitchPlayers()
        {
            //Arrange
            Program.player1 = new Player('X', true);
            Program.player2 = new Player('O', false);

            //Act
            Program.SwitchPlayer();
            Player currentPlayer = Program.GetPlayer();

            //Assert
            Assert.Equal(currentPlayer, Program.player2);
        }


        [Theory]
        [InlineData(9, 'A')]
        [InlineData(8, 'B')]
        [InlineData(7, 'C')]
        [InlineData(7, 'D')]
        [InlineData(1, 'Z')]
        public void PostionSelectionChangesCorrectIndexOfBoard(uint position, char marker)
        {
            //Arrange
            GameBoard myBoard = new GameBoard();

            //Act
            myBoard.PlaceMarker(position, marker);

            //Assert
            Assert.Equal(marker, myBoard.board[position - 1]);
        }
    }
}
