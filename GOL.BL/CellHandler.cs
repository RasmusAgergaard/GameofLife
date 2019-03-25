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
            for (int column = 0; column < grid.Columns; column++)
            {
                for (int row = 0; row < grid.Rows; row++)
                {
                    var neighbours = 0;

                    //Count neighbours
                    if (column > 1 && column < 99 && row > 1 && row < 99)
                    {
                        if (grid.GridofCells[column - 1, row - 1].State == Cell.states.alive) { neighbours += 1; }
                        if (grid.GridofCells[column + 0, row - 1].State == Cell.states.alive) { neighbours += 1; }
                        if (grid.GridofCells[column + 1, row - 1].State == Cell.states.alive) { neighbours += 1; }
                        if (grid.GridofCells[column + 0, row + 0].State == Cell.states.alive) { neighbours += 1; }
                        if (grid.GridofCells[column + 1, row + 0].State == Cell.states.alive) { neighbours += 1; }
                        if (grid.GridofCells[column - 1, row + 1].State == Cell.states.alive) { neighbours += 1; }
                        if (grid.GridofCells[column + 0, row + 1].State == Cell.states.alive) { neighbours += 1; }
                        if (grid.GridofCells[column + 1, row + 1].State == Cell.states.alive) { neighbours += 1; }
                    }

                    //Underpopulation 
                    if (neighbours < 2 && grid.GridofCells[column, row].State == Cell.states.alive)
                    {
                        grid.GridofCells[column, row].State = Cell.states.dead;
                    }

                    //Overpopulation
                    if (neighbours > 3 && grid.GridofCells[column, row].State == Cell.states.alive)
                    {
                        grid.GridofCells[column, row].State = Cell.states.dead;
                    }

                    //Reproduction
                    if (neighbours == 3 && grid.GridofCells[column, row].State == Cell.states.dead)
                    {
                        grid.GridofCells[column, row].State = Cell.states.alive;
                    }

                }
            }

            //var randomColumn = random.Next(grid.Columns);
            //var randomRow = random.Next(grid.Rows);
            //grid.GridofCells[randomColumn, randomRow].State = Cell.states.alive;

            return grid;
        }
    }
}
