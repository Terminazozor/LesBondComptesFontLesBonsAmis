using System;
using System.Collections.Generic;
using System.Text;

namespace LesBondComptesFontLesBonsAmis
{
    class OperateurCard : Card
    {
        public int symbol { get; private set; }
        public OperateurCard(int posX,int posY, int symbol) : base(posX,posY)
        {
            this.symbol = symbol;
            switch (symbol)
            {
                case 1:
                    Text = "+";
                    break;
                case 2:
                    Text = "-";
                    break;
                case 3:
                    Text = "x";
                    break;
                case 4:
                    Text = "/";
                    break;
            }
        }
    }
}
