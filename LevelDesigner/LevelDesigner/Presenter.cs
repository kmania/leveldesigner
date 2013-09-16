using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace LevelDesigner
{
    class Presenter
    {
        IView view;
        Map map;
        private int maxCellSize = 100, squareSize;
        float startX, startY;
        Graphics graphics;

        Point focusCell;
        int focusWall;

        public Presenter(IView newView)
        {
            this.view = newView;
            this.map = new Map();
        }

        public void setDimensions()
        {
            this.squareSize = this.maxCellSize;

            this.map.columns = Convert.ToInt32(this.view.columns);
            this.map.rows = Convert.ToInt32(this.view.rows);
            
            this.map.draw();
        }

        public void draw(PaintEventArgs ev)
        {
            //if (this.map.columns > 0 && this.map.rows > 0)
            if (this.view.columns != "" && this.view.rows != "")
            {               
                this.graphics = ev.Graphics;
                Pen pen = new Pen(Color.Black, 2);

                this.calculateStartPosition();

                // draw the outside borders
                graphics.DrawRectangle(pen, startX, startY, (this.squareSize * this.map.columns), (this.squareSize * this.map.rows));

                foreach (Cell cell in this.map.cells)
                {
                    // top line
                    pen.Color = Color.Black;
                    Point start = new Point((int)(startX + (cell.x * squareSize)), (int)(startY + (cell.y * squareSize)));
                    /*graphics.DrawLine(pen, start, new Point(start.X + squareSize, start.Y));*/


                    // right line
                    if (cell.rightBorder) pen.Color = Color.Blue;
                    else pen.Color = Color.Black;

                    start.X += squareSize;
                    // if its not the last cell on the column, draw the right line
                    if (cell.column != this.map.columns) graphics.DrawLine(pen, start, new Point(start.X, start.Y + squareSize));


                    // bottom line
                    if (cell.bottomBorder) pen.Color = Color.Blue;
                    else pen.Color = Color.Black;

                    start.Y += squareSize;
                    // if its not the last cell on the row, draw the bottom line
                    if(cell.row != this.map.rows) graphics.DrawLine(pen, start, new Point(start.X - squareSize, start.Y));


                    /*// left line
                    pen.Color = Color.Black;
                    start.X -= squareSize;
                    graphics.DrawLine(pen, start, new Point(start.X, start.Y - squareSize));*/
                }

                this.drawFocusCell();
            }
        }

        private void calculateStartPosition()
        {
            this.startX = ((float)this.view.panel.Width / 2) - ((float)(this.map.columns / 2) * this.squareSize) - (this.squareSize / 2);
            this.startY = ((float)this.view.panel.Height / 2) - ((float)(this.map.rows / 2) * this.squareSize) - (this.squareSize / 2);
        }

        public void mouseMove(object sender, MouseEventArgs evt)
        {
            float leftCorner = ((float)this.view.panel.Width / 2) - ((float)(this.map.columns / 2) * squareSize) - (squareSize / 2);
        }

        public void setFocusCell(Point cell, int wall)
        {
            this.focusCell = cell;
            this.focusWall = wall;
        }

        public void drawFocusCell()
        {
            // the starting corner for the walls of a cell
            Point[] wallStart = new Point[] { new Point(0, 0), new Point(this.squareSize, 0), new Point(this.squareSize, this.squareSize), new Point(0, this.squareSize) };

            Point start = new Point((int)(this.startX + wallStart[this.focusWall].X + ((this.focusCell.X - 1) * this.squareSize)), (int)(this.startY + wallStart[this.focusWall].Y + ((this.focusCell.Y - 1) * this.squareSize)));

            //Point[] wallEnd = new Point[] { new Point(this.squareSize, 0), new Point(this.squareSize, this.squareSize), new Point(0, this.squareSize), new Point(0, 0) }; // where the end of the line is based on the starting point (corner of the cell)
            //Point end = new Point((int)(this.startX + wallEnd[this.focusWall].X + ((this.focusCell.X - 1) * this.squareSize)), (int)(this.startY + wallEnd[this.focusWall].Y + ((this.focusCell.Y - 1) * this.squareSize)));
           
            
            Point[] wallEnd = new Point[] { new Point(this.squareSize, 0), new Point(0, this.squareSize), new Point(-this.squareSize, 0), new Point(0, -this.squareSize) }; // where the end of the line is based on the start of the line
            Point end = new Point(start.X + wallEnd[this.focusWall].X, start.Y + wallEnd[this.focusWall].Y);

            this.graphics.DrawLine(new Pen(Color.Green, 3), start, end);
        }
    }
}
