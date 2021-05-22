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
        Panel pMenu = new Panel();
        Panel pGame = new Panel();
        Button play = new Button();
        Button leave = new Button();
        public MainWin()
        {
            InitializeComponent();
            Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            WindowState = FormWindowState.Maximized;
            menu();
        }
        public void initGame()
        {
            pGame.Size = Size;
            Player p;
            
        }
        private void play_MouseEnter(object sender, EventArgs e)
        {
            Color word = ColorTranslator.FromHtml("#5A7475");
            Color back = ColorTranslator.FromHtml("#F5E9A4");
            play.ForeColor = word;
            play.BackColor = back;
        }
        private void leave_MouseEnter(object sender, EventArgs e)
        {
            Color word = ColorTranslator.FromHtml("#5A7475");
            Color back = ColorTranslator.FromHtml("#F5E9A4");
            leave.ForeColor = word;
            leave.BackColor = back;
        }
        private void play_MouseLeave(object sender, EventArgs e)
        {
            Color word = ColorTranslator.FromHtml("#000");
            Color back = Color.FromName("GradientActiveCaption");
            play.ForeColor = word;
            play.BackColor = back;
        }
        private void leave_MouseLeave(object sender, EventArgs e)
        {
            Color word = ColorTranslator.FromHtml("#000");
            Color back = Color.FromName("GradientActiveCaption");
            leave.ForeColor = word;
            leave.BackColor = back;
        }
        private void leave_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void play_Click(object sender, EventArgs e)
        {
            pMenu.Visible = false;
            initGame();
        }
        public void menu()
        {
            pMenu.Size = this.Size;
            Controls.Add(pMenu);
            Label title = new Label();
            title.AutoSize = true;
            title.Font = new Font("Impact", 55, FontStyle.Regular);
            Color test = ColorTranslator.FromHtml("#F5E9A4");
            title.ForeColor = test;
            title.Text = ("LES BONS COMPTES FONT LES BONS AMIS");
            title.Location = new Point(Width/100*20,Height/100*15);
            pMenu.Controls.Add(title);
            play.Font=new Font("Impact", 40, FontStyle.Regular);
            play.Text = "PLAY";
            play.Size = new Size(Width / 100 * 8, Height / 100 * 7);
            play.Location = new Point((Width - play.Width)/2, Height / 100 * 40);
            play.FlatAppearance.BorderSize = 0;
            play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            play.MouseEnter += new System.EventHandler(play_MouseEnter);
            play.MouseLeave += new System.EventHandler(play_MouseLeave);
            play.Click+= new System.EventHandler(play_Click);
            leave.Font = new Font("Impact", 40, FontStyle.Regular);
            leave.Text = "QUITTER";
            leave.Size = new Size(Width / 100 * 15, Height / 100 * 7);
            leave.Location = new Point((Width - leave.Width) / 2, Height / 100 * 55);
            leave.FlatAppearance.BorderSize = 0;
            leave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            leave.MouseEnter += new System.EventHandler(leave_MouseEnter);
            leave.MouseLeave += new System.EventHandler(leave_MouseLeave);
            leave.Click += new System.EventHandler(leave_Click);
            pMenu.Controls.Add(play);
            pMenu.Controls.Add(leave);
        }
    }
}
