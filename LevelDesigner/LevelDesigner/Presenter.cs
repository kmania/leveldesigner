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

        Point[] wallStart;
        Point[] wallEnd;

        public Presenter(IView newView)
        {
            this.view = newView;
            this.map = new Map();

            this.squareSize = this.maxCellSize;

            // the starting corner for the walls of a cell
            this.wallStart = new Point[] { new Point(0, 0), new Point(this.squareSize, 0), new Point(this.squareSize, this.squareSize), new Point(0, this.squareSize) };
            this.wallEnd = new Point[] { new Point(this.squareSize, 0), new Point(0, this.squareSize), new Point(-this.squareSize, 0), new Point(0, -this.squareSize) }; // where the end of the line is based on the start of the line
        }

        public void setDimensions()
        {
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
            if (this.map.cells != null)
            {
                Point mouse = new Point(evt.X, evt.Y);
                mouse.X = (mouse.X - (int)this.startX);
                mouse.Y = (mouse.Y - (int)this.startY);

                foreach (Cell cell in this.map.cells)
                {
                    Point cellLocation = new Point((int)((cell.x * this.squareSize) + this.startX), (int)((cell.y * this.squareSize) + this.startY));
                    //int wall = 0;
                    bool hit = false;

                    int column = (int)Math.Truncate(((double)mouse.X + (this.squareSize * .99)) / this.squareSize);
                    int row = (int)Math.Truncate(((double)mouse.Y + (this.squareSize * .99)) / this.squareSize);
                    

                    Point mouseInCell = new Point((((column - 1) * this.squareSize) - mouse.X) * -1, (((row - 1) * this.squareSize) - mouse.Y) * -1);
                    Point[] middleWalls = new Point[] { new Point(this.squareSize / 2, 0), new Point(this.squareSize, this.squareSize / 2), new Point(this.squareSize / 2, this.squareSize), new Point(0, this.squareSize / 2)};

                    int difference = this.squareSize *2;
                    int chosenWall = 3;

                    /*for (int wall = 0; wall < middleWalls.Length; wall++)
                    {
                        if ((Math.Abs(mouseInCell.X - middleWalls[wall].X) + Math.Abs(mouseInCell.Y - middleWalls[wall].Y)) < difference)
                        {
                            difference = (Math.Abs(mouseInCell.X - middleWalls[wall].X) + Math.Abs(mouseInCell.Y - middleWalls[wall].Y));
                            chosenWall = wall;
                            this.view.setPosition(difference.ToString() + "   ");
                        }
                    }*/

                    if (mouseInCell.Y <= 25 & mouseInCell.X < 75 && mouseInCell.X > 25) chosenWall = 0;
                    else if (mouseInCell.Y >= 75 & mouseInCell.X < 75 && mouseInCell.X > 25) chosenWall = 2;
                    else if (mouseInCell.X >= 75) chosenWall = 1;
                    else chosenWall = 3;

                    this.view.setPosition(column.ToString() + " " + row.ToString() + " " + mouseInCell.ToString());
                    //this.view.setPosition(chosenWall.ToString());
                    this.setFocusCell(new Point(column, row), chosenWall);
                    /*List<int> possible = new List<int>();
                    possible[0] = this.squareSize;// x proximity to mouse
                    possible[1] = this.squareSize;// y proximity to mouse
                    possible[2] = 0;// cell x
                    possible[3] = 0;// cell y
                    possible[4] = 0;// wall*/

                    /*for (wall = 0; wall < 4; wall++)
                    {
                        if (Math.Abs(mouse.X - (cellLocation.X + (this.wallEnd[wall].X / 2))) <= (this.squareSize / 2) && Math.Abs(mouse.Y - (cellLocation.Y + (this.wallEnd[wall].Y / 4))) <= (this.squareSize / 2))
                        {
                            this.setFocusCell(new Point(cell.column, cell.row), wall);
                            //this.view.refresh();
                            hit = true;
                            //this.view.setPosition((mouse.ToString() + new Point((int)cellLocation.X + this.wallEnd[wall].X, (int)(cellLocation.Y + this.wallEnd[wall].Y)).ToString()));
                            this.view.setPosition();
                            //break;
                        }
                    }*/
                    /*if (hit)
                    {
                        break;

                    }*/
                }

                this.view.refresh();
            }
        }

        public void setFocusCell(Point cell, int wall)
        {
            this.focusCell = cell;
            this.focusWall = wall;
        }
        
        public void drawFocusCell()
        {
            if (this.focusCell.X != 0)
            {
                Point start = new Point((int)(this.startX + wallStart[this.focusWall].X + ((this.focusCell.X - 1) * this.squareSize)), (int)(this.startY + wallStart[this.focusWall].Y + ((this.focusCell.Y - 1) * this.squareSize)));

                //Point[] wallEnd = new Point[] { new Point(this.squareSize, 0), new Point(this.squareSize, this.squareSize), new Point(0, this.squareSize), new Point(0, 0) }; // where the end of the line is based on the starting point (corner of the cell)
                //Point end = new Point((int)(this.startX + wallEnd[this.focusWall].X + ((this.focusCell.X - 1) * this.squareSize)), (int)(this.startY + wallEnd[this.focusWall].Y + ((this.focusCell.Y - 1) * this.squareSize)));

                Point end = new Point(start.X + wallEnd[this.focusWall].X, start.Y + wallEnd[this.focusWall].Y);

                this.graphics.DrawLine(new Pen(Color.Red, 3), start, end);
            }
        }
    }
}
