using System;
using System.Collections.Generic;
using System.Text;

namespace LesBondComptesFontLesBonsAmis
{
    class Player
    {
        public int nbLife;
        public int points;
        Level[] lvl = new Level[2];
        public Player()
        {
            nbLife = 3;
            points = 0;
            lvl[0] = new Level(200, 1);
            lvl[1] = new Level(250, 2);
        }
        public Level GetLevel(int index)
        {
            return lvl[index];
        }
    }
}
