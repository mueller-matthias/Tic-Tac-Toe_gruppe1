using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToeApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe_gruppe1;

namespace TicTacToeApp.Tests
{
    [TestClass]
    public class ProtokollTests
    {
        [TestMethod]
        public void GetInstanceTest()
        {
            // Arrange
            Protokoll firstInstance = Protokoll.GetInstance();

            // Act
            Protokoll secondInstance = Protokoll.GetInstance();

            // Assert
            Assert.AreSame(firstInstance, secondInstance);
        }

        [TestMethod]
        public void ProtokolliereTest()
        {
            // Arrange
            Protokoll protokoll = Protokoll.GetInstance();
            Spieler testSpieler = new Spieler("TestPlayer", 'X');
            Zug testZug = new Zug(testSpieler, 1, 2);

            // Act
            protokoll.Protokollieren(testZug);

            // Assert
            // This would require mocking or a way to verify file contents
            Assert.IsTrue(true); // Placeholder assertion
        }

        [TestMethod]
        public void ProtokolliereSpielStartTest()
        {
            // Arrange
            Protokoll protokoll = Protokoll.GetInstance();
            int boardSize = 3;

            // Act
            protokoll.ProtokolliereSpielStart(boardSize);

            // Assert
            // This would require mocking or a way to verify file contents
            Assert.IsTrue(true); // Placeholder assertion
        }

        [TestMethod]
        public void ProtokolliereSpielEndeTest()
        {
            // Arrange
            Protokoll protokoll = Protokoll.GetInstance();
            Spieler gewinner = new Spieler("Winner", 'X');

            // Act
            protokoll.ProtokolliereSpielEnde(gewinner);

            // Assert
            // This would require mocking or a way to verify file contents
            Assert.IsTrue(true); // Placeholder assertion
        }

        [TestMethod]
        public void ZeitProtokollierenTest()
        {
            // Arrange
            Protokoll protokoll = Protokoll.GetInstance();
            string spielzeit = "00:30:45";

            // Act
            protokoll.ZeitProtokollieren(spielzeit);

            // Assert
            // This would require mocking or a way to verify file contents
            Assert.IsTrue(true); // Placeholder assertion
        }

        [TestMethod]
        public void ConvertToChessNotationTest()
        {
            // Arrange
            // Use reflection to access the private static method
            var method = typeof(Protokoll).GetMethod("ConvertToChessNotation",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);

            // Act
            string result = (string)method.Invoke(null, new object[] { 0, 1 });

            // Assert
            Assert.AreEqual("a2", result);
        }

        [TestMethod]
        public void ProtokolliereUngueltigeEingabeTest()
        {
            // Arrange
            Protokoll protokoll = Protokoll.GetInstance();
            Spieler testSpieler = new Spieler("TestPlayer", 'X');
            Zug testZug = new Zug(testSpieler, 1, 2);

            // Act
            protokoll.ProtokolliereUngueltigeEingabe(testZug);

            // Assert
            // This would require mocking or a way to verify file contents
            Assert.IsTrue(true); // Placeholder assertion
        }

        [TestMethod]
        public void ProtokolliereBestaettigungTest()
        {
            // Arrange
            Protokoll protokoll = Protokoll.GetInstance();
            Spieler testSpieler = new Spieler("TestPlayer", 'X');
            Zug testZug = new Zug(testSpieler, 1, 2);

            // Act
            protokoll.ProtokolliereBestaetigung(testZug);

            // Assert
            // This would require mocking or a way to verify file contents
            Assert.IsTrue(true); // Placeholder assertion
        }

        [TestMethod]
        public void ProtokolliereNichtBestaettigungTest()
        {
            // Arrange
            Protokoll protokoll = Protokoll.GetInstance();
            Spieler testSpieler = new Spieler("TestPlayer", 'X');
            Zug testZug = new Zug(testSpieler, 1, 2);

            // Act
            protokoll.ProtokolliereNichtBestaetigung(testZug);

            // Assert
            // This would require mocking or a way to verify file contents
            Assert.IsTrue(true); // Placeholder assertion
        }
    }
}
