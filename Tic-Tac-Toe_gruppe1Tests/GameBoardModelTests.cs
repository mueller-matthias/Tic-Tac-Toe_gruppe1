using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tic_Tac_Toe_gruppe1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_gruppe1.Tests
{
    [TestClass()]
    public class GameBoardModelTests
    {
        [TestMethod()]
        public void GetCellTest()
        {
            //arrange
            GameBoardModel board = new GameBoardModel(3);
            //act
            char result = board.GetCell(1, 2);
            //assert
            Assert.AreEqual(' ', result);
        }
    }
}