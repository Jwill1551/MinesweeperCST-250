using System;
using System.Collections.Generic;
using System.Text;

namespace MindsweeperGame1
{
    class Board
    {
        //The size of the board 
        private int size;

        public int getSize()
        {
            return size;
        }

        //The grid for the board, filled with cells  
        public Cell[,] Grid;

        public double difficulty;

        public Board(int size)
        {
            //The grid is initialized and given the type obj of the class Cell
            Grid = new Cell[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Grid[i, j] = new Cell();
                }
            }
            this.size = size;
        }

        public void setupLiveNeighbors(double difficulty)
        {
            Random r = new Random();

            //The higher the difficulty the more cells will be live
            int liveGrids = Convert.ToInt32(difficulty * Grid.Length);
            int liveCounter = 0;

            //These for loops will run througth the Grid and randomly put some cells as live
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int rand = r.Next(0, 2);

                    if (liveCounter < liveGrids)
                    {
                        if (rand == 0)
                        {
                            Grid[i, j].live = false;
                        }
                        else
                        {
                            Grid[i, j].live = true;
                            liveCounter++;
                        }
                    }
                }
            }

        }

        //This method will count the live neighbors in Grid
        public void calculateLiveNeighbors()
        {
            int liveCount = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    // North
                    if (isSafe(i - 1, j))
                    {
                        if (Grid[i - 1, j].live)
                        {
                            Grid[i, j].Neighbors++;
                        }
                    }

                    // North east
                    if (isSafe(i - 1, j - 1))
                    {
                        if (Grid[i - 1, j - 1].live)
                        {
                            Grid[i, j].Neighbors++;
                        }
                    }

                    // North west
                    if (isSafe(i - 1, j + 1))
                    {
                        if (Grid[i - 1, j + 1].live)
                        {
                            Grid[i, j].Neighbors++;
                        }
                    }

                    // East
                    if (isSafe(i, j - 1))
                    {
                        if (Grid[i, j - 1].live)
                        {
                            Grid[i, j].Neighbors++;
                        }
                    }

                    // West
                    if (isSafe(i, j + 1))
                    {
                        if (Grid[i, j + 1].live)
                        {
                            Grid[i, j].Neighbors++;
                        }
                    }

                    // South
                    if (isSafe(i + 1, j))
                    {
                        if (Grid[i + 1, j].live)
                        {
                            Grid[i, j].Neighbors++;
                        }
                    }

                    //South east
                    if (isSafe(i + 1, j - 1))
                    {
                        if (Grid[i + 1, j - 1].live)
                        {
                            Grid[i, j].Neighbors++;
                        }
                    }

                    // South west
                    if (isSafe(i + 1, j + 1))
                    {
                        if (Grid[i + 1, j + 1].live)
                        {
                            Grid[i, j].Neighbors++;
                        }
                    }
                }
            }

        }

        public bool isSafe(int x, int y)
        {
            // check to see if this square is out of bounds.
            return (x >= 0 && x < size && y >= 0 && y < size);

        }

        //This is a recursive method and will set all non live cells to visited
        public void FloodFill(int Row, int Col)
        {
            // North (?)
            if (isSafe(Row - 1, Col))
            {
                if (Grid[Row - 1, Col].live == false && !Grid[Row - 1, Col].Visited)
                {
                    Grid[Row - 1, Col].Visited = true;
                    FloodFill(Row - 1, Col);
                }
            }

            // East
            if (isSafe(Row, Col - 1))
            {
                if (Grid[Row, Col - 1].live == false && !Grid[Row, Col - 1].Visited)
                {
                    Grid[Row, Col - 1].Visited = true;
                    FloodFill(Row, Col - 1);
                }
            }

            // North east
            if (isSafe(Row - 1, Col - 1))
            {
                if (Grid[Row - 1, Col - 1].live == false && !Grid[Row - 1, Col - 1].Visited)
                {
                    Grid[Row - 1, Col - 1].Visited = true;
                    FloodFill(Row - 1, Col - 1);
                }
            }

            // North west
            if (isSafe(Row - 1, Col + 1))
            {
                if (Grid[Row - 1, Col + 1].live == false && !Grid[Row - 1, Col + 1].Visited)
                {
                    Grid[Row - 1, Col + 1].Visited = true;
                    FloodFill(Row - 1, Col + 1);
                }
            }

            // West
            if (isSafe(Row, Col + 1))
            {
                if (Grid[Row, Col + 1].live == false && !Grid[Row, Col + 1].Visited)
                {
                    Grid[Row, Col + 1].Visited = true;
                    FloodFill(Row, Col + 1);
                }
            }

            // South
            if (isSafe(Row + 1, Col))
            {
                if (Grid[Row + 1, Col].live == false && !Grid[Row + 1, Col].Visited)
                {
                    Grid[Row + 1, Col].Visited = true;
                    FloodFill(Row + 1, Col);
                }
            }

            //South east
            if (isSafe(Row + 1, Col - 1))
            {
                if (Grid[Row + 1, Col - 1].live == false && !Grid[Row + 1, Col - 1].Visited)
                {
                    Grid[Row + 1, Col - 1].Visited = true;
                    FloodFill(Row + 1, Col - 1);
                }
            }

            // South west
            if (isSafe(Row + 1, Col + 1))
            {
                if (Grid[Row + 1, Col + 1].live == false && !Grid[Row + 1, Col + 1].Visited)
                {
                    Grid[Row + 1, Col + 1].Visited = true;
                    FloodFill(Row + 1, Col + 1);
                }
            }
        }
    }
}