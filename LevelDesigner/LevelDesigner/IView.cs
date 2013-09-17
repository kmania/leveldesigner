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
    interface IView
    {
        string columns { get; }
        string rows { get; }
        Point size { get; }
        GroupBox panel { get; }

        void refresh();
        void setPosition(string text);
    }
}
