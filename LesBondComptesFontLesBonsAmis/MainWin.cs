using System;
using System.Drawing;
using System.Windows.Forms;

namespace LesBondComptesFontLesBonsAmis
{
    public partial class MainWin : Form
    {
        Panel pMenu = new Panel();
        Panel pGame=new Panel();
        Panel pCard;
        Button play = new Button();
        Button leave = new Button();
        Player player = new Player();
        Button restart = new Button();
        Button[] life = new Button[3];
        ProgressBar timeLeft;
        Label labLevel = new Label();
        Label labTour = new Label();
        Label points = new Label();
        Label answer = new Label();
        Label firstNum = new Label();
        Label op = new Label();
        Label secondNum = new Label();
        Label calInPro = new Label();
        int nb1;
        int nb2;
        int currentLevel;
        int currentRound;
        public MainWin()
        {
            InitializeComponent();
            Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            WindowState = FormWindowState.Maximized;
            menu();
        }
        public void initGame()
        {
            pGame.Size = Size;
            restart.Size = new Size(Screen.PrimaryScreen.Bounds.Width/100*5, Screen.PrimaryScreen.Bounds.Width / 100 * 5);
            restart.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 100 * 5, Screen.PrimaryScreen.Bounds.Width / 100 * 5);
            restart.Text = "restart";
            pGame.Controls.Add(restart);
            for(int i = 0; i < 3; i++)
            {
                life[i] = new Button();
                life[i].Size=new Size(Screen.PrimaryScreen.Bounds.Width / 100 * 5, Screen.PrimaryScreen.Bounds.Width / 100 * 5);
                life[i].Location = new Point((Screen.PrimaryScreen.Bounds.Width/2)-(3*life[i].Width/2)+(i* life[i].Width), restart.Height);
                life[i].Text = "Life";
                pGame.Controls.Add(life[i]);
            }
            labLevel.Text = currentLevel.ToString();
            labLevel.Location = new Point(pGame.Width-pGame.Width/100*15, restart.Height);
            pGame.Controls.Add(labLevel);
            labTour.Text = currentRound.ToString();
            labTour.Location = new Point(labLevel.Location.X + labLevel.Size.Width, labLevel.Location.Y); 
            pGame.Controls.Add(labTour);
            answer.Text = "reponse attendu";
            answer.Location = new Point(pGame.Width/2-answer.Width/2,pGame.Height/100*30);
            pGame.Controls.Add(answer);
            firstNum.Text = "Nombre 1";
            firstNum.Location = new Point(pGame.Width/2-(pGame.Width/2)/100*25,pGame.Height/2);
            pGame.Controls.Add(firstNum);
            op.Text = "Operateur";
            op.Location = new Point(pGame.Width / 2 - op.Width / 2, pGame.Height / 2);
            pGame.Controls.Add(op);
            secondNum.Text = "Nombre 2";
            secondNum.Location = new Point(pGame.Width / 2 + (pGame.Width / 2) / 100 * 25, pGame.Height / 2);
            pGame.Controls.Add(secondNum);
            points.Text = player.points.ToString();
            points.Location = new Point(labTour.Location.X, Screen.PrimaryScreen.Bounds.Width / 100 * 10);
            pGame.Controls.Add(points);
            timeLeft = new ProgressBar();
            timeLeft.Size = new Size(pGame.Width / 100 * 25, pGame.Height / 100 * 4);
            timeLeft.Location = new Point(pGame.Width / 2 - timeLeft.Size.Width / 2, pGame.Height / 100 * 65);
            timeLeft.Step = 1;
            timeLeft.Value = 15;
            timeLeft.Maximum = 15;
            pGame.Controls.Add(timeLeft);
            calInPro.Text = "Calcul en cours";
            calInPro.Location = new Point(pGame.Width / 2 - calInPro.Width/2, pGame.Height / 100 * 75);
            pGame.Controls.Add(calInPro);
            Controls.Add(pGame);
        }
        public void restartClick(object sender, EventArgs e)
        {
            pGame.Controls.Clear();
            initGame();
            showCards(currentLevel, currentRound);

        }
        public void showCards(int lvl,int round)
        {
            pCard = new Panel();
            pCard.Size = new Size(Width,Height / 100 * 25);
            pCard.Location = new Point(0, Height - pCard.Height);
            for (int nbCard = 0; nbCard < player.GetLevel(lvl).GetRound(round).numberCard;nbCard++)
            {
                pCard.Controls.Add(player.GetLevel(lvl).GetRound(round).GetNumberCard(nbCard));
                player.GetLevel(lvl).GetRound(round).GetNumberCard(nbCard).Click += new EventHandler(numberCardClick);
                player.GetLevel(lvl).GetRound(round).GetNumberCard(nbCard).MouseEnter += new EventHandler(CardEnter);
                player.GetLevel(lvl).GetRound(round).GetNumberCard(nbCard).MouseLeave += new EventHandler(CardLeave);
            }
            for (int nbCard = 0; nbCard < player.GetLevel(lvl).GetRound(round).numberOp; nbCard++)
            {
                pCard.Controls.Add(player.GetLevel(lvl).GetRound(round).GetOperateurCard(nbCard));
                player.GetLevel(lvl).GetRound(round).GetOperateurCard(nbCard).MouseEnter += new EventHandler(CardEnter);
                player.GetLevel(lvl).GetRound(round).GetOperateurCard(nbCard).MouseLeave += new EventHandler(CardLeave);
                player.GetLevel(lvl).GetRound(round).GetOperateurCard(nbCard).Click += new EventHandler(operateurCardClick);
            }
            pGame.Controls.Add(pCard);
        }
        public void game()
        {
            showCards(currentLevel, currentRound);
            answer.Text = player.GetLevel(currentLevel).GetRound(currentRound).answer.ToString();
        }
        public void win()
        {
            if (currentRound == 4)
            {
                if (currentLevel == 2)
                {
                    pGame.Dispose();
                    menu();
                   
                }
                else
                {
                    currentLevel++;
                }
                currentRound = 1;
                pCard.Dispose();
                initGame();
                game();
            }
            else
            {
                currentRound++;
                pCard.Dispose();
                initGame();
                game();
            }
        }
        public void numberCardClick(object sender, EventArgs e)
        {
            Color back = ColorTranslator.FromHtml("#002640");
            NumberCard card = sender as NumberCard;
            if (card.BackColor != back)
            {
                card.BackColor = back;
                if (firstNum.Text == "Nombre 1")
                {
                    firstNum.Text = card.value.ToString();
                    calInPro.Text = card.value.ToString();
                    nb1 = card.value;
                    card.used = true;
                }
                else
                {
                    if (op.Text != "Operateur")
                    {
                        secondNum.Text = card.value.ToString();
                        switch (op.Text)
                        {
                            case "+":
                                calInPro.Text = (nb1 + card.value).ToString();
                                nb2 = nb1 + card.value;
                                card.used = true;
                                break;
                            case "-":
                                calInPro.Text = (nb1 - card.value).ToString();
                                nb2 = nb1 - card.value;
                                card.used = true;
                                break;
                            case "x":
                                calInPro.Text = (nb1 * card.value).ToString();
                                nb2 = nb1 * card.value;
                                card.used = true;
                                break;
                            case "/":
                                calInPro.Text = (nb1 / card.value).ToString();
                                if (nb1 % card.value==0)
                                {
                                    nb2 = nb1 / card.value;
                                    card.used = true;
                                }
                                break;
                        }

                    }
                    if (calInPro.Text == answer.Text)
                    {
                        win();
                    }
                    else
                    {
                        nb1 = nb2;
                        firstNum.Text = calInPro.Text;
                        op.Text = "Operateur";
                        secondNum.Text = "Nombre 2";
                    }
                }
            }


        }

        public void operateurCardClick(object sender, EventArgs e)
        {
            OperateurCard card = sender as OperateurCard;
            switch (card.symbol)
            {
                case 1:
                    op.Text = "+";
                    break;
                case 2:
                    op.Text = "-";
                    break;
                case 3:
                    op.Text = "x";
                    break;
                case 4:
                    op.Text = "/";
                    break;
            }
        }
        public void CardEnter(object sender, EventArgs e)
        {
            Card card = sender as Card;
            if (!card.used)
            {
                Color word = ColorTranslator.FromHtml("#5A7475");
                Color back = ColorTranslator.FromHtml("#F5E9A4");
                card.ForeColor = word;
                card.BackColor = back;
            }
        }
        public void CardLeave(object sender, EventArgs e)
        { 
            Card card = sender as Card;
            if (!card.used)
            {
                Color word = ColorTranslator.FromHtml("#000");
                Color back = Color.FromName("GradientActiveCaption");
                card.ForeColor = word;
                card.BackColor = back;
            }
        }
        private void play_MouseEnter(object sender, EventArgs e)
        {
            Color word = ColorTranslator.FromHtml("#5A7475");
            Color back = ColorTranslator.FromHtml("#F5E9A4");
            play.ForeColor = word;
            play.BackColor = back;
        }
        private void leave_MouseEnter(object sender, EventArgs e)
        {
            Color word = ColorTranslator.FromHtml("#5A7475");
            Color back = ColorTranslator.FromHtml("#F5E9A4");
            leave.ForeColor = word;
            leave.BackColor = back;
        }
        private void play_MouseLeave(object sender, EventArgs e)
        {
            Color word = ColorTranslator.FromHtml("#000");
            Color back = Color.FromName("GradientActiveCaption");
            play.ForeColor = word;
            play.BackColor = back;
        }
        private void leave_MouseLeave(object sender, EventArgs e)
        {
            Color word = ColorTranslator.FromHtml("#000");
            Color back = Color.FromName("GradientActiveCaption");
            leave.ForeColor = word;
            leave.BackColor = back;
        }
        private void leave_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void play_Click(object sender, EventArgs e)
        {
            pMenu.Dispose();
            currentLevel = 1;
            currentRound = 1;
            initGame();
            game();
        }
        public void menu()
        {
            pMenu.Size = this.Size;
            Controls.Add(pMenu);
            Label title = new Label();
            title.AutoSize = true;
            title.Font = new Font("Impact", 55, FontStyle.Regular);
            Color test = ColorTranslator.FromHtml("#F5E9A4");
            title.ForeColor = test;
            title.Text = ("LES BONS COMPTES FONT LES BONS AMIS");
            title.Location = new Point(Width/100*20,Height/100*15);
            pMenu.Controls.Add(title);
            play.Font=new Font("Impact", 40, FontStyle.Regular);
            play.Text = "PLAY";
            play.Size = new Size(Width / 100 * 8, Height / 100 * 7);
            play.Location = new Point((Width - play.Width)/2, Height / 100 * 40);
            play.FlatAppearance.BorderSize = 0;
            play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            play.MouseEnter += new System.EventHandler(play_MouseEnter);
            play.MouseLeave += new System.EventHandler(play_MouseLeave);
            play.Click+= new System.EventHandler(play_Click);
            leave.Font = new Font("Impact", 40, FontStyle.Regular);
            leave.Text = "QUITTER";
            leave.Size = new Size(Width / 100 * 15, Height / 100 * 7);
            leave.Location = new Point((Width - leave.Width) / 2, Height / 100 * 55);
            leave.FlatAppearance.BorderSize = 0;
            leave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            leave.MouseEnter += new System.EventHandler(leave_MouseEnter);
            leave.MouseLeave += new System.EventHandler(leave_MouseLeave);
            leave.Click += new System.EventHandler(leave_Click);
            pMenu.Controls.Add(play);
            pMenu.Controls.Add(leave);
        }
    }
}
