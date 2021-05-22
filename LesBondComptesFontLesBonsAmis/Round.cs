using System;
using System.Collections.Generic;
using System.Text;

namespace LesBondComptesFontLesBonsAmis
{
    class Round
    {
        private readonly Random rand = new Random();
        private int answer { get; }
        private int numberCard { get; }
        private int numberOp { get; }
        NumberCard[] nc;
        OperateurCard[] oc;
        public Round(int nbC,int nbOP)
        {
            nc = new NumberCard[nbC];
            oc = new OperateurCard[nbOP];

        }
    }
}
