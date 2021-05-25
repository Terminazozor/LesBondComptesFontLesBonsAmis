using System.Drawing;
using System.Windows.Forms;

namespace LesBondComptesFontLesBonsAmis
{
    public class Card : Button
    {
        public bool used;
        public Card(int posX, int posY)
        {
            used = false;
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width/100*8,Screen.PrimaryScreen.Bounds.Height/100*20);
            Location = new Point(posX, posY);
            Visible = true;
        }
    }
}