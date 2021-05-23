using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LesBondComptesFontLesBonsAmis
{
    class Round
    {
        private readonly Random rand = new Random();
        public int answer { get; private set; }
        public int numberCard { get; private set; }
        public int numberOp { get; private set; }
        private int[] genNumber;
        private NumberCard[] nc;
        private OperateurCard[] oc;
        public Round(int lvl,int nbC)
        {
            numberOp = 2;
            nc = new NumberCard[nbC];
            numberCard = nbC;
            oc = new OperateurCard[numberOp];
            genNumber = new int[nbC];
            for(int j = 0; j < nbC; j++)
            {
                genNumber[j] = -1;
            }
            int opCho = rand.Next(1, 5);
            oc[0] = new OperateurCard(Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width / 100 * 8), Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 100 * 25), opCho);
            do
            {
                opCho = rand.Next(1, 5);
            } while (opCho == oc[0].symbol);
            oc[1] = new OperateurCard(Screen.PrimaryScreen.Bounds.Width - (oc[0].Width * 2), Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 100 * 25), opCho);
            if (lvl == 1)
            {
                lvl1Creator();
            }
            else
            {
                lvl2Creator();
            }

        }
        public NumberCard GetNumberCard(int index)
        {
            return nc[index];
        }
        public OperateurCard GetOperateurCard(int index)
        {
            return oc[index];
        }
        private int GenPos()
        {
            int pos = rand.Next(0, numberCard );
            while (genNumber[pos] != -1)
            {
                pos = rand.Next(0, numberCard );
            }
            return pos;
        }
        private void lvl1Creator()
        {
            int pos = GenPos();
            switch (oc[rand.Next(1)].symbol)
            {
                case 1:
                    int a1 = rand.Next(0, 101);
                    int a2 = rand.Next(0, 101 - a1);
                    answer = a1 + a2;
                    genNumber[pos] = a1;
                    nc[pos] = new NumberCard((Screen.PrimaryScreen.Bounds.Width / 100 * 8) * pos, Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 100 * 25), a1);
                    pos = GenPos();
                    genNumber[pos] = a2;
                    nc[pos] = new NumberCard((Screen.PrimaryScreen.Bounds.Width / 100 * 8) * pos, Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 100 * 25), a2);
                    break;
                case 2:
                    int s1 = rand.Next(0, 101);
                    int s2 = rand.Next(0, 101 - s1);
                    int sAns = s1 + s2;
                    answer = s1;
                    genNumber[pos] = s2;
                    nc[pos] = new NumberCard((Screen.PrimaryScreen.Bounds.Width / 100 * 8) * pos, Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 100 * 25), s2);
                    pos = GenPos();
                    genNumber[pos] = sAns;
                    nc[pos] = new NumberCard((Screen.PrimaryScreen.Bounds.Width / 100 * 8) * pos, Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 100 * 25), sAns);
                    break;
                case 3:
                    int m1 = rand.Next(1, 50);
                    int m2 = rand.Next(0, 100 / m1);
                    answer = m1 * m2;
                    genNumber[pos] = m1;
                    nc[pos] = new NumberCard((Screen.PrimaryScreen.Bounds.Width / 100 * 8) * pos, Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 100 * 25), m1);
                    pos = GenPos();
                    genNumber[pos] = m2;
                    nc[pos] = new NumberCard((Screen.PrimaryScreen.Bounds.Width / 100 * 8) * pos, Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 100 * 25), m2);
                    break;
                case 4:
                    int d1 = rand.Next(1, 50);
                    int d2 = rand.Next(1, 100 / d1);
                    answer = d2;
                    genNumber[pos] = d1;
                    nc[pos] = new NumberCard((Screen.PrimaryScreen.Bounds.Width / 100 * 8) * pos, Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 100 * 25), d1);
                    pos = GenPos();
                    genNumber[pos] = d2 * d1;
                    nc[pos] = new NumberCard((Screen.PrimaryScreen.Bounds.Width / 100 * 8) * pos, Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 100 * 25), d2 * d1);
                    break;
            }
            for (int i = 0; i < 3; i++)
            {
                pos = GenPos();
                nc[pos] = new NumberCard((Screen.PrimaryScreen.Bounds.Width / 100 * 8) * pos, Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 100 * 25), rand.Next(0, 100));
            }
        }
        private void lvl2Creator()
        {
            for(int i = 1; i < 3; i++)
            {
                int pos = GenPos();
                switch (oc[i-1].symbol)
                {
                    case 1:
                        int a1;
                        if (i < 2)
                        {
                            a1 = rand.Next(1, 50);
                        }
                        else
                        {
                            a1 = answer;
                        }
                        int a2 = rand.Next(1, 50*i - a1);
                        answer = a1 + a2;
                        genNumber[pos] = a1;
                        if (i < 2)
                        {
                            nc[pos] = new NumberCard((Screen.PrimaryScreen.Bounds.Width / 100 * 8) * pos, Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 100 * 25), a1);
                        }
                        pos = GenPos();
                        genNumber[pos] = a2;
                        nc[pos] = new NumberCard((Screen.PrimaryScreen.Bounds.Width / 100 * 8) * pos, Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 100 * 25), a2);
                        break;
                    case 2:
                        int s1;
                        if (i < 2)
                        {
                            s1 = rand.Next(1, 50);
                        }
                        else
                        {
                            s1 = answer;
                        }
                        int s2 = rand.Next(1, 50 * i - s1);
                        answer = s1;
                        int sAns = s1 + s2;
                        if (i < 2)
                        {
                            pos = GenPos();
                            genNumber[pos] = sAns;
                            nc[pos] = new NumberCard((Screen.PrimaryScreen.Bounds.Width / 100 * 8) * pos, Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 100 * 25), sAns);
                        }
                        genNumber[pos] = s2;
                        nc[pos] = new NumberCard((Screen.PrimaryScreen.Bounds.Width / 100 * 8) * pos, Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 100 * 25), s2);

                        break;
                    case 3:
                        int m1;
                        if (i < 2)
                        {
                            m1 = rand.Next(1, 25);
                        }
                        else
                        {
                            m1 = answer;
                        }
                        int m2 = rand.Next(1, 50*i / m1);
                        answer = m1 * m2;
                        if (i < 2)
                        {
                            genNumber[pos] = m1;
                            nc[pos] = new NumberCard((Screen.PrimaryScreen.Bounds.Width / 100 * 8) * pos, Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 100 * 25), m1);
                        }
                        pos = GenPos();
                        genNumber[pos] = m2;
                        nc[pos] = new NumberCard((Screen.PrimaryScreen.Bounds.Width / 100 * 8) * pos, Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 100 * 25), m2);
                        break;
                    case 4:
                        int d1;
                        if (i < 2)
                        {
                            d1 = rand.Next(1, 25);
                        }
                        else
                        {
                            d1 = answer;
                        }
                        int d2 = rand.Next(1, 50*i / d1);
                        answer = d2;
                        if (i < 2)
                        {
                            genNumber[pos] = d1;
                            nc[pos] = new NumberCard((Screen.PrimaryScreen.Bounds.Width / 100 * 8) * pos, Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 100 * 25), d1);
                        }
                        pos = GenPos();
                        genNumber[pos] = d2 * d1;
                        nc[pos] = new NumberCard((Screen.PrimaryScreen.Bounds.Width / 100 * 8) * pos, Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 100 * 25), d2 * d1);
                        break;
                }
                for (int j = 0; j < 5; j++)
                {
                    pos = GenPos();
                    nc[pos] = new NumberCard((Screen.PrimaryScreen.Bounds.Width / 100 * 8) * pos, Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 100 * 25), rand.Next(0, 100));
                }
            }
        }
    }
}
