using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tic_Tac_Toe_gruppe1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Tic_Tac_Toe_gruppe1.Tests
{
    [TestClass]
    public class GameControllerTests
    {
        private GameController gameController;
        private StringWriter consoleOutput;
        private StringReader consoleInput;

        [TestInitialize]
        public void Setup()
        {
            consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
        }

        [TestCleanup]
        public void Cleanup()
        {
            Console.SetOut(Console.Out);
            consoleOutput.Dispose();
        }

        [TestMethod]
        public void InitialiseSpiel_SelectThreeByThreeBoard_ShouldSetupCorrectly()
        {
            // Arrange
            consoleInput = new StringReader("3\n");
            Console.SetIn(consoleInput);

            // Act
            gameController = new GameController();

            // Assert
            Assert.IsNotNull(gameController, "GameController should be initialized");
        }

        [TestMethod]
        public void InitialiseSpiel_SelectFiveByFiveBoard_ShouldSetupCorrectly()
        {
            // Arrange
            consoleInput = new StringReader("5\n");
            Console.SetIn(consoleInput);

            // Act
            gameController = new GameController();

            // Assert
            Assert.IsNotNull(gameController, "GameController should be initialized");
        }

        [TestMethod]
        public void InitialiseSpiel_SelectSevenBySevenBoard_ShouldSetupCorrectly()
        {
            // Arrange
            consoleInput = new StringReader("7\n");
            Console.SetIn(consoleInput);

            // Act
            gameController = new GameController();

            // Assert
            Assert.IsNotNull(gameController, "GameController should be initialized");
        }

        [TestMethod]
        public void IstUnentschieden_EmptyBoard_ShouldReturnFalse()
        {
            // Arrange
            consoleInput = new StringReader("3\n");
            Console.SetIn(consoleInput);
            gameController = new GameController();

            var method = typeof(GameController).GetMethod("IstUnentschieden",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            // Act
            bool result = (bool)method.Invoke(gameController, null);

            // Assert
            Assert.IsFalse(result, "Unentschieden should be false on an empty board");
        }

        [TestMethod]
        public void InitialiseSpiel_InvalidBoardSize_ShouldRepromptUntilValidInput()
        {
            // Arrange
            using (StringReader input = new StringReader("4\n0\n6\n3\n"))
            {
                Console.SetIn(input);

                using (StringWriter output = new StringWriter())
                {
                    Console.SetOut(output);

                    // Act
                    GameController gameController = new GameController();

                    // Assert
                    string consoleOutput = output.ToString();

                    Assert.IsTrue(consoleOutput.Contains("Ungültige Eingabe! Bitte geben Sie 3, 5 oder 7 ein."),
                        "Should prompt for valid input multiple times");

                    Assert.IsTrue(consoleOutput.Contains("Wählen Sie die Spielfeldgröße: 3x3, 5x5 oder 7x7:"),
                        "Should allow selection of board size");
                }
            }
        }
    }
} 