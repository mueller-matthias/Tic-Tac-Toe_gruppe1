using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToeApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeApp.Tests
{
    [TestClass]
    public class SpielTimerTests
    {
        [TestMethod]
        public void Constructor_InitializesStopwatch()
        {
            // Arrange & Act
            SpielTimer timer = new SpielTimer();

            // Assert
            Assert.AreEqual("00:00", timer.Erhalten());
        }

        [TestMethod]
        public void Starten_StartsTimer()
        {
            // Arrange
            SpielTimer timer = new SpielTimer();

            // Act
            timer.Starten();
            Thread.Sleep(1000); 
            timer.Stoppen();

            // Assert
            string elapsedTime = timer.Erhalten();
            Assert.IsTrue(elapsedTime != "00:00");
        }

        [TestMethod]
        public void Stoppen_StopsTimer()
        {
            // Arrange
            SpielTimer timer = new SpielTimer();

            // Act
            timer.Starten();
            Thread.Sleep(1000); 
            timer.Stoppen();
            string firstTime = timer.Erhalten();

            Thread.Sleep(1000); 
            string secondTime = timer.Erhalten();

            // Assert
            Assert.AreEqual(firstTime, secondTime);
        }

        [TestMethod]
        public void Erhalten_ReturnsFormattedTime()
        {
            // Arrange
            SpielTimer timer = new SpielTimer();

            // Act
            timer.Starten();
            Thread.Sleep(1500); 
            timer.Stoppen();
            string elapsedTime = timer.Erhalten();

            // Assert
            Assert.IsTrue(System.Text.RegularExpressions.Regex.IsMatch(elapsedTime, @"^\d{2}:\d{2}$"));
        }

        [TestMethod]
        public void Zuruecksetzen_ResetsTimer()
        {
            // Arrange
            SpielTimer timer = new SpielTimer();

            // Act
            timer.Starten();
            Thread.Sleep(1000); 
            timer.Stoppen();
            string firstTime = timer.Erhalten();

            timer.Zuruecksetzen();
            timer.Starten();
            Thread.Sleep(500); 
            timer.Stoppen();
            string secondTime = timer.Erhalten();

            // Assert
            Assert.AreNotEqual(firstTime, secondTime);
        }

        [TestMethod]
        public void MultipleStartAndStop_WorksCorrectly()
        {
            // Arrange
            SpielTimer timer = new SpielTimer();

            // Act
            timer.Starten();
            Thread.Sleep(500);
            timer.Stoppen();

            timer.Starten();
            Thread.Sleep(500);
            timer.Stoppen();

            // Assert
            string elapsedTime = timer.Erhalten();
            Assert.IsTrue(System.Text.RegularExpressions.Regex.IsMatch(elapsedTime, @"^\d{2}:\d{2}$"));
        }
    }
}