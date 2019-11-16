using System;
using System.Web.Http;
using System.Web.Mvc;
using TicTacToe.Logic;

namespace TicTacToe.Controllers
{
    public class TicTacToeController : Controller
    {
        static TicTacToeLogic _ticTacToeLogic = new TicTacToeLogic();
        public string StartGame(int person1, int person2, int size)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(_ticTacToeLogic.StartGame(person1, person2, size));
        }
        public string CaptureMove(string gameId, int personId, int row,int col)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(_ticTacToeLogic.CaptureMove(Guid.Parse(gameId), personId, row, col));
        }
    }
}
