using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LesBondComptesFontLesBonsAmis
{
    public partial class MainWin : Form
    {
        public MainWin()
        {
            InitializeComponent();
            Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            WindowState = FormWindowState.Maximized;
        }

    }
}
