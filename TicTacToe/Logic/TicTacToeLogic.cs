using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Entities;
using WebApplication3.Logic;

namespace TicTacToe.Logic
{
    public class TicTacToeLogic
    {
        GamesService gamesService = new GamesService();
        public CreationOutput StartGame(int person1, int person2, int size)
        {
            CreationOutput output = new CreationOutput();
            if(person1 > 0 && person2 >0 && person2 == person1 & size > 1)
            {
                output.Message = "Invalid Details";
                return output;
            }
            if(!gamesService.IsGameValid(person1, person2))
            {
                output.Message = "Player is already playing";
                return output;    
            }
            GameStatus gameStatus = new GameStatus()
            {
                Person1 = person1,
                Person2 = person2,
                BoardSize = size,
                Board = new int[size, size],
                PlayerTurn = person2,
                PlayerMoves = new Dictionary<int, List<Coordinate>>()
            };
            gameStatus.PlayerMoves.Add(person1, new List<Coordinate>());
            gameStatus.PlayerMoves.Add(person2, new List<Coordinate>());

            var guid = gamesService.AddGame(gameStatus);
            output.Message = "Game is started, GameId : " + guid;
            output.Guid = guid;
            return output;
        }
        /// <summary>
        /// if valid -> capture move -> populate player moves -> change the turn to other player
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="personId"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public MoveOutput CaptureMove(Guid gameId, int personId, int row, int col)
        {
            GameStatus game = gamesService.GetGame(gameId);
            var moveOutput = Validate(game,personId,row,col);
            if(!moveOutput.IsValid)
            {
                return moveOutput;
            }

            game.Board[row, col] = personId;
            var moves = game.PlayerMoves[personId];
            moves.Add(new Coordinate(row, col));
            moveOutput.Moves = moves;
            game.MoveCount++;
            moveOutput.Message = "Recorded move succesfully";
            
            if (game.MoveCount >= game.BoardSize * game.BoardSize)
            {
                game.IsCompleted = true;
                game.IsDraw = true;
                moveOutput.Message = "Match is drawed";
            }
            if (CheckifGameCompleted(game, gameId, personId, row, col))
            {
                moveOutput.Message = "You win";
                game.IsCompleted = true;
                game.winner = personId;
            }
            else
            {
                game.PlayerTurn = personId == game.Person1 ? game.Person2 : game.Person1;
            }
            return moveOutput;
        }
        /// <summary>
        /// Validation for before making a move ps: put further validations here
        /// </summary>
        /// <param name="game"></param>
        /// <param name="personId"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public MoveOutput Validate(GameStatus game, int personId, int row, int col)
        {
            MoveOutput moveOutput = new MoveOutput();
            if (game == null)
            {
                moveOutput.Message = "Invalid GameId";
                return moveOutput;
            }
            if (personId <= 0 || row < 0 || row >= game.BoardSize || col < 0 || col >= game.BoardSize)
            {
                moveOutput.Message = "Invalid input";
                return moveOutput;
            }
            if (game.IsCompleted)
            {
                moveOutput.Message = "Game is ended already";
                return moveOutput;
            }
            if (game.Person1 != personId && game.Person2 != personId)
            {
                moveOutput.Message = "Invalid player";
                return moveOutput;
            }
            if (game.PlayerTurn != personId)
            {
                moveOutput.Message = "Wait for the player : " + game.PlayerTurn;
                return moveOutput;
            }
            if (game.Board[row, col] != 0)
            {
                moveOutput.Message = "Block is already filled";
                return moveOutput;
            }
            moveOutput.IsValid = true;
            return moveOutput;
        }
        private bool CheckifGameCompleted(GameStatus game, Guid gameId, int personId, int row, int col)
        {
            return game != null && (IsDiagonallyDone(game, personId, row, col) || IsRowDone(game, personId, row) || IsRowDone(game, personId, col));
        }
        /// <summary>
        /// checks for two diagonals
        /// </summary>
        /// <param name="game"></param>
        /// <param name="gameId"></param>
        /// <param name="personId"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public bool IsDiagonallyDone(GameStatus game, int personId, int row, int col)
        {
            bool iswinInLeft = false, iswinInRight = false;
            if(game != null)
            {
                var board = game.Board;
                //left top to right bottom diagonal
                int count = 0;
                for (int i = 0; i < game.BoardSize; i++)
                {
                    if (personId == board[i,i])
                    {
                        count++;
                    }
                }
                iswinInLeft = count == game.BoardSize;

                //right diagonal
                count = 0;
                int x = 0, y = game.BoardSize - 1;
                for (int i = 0; i < game.BoardSize; i++)
                {
                    if (personId == board[x,y])
                    {
                        count++;
                    }
                    x++;y--;
                }
                iswinInRight = count == game.BoardSize;
            }
            else
            {
                return false;
            }
            return iswinInRight || iswinInLeft;
        }
        public bool IsRowDone(GameStatus game, int personId, int row)
        {
            if (game != null)
            {
                var board = game.Board;
                for (int i = 0; i < game.BoardSize; i++)
                {
                    if (personId != board[row,i])
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }
        public bool IsColDone(GameStatus game, int personId, int col)
        {
            if (game != null)
            {
                var board = game.Board;
                for (int i = 0; i < game.BoardSize; i++)
                {
                    if (personId != board[i,col])
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}