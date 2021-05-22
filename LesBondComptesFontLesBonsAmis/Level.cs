using System;
using System.Collections.Generic;
using System.Text;

namespace LesBondComptesFontLesBonsAmis
{
    class Level
    {
        Round[] rounds;
        int neededPoints { get;}
        Level(int np)
        {
            rounds = new Round[4];
            neededPoints = np;
        }
    }
}
