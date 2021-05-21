using System;
using System.Collections.Generic;
using System.Text;

namespace LesBondComptesFontLesBonsAmis
{
    class OperateurCard : Card
    {
        private char value;
        public OperateurCard(int posX,int posY,bool selected, bool used, char value) : base(posX,posY)
        {
            this.value = value;
        }
    }
}
