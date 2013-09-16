using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelDesigner
{
    class Cell
    {
        Map map;
        public int x, y;
        public int column { get { return this.x + 1; } }
        public int row { get { return this.y + 1; } }
        public bool rightBorder, bottomBorder;

        public Cell(Map newMap, int column, int row)
        {
            this.map = newMap;
            this.x = column;
            this.y = row;
        }

        public Cell(Map newMap, int column, int row, bool right, bool bottom)
        {
            this.map = newMap;
            this.x = column;
            this.y = row;
            this.rightBorder = (this.column == this.map.columns) ? false : right;
            this.bottomBorder = (this.row == this.map.rows) ? false : bottom;
        }

        
    }
}
