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
    public class SpielerTests
    {
        [TestMethod]
        public void Spieler_Name_ShouldBeCorrect()
        {
            // Arrange
            var spieler = new Spieler("Max", 'X');

            // Act
            string result = spieler.Name;

            // Assert
            Assert.AreEqual("Max", result);
        }

        [TestMethod]
        public void Spieler_Symbol_ShouldBeCorrect()
        {
            // Arrange
            var spieler = new Spieler("Max", 'X');

            // Act
            char result = spieler.Symbol;

            // Assert
            Assert.AreEqual('X', result);
        }

        [TestMethod]
        public void Spieler_UndoFunction_ShouldNotBeNull()
        {
            // Arrange
            var spieler = new Spieler("Max", 'X');

            // Act
            var undoFunction = spieler.Undo;

            // Assert
            Assert.IsNotNull(undoFunction);
        }
    }
}