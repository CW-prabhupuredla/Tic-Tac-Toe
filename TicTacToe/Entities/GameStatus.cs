using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Entities
{
    public class GameStatus
    {
        public int[,] Board;
        public bool IsCompleted;
        public int winner;
        public int BoardSize;
        public int Person1;
        public int Person2;
        public int MoveCount;
        public bool IsDraw;
        public int PlayerTurn;
        public IDictionary<int, List<Coordinate>> PlayerMoves;
    }

    public class Coordinate
    {
        public int X;
        public int Y;
        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
 }