using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tic_Tac_Toe_gruppe1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_gruppe1.Tests
{
    [TestClass]
    public class GameControllerTests
    {
        [TestClass]
        public class GameBoardModelTests
        {
            [TestMethod]
            public void GetCellTest()
            {
                // Arrange
                GameBoardModel board = new GameBoardModel(3);

                // Act
                char result = board.GetCell(1, 2);

                // Assert
                Assert.AreEqual('.', result);
            }

            [TestMethod]
            public void SetCellTest()
            {
                // Arrange
                GameBoardModel board = new GameBoardModel(3);

                // Act
                board.SetCell(1, 2, 'X');
                char result = board.GetCell(1, 2);

                // Assert
                Assert.AreEqual('X', result);
            }

            [TestMethod]
            public void ValidateMoveTest_ValidMove()
            {
                // Arrange
                GameBoardModel board = new GameBoardModel(3);

                // Act
                bool isValid = board.ValidateMove(1, 2);

                // Assert
                Assert.IsTrue(isValid);
            }

            [TestMethod]
            public void ValidateMoveTest_InvalidMove()
            {
                // Arrange
                GameBoardModel board = new GameBoardModel(3);
                board.SetCell(1, 2, 'X');

                // Act
                bool isValid = board.ValidateMove(1, 2);

                // Assert
                Assert.IsFalse(isValid);
            }

            [TestMethod]
            public void PruefeGewinnerTest_WinningRow()
            {
                // Arrange
                GameBoardModel board = new GameBoardModel(3);
                board.SetCell(1, 0, 'X');
                board.SetCell(1, 1, 'X');
                board.SetCell(1, 2, 'X');

                // Act
                bool hasWon = board.PruefeGewinner('X', 3);

                // Assert
                Assert.IsTrue(hasWon);
            }

            [TestMethod]
            public void PruefeGewinnerTest_NoWin()
            {
                // Arrange
                GameBoardModel board = new GameBoardModel(3);
                board.SetCell(0, 0, 'X');
                board.SetCell(1, 1, 'O');
                board.SetCell(2, 2, 'X');

                // Act
                bool hasWon = board.PruefeGewinner('X', 3);

                // Assert
                Assert.IsFalse(hasWon);
            }

            [TestMethod]
            public void ValidateInputTest_ValidInput()
            {
                // Arrange
                GameBoardModel board = new GameBoardModel(3);
                int row, col;

                // Act
                bool isValid = board.ValidateInput("b2", out row, out col);

                // Assert
                Assert.IsTrue(isValid);
                Assert.AreEqual(1, row);
                Assert.AreEqual(1, col);
            }

            [TestMethod]
            public void ValidateInputTest_InvalidInput()
            {
                // Arrange
                GameBoardModel board = new GameBoardModel(3);
                int row, col;

                // Act
                bool isValid = board.ValidateInput("z9", out row, out col);

                // Assert
                Assert.IsFalse(isValid);
            }
        }
    }
}