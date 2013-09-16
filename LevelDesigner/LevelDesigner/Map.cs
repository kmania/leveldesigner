using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LevelDesigner
{
    class Map
    {
        public int columns { get; set; }
        public int rows { get; set; }
        public Cell[] cells { get; set; }

        public Map()
        {
        }

        public int[] getCell(Point cell)
        {
            //return this.cells[cell.X][cell.Y];
            return new int[] { 1, 0, 1, 0 };
        }

        public void draw()
        {
            // an array that holds each cell
            this.cells = new Cell[this.columns * this.rows];

            // for each column
            for (int x = 0, index = 0; x < this.columns; x++)
            {
                // for each row
                for (int y = 0; y < this.rows; y++, index++)
                {
                    this.cells[index] = new Cell(this, x, y, false, false);
                    //System.Windows.Forms.MessageBox.Show("Cell index =" + index.ToString() + ". Row i = " + i + ". Row value = " + this.cells[index].row + ". Column j = " + j.ToString() + ". Column value = " + this.cells[index].column.ToString());
                }
            }
        }
    }
}
