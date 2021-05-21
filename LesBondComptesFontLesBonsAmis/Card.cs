using System.Drawing;
using System.Windows.Forms;

namespace LesBondComptesFontLesBonsAmis
{
    public class Card : Button
    {
        private bool selected;
        private bool used;
        public Card(int posX, int posY)
        {
            selected = false;
            used = false;
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width/100*5,Screen.PrimaryScreen.Bounds.Height/100*15);
            Location = new Point(posX, posY);
            Visible = true;
        }
    }
}