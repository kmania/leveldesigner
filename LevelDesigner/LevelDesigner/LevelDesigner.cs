using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LevelDesigner
{
    public partial class LevelDesigner : Form, IView
    {
        Presenter presenter;

        public string columns { get { return this.tbxColumns.Text; }}
        public string rows { get { return this.tbxRows.Text; }}
        public Point size { get { return this.size; } }
        public GroupBox panel { get { return this.picturePanel; }}

        public LevelDesigner()
        {
            InitializeComponent();
            this.presenter = new Presenter(this);
            this.WindowState = FormWindowState.Maximized;
        }

        private void LevelDesigner_Load(object sender, EventArgs e)
        {

        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            if (this.columns != "" & this.rows != "")
            {
                this.presenter.setDimensions();
                this.presenter.setFocusCell(new Point(1, 1), 0);

                this.picture.Refresh();
            }
        }

        private void picture_Paint(object sender, PaintEventArgs e)
        {
            this.presenter.draw(e);
        }

        private void picture_MouseMove(object sender, MouseEventArgs e)
        {
            this.presenter.mouseMove(sender, e);
        }
    }
}
