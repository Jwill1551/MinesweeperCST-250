using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindsweeperGame1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool gameOver = false;
            Board board = new Board(8);
            board.setupLiveNeighbors(0.5);
            board.calculateLiveNeighbors();
            int visitedCells = 0;

            //The game will contiune to run until the user either wins or loses
            while (gameOver != true)
            {
                printBoard(board);

                //Prompt the user to pick a coordinate on the grid
                Console.WriteLine("Please select a value for Row between 0 and " + board.getSize() + ": ");
                int userRow = int.Parse(Console.ReadLine());

                Console.WriteLine("Please select a value for Column between 0 and " + board.getSize() + ": ");
                int userColumn = int.Parse(Console.ReadLine());

                //If the user picks a cell to land on then the cells condition is true
                board.Grid[userRow, userColumn].Visited = true;
                board.FloodFill(userRow, userColumn);

                if (board.Grid[userRow, userColumn].live == true && board.Grid[userRow, userColumn].Visited == true)
                {
                    Console.WriteLine("You landed on a bomb, so therefor you lose!");
                    gameOver = true;
                }
                else if (visitedCells >= (board.difficulty - board.getSize()))
                {
                    Console.WriteLine("You visited all the non-bomb cells, you win!");
                    gameOver = true;
                }
                else
                {
                    Console.WriteLine("Your last visited location is (Row: " + userRow + ", Column: " + userColumn + ")");
                    gameOver = false;
                    visitedCells++;
                }
            }
            printBoard(board);
        }

        //This method will print out the size and layout of the grid
        public static void printBoard(Board obj)
        {
            int boardSize = obj.getSize();

            for (int i = 0; i < boardSize; i++)
            {
                repeatStr(boardSize);
                Console.WriteLine("+");

                for (int j = 0; j < boardSize; j++)
                {
                    if (obj.Grid[i, j].live == true && obj.Grid[i, j].Visited == true)
                    {
                        Console.Write("| * ");
                    }
                    else if (obj.Grid[i, j].Visited == true)
                    {
                        Console.Write("| " + obj.Grid[i, j].Neighbors + " ");
                    }
                    else
                    {
                        Console.Write("| ? ");
                    }
                }
                Console.Write("|");
                Console.WriteLine();
            }
            repeatStr(boardSize);
            Console.WriteLine("+");
        }

        //Part of the outline of the board 
        public static void repeatStr(int x)
        {
            for (int i = 0; i < x; i++)
            {
                Console.Write("+---");
            }
        }
    }
}
