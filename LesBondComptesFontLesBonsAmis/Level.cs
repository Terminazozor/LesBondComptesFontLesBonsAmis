using System;
using System.Collections.Generic;
using System.Text;

namespace LesBondComptesFontLesBonsAmis
{
    class Level
    {
        private Round[] rounds=new Round[4];
        public int neededPoints { get; private set; }
        public Level(int np,int number)
        {
            neededPoints = np;
            for(int i = 0; i < 4; i++)
            {
                if (number == 1)
                {
                    rounds[i] = new Round(number, 4);
                }
                else
                {
                    rounds[i] = new Round(number, 6);
                }
                
            }
        }
        public Round GetRound(int index)
        {
            return rounds[index];
        }
    }
}
