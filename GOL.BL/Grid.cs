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
                    GridofCells[column, row] = new Cell(Cell.states.dead);
                }
            }

            //Create Block
            for (int column = 50; column < 55; column++)
            {
                for (int row = 20; row < 80; row++)
                {
                    GridofCells[column, row] = new Cell(Cell.states.alive);
                }
            }

            ////Hollow block
            //for (int column = 45; column < 55; column++)
            //{
            //    for (int row = 45; row < 55; row++)
            //    {
            //        GridofCells[column, row] = new Cell(Cell.states.dead);
            //    }
            //}

            //Create stuff
            GridofCells[20, 19] = new Cell(Cell.states.alive);
            GridofCells[19, 20] = new Cell(Cell.states.alive);
            GridofCells[19, 21] = new Cell(Cell.states.alive);
            GridofCells[20, 21] = new Cell(Cell.states.alive);
            GridofCells[21, 21] = new Cell(Cell.states.alive);

            GridofCells[80, 79] = new Cell(Cell.states.alive);
            GridofCells[81, 80] = new Cell(Cell.states.alive);
            GridofCells[79, 81] = new Cell(Cell.states.alive);
            GridofCells[80, 81] = new Cell(Cell.states.alive);
            GridofCells[81, 81] = new Cell(Cell.states.alive);
        }
    }
}
