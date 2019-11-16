using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Entities
{
    public class MoveOutput
    {
        public string Message;
        public List<Coordinate> Moves;
        public bool IsValid;
    }
}