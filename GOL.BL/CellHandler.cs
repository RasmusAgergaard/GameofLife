using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOL.BL
{
    public class CellHandler
    {
        Random random = new Random();

        public Grid UpdateCells(Grid grid)
        {
            //Create new grid
            var newGrid = new Grid(100, 100);

            for (int column = 0; column < grid.Columns; column++)
            {
                for (int row = 0; row < grid.Rows; row++)
                {
                    var neighbours = 0;

                    if (column - 1 >= 0 && row - 1 >= 0)
                    {
                        if (grid.GridofCells[column - 1, row - 1].State == Cell.states.alive) { neighbours += 1; }
                    }
                    if (row - 1 >= 0)
                    {
                        if (grid.GridofCells[column + 0, row - 1].State == Cell.states.alive) { neighbours += 1; }
                    }
                    if (column + 1 < grid.Columns && row - 1 >= 0)
                    {
                        if (grid.GridofCells[column + 1, row - 1].State == Cell.states.alive) { neighbours += 1; }
                    }
                    if (column - 1 >= 0)
                    {
                        if (grid.GridofCells[column - 1, row + 0].State == Cell.states.alive) { neighbours += 1; }
                    }
                    if (column + 1 < grid.Columns)
                    {
                        if (grid.GridofCells[column + 1, row + 0].State == Cell.states.alive) { neighbours += 1; }
                    }
                    if (column - 1 >= 0 && row + 1 < grid.Rows)
                    {
                        if (grid.GridofCells[column - 1, row + 1].State == Cell.states.alive) { neighbours += 1; }
                    }
                    if (row + 1 < grid.Rows)
                    {
                        if (grid.GridofCells[column + 0, row + 1].State == Cell.states.alive) { neighbours += 1; }
                    }
                    if (column + 1 < grid.Columns && row + 1 < grid.Rows)
                    {
                        if (grid.GridofCells[column + 1, row + 1].State == Cell.states.alive) { neighbours += 1; }
                    }


                    //Underpopulation
                    if (grid.GridofCells[column, row].State == Cell.states.alive && neighbours < 2)
                    {
                        newGrid.GridofCells[column, row].State = Cell.states.dead;
                    }

                    //Next generation
                    if (grid.GridofCells[column, row].State == Cell.states.alive && (neighbours == 2 || neighbours == 3))
                    {
                        newGrid.GridofCells[column, row].State = Cell.states.alive;
                    }

                    //Overpopulation
                    if (grid.GridofCells[column, row].State == Cell.states.alive && neighbours > 3)
                    {
                        newGrid.GridofCells[column, row].State = Cell.states.dead;
                    }

                    //Reproduction
                    if (grid.GridofCells[column, row].State == Cell.states.dead && neighbours == 3)
                    {
                        newGrid.GridofCells[column, row].State = Cell.states.alive;
                    }
                }
            }

            return newGrid;
        }
    }
}
