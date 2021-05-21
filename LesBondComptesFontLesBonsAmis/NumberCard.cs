using System;
using System.Collections.Generic;
using System.Text;

namespace LesBondComptesFontLesBonsAmis
{
    class NumberCard : Card
    {
        private int value;
        public NumberCard(int Posx, int Posy,int value) : base(Posx, Posy)
        {
            this.value = value;
        }
    }
}
