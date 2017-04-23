using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.CodeWars.CSharp.Arrays
{

    /*
    If we were to set up a Tic-Tac-Toe game, we would want to know whether the board's current state is solved, wouldn't we? Our goal is to create a function that will check that for us!

        Assume that the board comes in the form of a 3x3 array, where the value is 0 if a spot is empty, 1 if it is an X, or 2 if it is an O, like so:

        [[0,0,1],
         [0,1,2],
         [2,1,0]]
        We want our function to return -1 if the board is not solved yet, 1 if X won, 2 if O won, or 0 if it's a cat's game (i.e. a draw).

        You may assume that the board passed in is valid in the context of a game of Tic-Tac-Toe.
*/

        /// <summary>
        /// keys to victory
        /// writing matrix down!!!
        /// making images of desired behavior
        /// </summary>

    public  static class TicTacToeChecker
    {
        private static readonly IEnumerable<int> boardTypes = new[] {1, 2};

        private enum boardStatus
        {
            NotSolved = -1,
            Draw = 0,
            XWon = 1,
            OWon = 2,
        }

        public static int IsSolved(int[,] board)
        {
            int result = (int) boardStatus.NotSolved;
            foreach (var boardType in boardTypes)
            {
                //#1 Check if Middle is Empty
                if (board[1, 2] != 0)
                {
                    if ((board[0, 0] == boardType && board[1, 1] == boardType && board[2, 2] == boardType) //diagonal
                        || (board[0,1] == boardType && board[1, 1] == boardType && board[2,1] == boardType)//second column
                        || (board[0,2] == boardType && board[1, 1] == boardType && board[2, 0] == boardType)//reverse diagonal
                        || (board[1, 0] == boardType && board[1, 1] == boardType && board[1, 2] == boardType)// second row
                        )
                    {
                        result = boardType;
                        break;
                    }
                }

                //#2 Check if top right corner  is Empty
                if (board[0, 0] != 0) 
                    {
                        if ((board[0, 0] == boardType && board[0, 1] == boardType && board[0, 2] == boardType)//first row
                            || (board[0, 0] == boardType && board[1, 0] == boardType && board[2, 0] == boardType)//first column
                            )
                            {
                                result = boardType;
                                break;}
                }

                //#2 Check if bottom left corner  is Empty
                if (board[2, 2] != 0) 
                {
                    if ((board[0, 2] == boardType && board[1,2] == boardType && board[2, 2] == boardType)
                        || (board[2, 0] == boardType && board[2,1] == boardType && board[2, 2] == boardType))
                        //third column)
                    {
                        result = boardType;
                        break;
                    }
                }
            }

            // check for empty if no tic tac toe detected
            if (result == (int) boardStatus.NotSolved)
            {
                result = (int)boardStatus.Draw;
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        if (board[row, col] == 0)
                        {
                            result = (int) boardStatus.NotSolved;
                        }
                    }
                }
            } 

            return result;
        }
    }
}

/*
 var winLines = new int[][] { 
      new []{0,1,2}, 
      new []{3,4,5}, 
      new []{6,7,8}, 
      new []{0,3,6}, 
      new []{1,4,7}, 
      new []{2,5,8}, 
      new []{0,4,8}, 
      new []{2,4,6} };
      */