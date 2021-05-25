using System;
using System.Collections.Generic;
using System.Text;

namespace LesBondComptesFontLesBonsAmis
{
    class NumberCard : Card
    {
        public int value{ get; private set; }
        public NumberCard(int Posx, int Posy,int value) : base(Posx, Posy)
        {
            this.value = value;
            Text = value.ToString();  
        }
    }
}
