using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOL.BL
{
    public class Grid
    {
        Random random = new Random();

        public Grid()
        {

        }

        public Grid(int columns, int rows)
        {
            Columns = columns;
            Rows = rows;
            GridofCells = new Cell[Columns, Rows];

            PopulateStartGrid();
        }

        public int Columns { get; set; }
        public int Rows { get; set; }
        public Cell[,] GridofCells { get; set; }

        public void PopulateStartGrid()
        {
            //Dead cells
            for (int column = 0; column < Columns; column++)
            {
                for (int row = 0; row < Rows; row++)
                {
                    var cellState = random.Next(2);

                    if (cellState == 0)
                    {
                        GridofCells[column, row] = new Cell(Cell.states.dead);
                    }
                    else
                    {
                        GridofCells[column, row] = new Cell(Cell.states.alive);
                    }

                    
                }
            }
        }
    }
}
