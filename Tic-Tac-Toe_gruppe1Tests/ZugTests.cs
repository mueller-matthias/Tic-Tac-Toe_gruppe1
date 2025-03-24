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
    public class ZugTests
    {
        [TestMethod]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            Spieler testSpieler = new Spieler("TestPlayer", 'X');
            int testRow = 1;
            int testCol = 2;

            // Act
            Zug zug = new Zug(testSpieler, testRow, testCol);

            // Assert
            Assert.AreEqual(testSpieler, zug.Spieler);
            Assert.AreEqual(testRow, zug.Row);
            Assert.AreEqual(testCol, zug.Col);
        }

        [TestMethod]
        public void Constructor_SetsZeitstempelToCurrentTime()
        {
            // Arrange
            Spieler testSpieler = new Spieler("TestPlayer", 'X');
            DateTime beforeCreation = DateTime.Now;

            // Act
            Zug zug = new Zug(testSpieler, 1, 2);
            DateTime afterCreation = DateTime.Now;

            // Assert
            Assert.IsTrue(zug.Zeitstempel >= beforeCreation);
            Assert.IsTrue(zug.Zeitstempel <= afterCreation);
        }

        [TestMethod]
        public void Constructor_AllowsZeroBasedIndices()
        {
            // Arrange
            Spieler testSpieler = new Spieler("TestPlayer", 'X');

            // Act
            Zug zug = new Zug(testSpieler, 0, 0);

            // Assert
            Assert.AreEqual(0, zug.Row);
            Assert.AreEqual(0, zug.Col);
        }

        [TestMethod]
        public void Constructor_AllowsNegativeIndices()
        {
            // Arrange
            Spieler testSpieler = new Spieler("TestPlayer", 'X');

            // Act
            Zug zug = new Zug(testSpieler, -1, -2);

            // Assert
            Assert.AreEqual(-1, zug.Row);
            Assert.AreEqual(-2, zug.Col);
        }

        [TestMethod]
        public void Constructor_SetsPlayerSymbolCorrectly()
        {
            // Arrange
            Spieler testSpieler = new Spieler("TestPlayer", 'O');

            // Act
            Zug zug = new Zug(testSpieler, 1, 2);

            // Assert
            Assert.AreEqual('O', zug.Spieler.Symbol);
        }
    }
}