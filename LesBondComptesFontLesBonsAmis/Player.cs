using System;
using System.Collections.Generic;
using System.Text;

namespace LesBondComptesFontLesBonsAmis
{
    class Player
    {
        int nbLife { get; set; }
        int points { get; set; }
        Level[] lvl;
        Player()
        {
            nbLife = 3;
            points = 0;
            lvl = new Level[2];
        }
    }
}
