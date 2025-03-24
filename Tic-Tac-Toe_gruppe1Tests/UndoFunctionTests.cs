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
    public class UndoFunctionTests
    {
        [TestMethod]
        public void SpeichereZug_AddsZugToHistory()
        {
            // Arrange
            UndoFunction undoFunction = new UndoFunction();
            Spieler testSpieler = new Spieler("TestPlayer", 'X');
            Zug testZug = new Zug(testSpieler, 1, 2);

            // Act
            undoFunction.SpeichereZug(testZug);
            Zug ladeLetztenZug = undoFunction.LadeLetztenZug();

            // Assert
            Assert.AreEqual(testZug, ladeLetztenZug);
        }

        [TestMethod]
        public void LadeLetztenZug_ReturnsNullWhenNoZugeExist()
        {
            // Arrange
            UndoFunction undoFunction = new UndoFunction();

            // Act
            Zug result = undoFunction.LadeLetztenZug();

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void LadeLetztenZug_RemovesZugFromHistory()
        {
            // Arrange
            UndoFunction undoFunction = new UndoFunction();
            Spieler testSpieler = new Spieler("TestPlayer", 'X');
            Zug firstZug = new Zug(testSpieler, 1, 2);
            Zug secondZug = new Zug(testSpieler, 3, 4);

            // Act
            undoFunction.SpeichereZug(firstZug);
            undoFunction.SpeichereZug(secondZug);

            Zug firstLoadedZug = undoFunction.LadeLetztenZug();
            Zug secondLoadedZug = undoFunction.LadeLetztenZug();
            Zug thirdLoadedZug = undoFunction.LadeLetztenZug();

            // Assert
            Assert.AreEqual(secondZug, firstLoadedZug);
            Assert.AreEqual(firstZug, secondLoadedZug);
            Assert.IsNull(thirdLoadedZug);
        }

        [TestMethod]
        public void MultipleZuege_LoadedInReverseOrder()
        {
            // Arrange
            UndoFunction undoFunction = new UndoFunction();
            Spieler testSpieler = new Spieler("TestPlayer", 'X');
            Zug firstZug = new Zug(testSpieler, 1, 2);
            Zug secondZug = new Zug(testSpieler, 3, 4);
            Zug thirdZug = new Zug(testSpieler, 5, 6);

            // Act
            undoFunction.SpeichereZug(firstZug);
            undoFunction.SpeichereZug(secondZug);
            undoFunction.SpeichereZug(thirdZug);

            // Assert
            Assert.AreEqual(thirdZug, undoFunction.LadeLetztenZug());
            Assert.AreEqual(secondZug, undoFunction.LadeLetztenZug());
            Assert.AreEqual(firstZug, undoFunction.LadeLetztenZug());
        }
    }
}