using System;
using System.Collections.Generic;
using System.Text;

namespace MindsweeperGame1
{
    class Cell
    {
        private int row;
        public int Row
        {
            get { return row; }
            set { row = value; }
        }

        private int column { get; set; }
        public int Column
        {
            get { return column; }
            set { column = value; }
        }

        private bool visited { get; set; }
        public bool Visited
        {
            get { return visited; }
            set { visited = value; }
        }

        private bool Live { get; set; }
        public bool live
        {
            get { return Live; }
            set { Live = value; }
        }

        private int neighbors;
        public int Neighbors
        {
            get { return neighbors; }
            set { neighbors = value; }
        }

        public Cell()
        {
            row = -1;
            column = -1;
            visited = false;
            Live = false;
            neighbors = 0;
        }

        Cell(int row, int column, bool isVisited, bool Live, int neighbors)
        {
            this.row = row;
            this.column = column;
            this.visited = isVisited;
            this.Live = Live;
            this.neighbors = neighbors;
        }
    }
}
