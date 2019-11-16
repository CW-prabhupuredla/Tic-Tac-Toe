using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Logic;
using Xunit;

namespace TicTacToeTest.LogicTests
{
    public class TicTacToeLogicTests
    {
     
        public void StartGameTest()
        {
            TicTacToeLogic ticTacToeLogic = new TicTacToeLogic();
            var output = ticTacToeLogic.StartGame(1, 2, 3);
            Assert.True(output.Message == "Game is started, GameId : " + output.Guid);
        }
        [Fact]
        public void CaptureMoveTest()
        {
            TicTacToeLogic ticTacToeLogic = new TicTacToeLogic();
            Assert.True(ticTacToeLogic.CaptureMove(Guid.NewGuid(),1,0,0).Message == "Invalid GameId");
            var output1 = ticTacToeLogic.StartGame(1, 2, 3);
            Assert.True(output1.Message == "Game is started, GameId : " + output1.Guid);

            Assert.True(ticTacToeLogic.CaptureMove(output1.Guid, 2, 0, 0).Message == "Recorded move succesfully");
            Assert.True(ticTacToeLogic.CaptureMove(output1.Guid, 1, 0, 1).Message == "Recorded move succesfully");
            Assert.True(ticTacToeLogic.CaptureMove(output1.Guid, 2, 0, 2).Message == "Recorded move succesfully");

            Assert.True(ticTacToeLogic.CaptureMove(output1.Guid, 1, 1, 1).Message == "Recorded move succesfully");
            Assert.True(ticTacToeLogic.CaptureMove(output1.Guid, 2, 1, 2).Message == "Recorded move succesfully");
            Assert.True(ticTacToeLogic.CaptureMove(output1.Guid, 1, 2, 0).Message == "Recorded move succesfully");

            Assert.True(ticTacToeLogic.CaptureMove(output1.Guid, 2, 2, 1).Message == "Recorded move succesfully");
            Assert.True(ticTacToeLogic.CaptureMove(output1.Guid, 1, 2, 2).Message == "Recorded move succesfully");
            Assert.True(ticTacToeLogic.CaptureMove(output1.Guid, 2, 1, 0).Message == "Match is drawed");
        }
    }
    public class TicTacToeLogicTests2
    {
        [Fact]
        public void CaptureMoveTest()
        {
            TicTacToeLogic ticTacToeLogic = new TicTacToeLogic();

            var output2 = ticTacToeLogic.StartGame(3, 4, 3);
            Assert.True(output2.Message == "Game is started, GameId : " + output2.Guid);
            Assert.True(ticTacToeLogic.CaptureMove(output2.Guid, 4, 0, 0).Message == "Recorded move succesfully");
            Assert.True(ticTacToeLogic.CaptureMove(output2.Guid, 3, 1, 2).Message == "Recorded move succesfully");
            Assert.True(ticTacToeLogic.CaptureMove(output2.Guid, 4, 0, 2).Message == "Recorded move succesfully");
            Assert.True(ticTacToeLogic.CaptureMove(output2.Guid, 3, 1, 1).Message == "Recorded move succesfully");
            Assert.True(ticTacToeLogic.CaptureMove(output2.Guid, 4, 0, 1).Message == "You win");
        }
    }
    public class TicTacToeLogicTests3
    {
        [Fact]
        public void CaptureMoveTest()
        {
            TicTacToeLogic ticTacToeLogic = new TicTacToeLogic();

            var output2 = ticTacToeLogic.StartGame(5, 6, 3);
            Assert.True(output2.Message == "Game is started, GameId : " + output2.Guid);
            Assert.True(ticTacToeLogic.CaptureMove(output2.Guid, 6, 0, 0).Message == "Recorded move succesfully");
            Assert.True(ticTacToeLogic.CaptureMove(output2.Guid, 5, 1, 2).Message == "Recorded move succesfully");
            Assert.True(ticTacToeLogic.CaptureMove(output2.Guid, 6, 0, 2).Message == "Recorded move succesfully");
            Assert.True(ticTacToeLogic.CaptureMove(output2.Guid, 5, 1, 1).Message == "Recorded move succesfully");
            Assert.True(ticTacToeLogic.CaptureMove(output2.Guid, 6, 0, 1).Message == "You win");
        }
    }
    public class TicTacToeLogicTests4
    {
        [Fact]
        public void CaptureMoveTest()
        {
            TicTacToeLogic ticTacToeLogic = new TicTacToeLogic();

            var output2 = ticTacToeLogic.StartGame(7, 8, 3);
            Assert.True(output2.Message == "Game is started, GameId : " + output2.Guid);
            Assert.True(ticTacToeLogic.CaptureMove(output2.Guid, 8, 0, 0).Message == "Recorded move succesfully");
            Assert.True(ticTacToeLogic.CaptureMove(output2.Guid, 7, 1, 2).Message == "Recorded move succesfully");
            Assert.True(ticTacToeLogic.CaptureMove(output2.Guid, 8, 0, 2).Message == "Recorded move succesfully");
            Assert.True(ticTacToeLogic.CaptureMove(output2.Guid, 7, 1, 1).Message == "Recorded move succesfully");
            Assert.True(ticTacToeLogic.CaptureMove(output2.Guid, 8, 0, 1).Message == "You win");
        }
    }
    public class TicTacToeLogicTests5
    {
        [Fact]
        public void CaptureMoveTest()
        {
            TicTacToeLogic ticTacToeLogic = new TicTacToeLogic();

            var output2 = ticTacToeLogic.StartGame(9, 10, 3);
            Assert.True(output2.Message == "Game is started, GameId : " + output2.Guid);
            Assert.True(ticTacToeLogic.CaptureMove(output2.Guid, 10, 0, 0).Message == "Recorded move succesfully");
            Assert.True(ticTacToeLogic.CaptureMove(output2.Guid, 9, 1, 2).Message == "Recorded move succesfully");
            Assert.True(ticTacToeLogic.CaptureMove(output2.Guid, 10, 0, 2).Message == "Recorded move succesfully");
            Assert.True(ticTacToeLogic.CaptureMove(output2.Guid, 9, 1, 1).Message == "Recorded move succesfully");
            Assert.True(ticTacToeLogic.CaptureMove(output2.Guid, 10, 0, 1).Message == "You win");
        }
    }
}
