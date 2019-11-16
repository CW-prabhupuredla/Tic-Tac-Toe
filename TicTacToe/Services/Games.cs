using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Entities;

namespace WebApplication3.Logic
{
    public class GamesService
    {
        private static ConcurrentDictionary<Guid, GameStatus> _games = new ConcurrentDictionary<Guid, GameStatus>();
        
        public GameStatus GetGame(Guid gameId)
        {
            GameStatus gameStatus;
            _games.TryGetValue(gameId, out gameStatus);
            return gameStatus;
        }
        public bool IsGameValid(int person1, int person2)
        {
            foreach (var game in _games)
            {
                if (!game.Value.IsCompleted && (game.Value.Person1 == person1 || game.Value.Person2 == person1 || game.Value.Person1 == person2 || game.Value.Person2 == person2))
                {
                    return false;
                }
            }
            return true;
        }
        public Guid AddGame(GameStatus gameStatus)
        {
            var guid = Guid.NewGuid();
            _games.TryAdd(guid, gameStatus);
            return guid;
        }
             
    }
}