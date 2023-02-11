using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NinjaVsZombie.CharactersBL;
using EZInput;


namespace NinjaVsZombie
{
    public partial class FrmGame : Form
    {
        int totalKunai;
        List<PictureBox> kunais;
        List<Zombie> zombieList1;

        Label lblKunai;
        Label lblScore;
        int score;

        Ninja ninja;


        public FrmGame()
        {
            InitializeComponent();
        }

        private void FrmGame_Load(object sender, EventArgs e)
        {
            startGame();
        }

        private void startGame()
        {
            this.BackgroundImage = NinjaVsZombie.Properties.Resources.Background;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            kunais = new List<PictureBox>();
            totalKunai = 10;
            score = 0;
            makeNinja();

            zombieList1 = new List<Zombie>();
            Zombie zombie = generateZombie1(this.Width);
            zombieList1.Add(zombie);

            makeKunaiLabel();
            makeScoreLabel();

        }
        private void makeNinja()
        {
            PictureBox pbNinja = new PictureBox();
            Image img = NinjaVsZombie.Properties.Resources.Idle_Right;
            pbNinja.Image = img;
            pbNinja.Height = img.Height;
            pbNinja.Width = img.Width;
            pbNinja.Left = 100;
            pbNinja.Top = this.Height - (pbSurface.Height + pbNinja.Height + 40);
            pbNinja.BackColor = Color.Transparent;
            pbNinja.BringToFront();
            this.Controls.Add(pbNinja);

            ProgressBar pbHelth = new ProgressBar();
            pbHelth.Value = 100;
            pbHelth.Left = pbNinja.Left - 10;
            pbHelth.Top = pbNinja.Top - 30;
            pbHelth.Size = new Size(119, 13);

            this.Controls.Add((pbHelth));

            ninja = new Ninja(pbNinja, pbHelth);
        }

        private Zombie generateZombie1(int left)
        {

            Random rand = new Random();

            int select = rand.Next(1, 4);
            int no;
            Image img;
            if (select == 1)
            {
                img = NinjaVsZombie.Properties.Resources.Zombie1_Walking;
                no = 1;
            }
            else if(select == 2)
            {
                img = NinjaVsZombie.Properties.Resources.Zombie2_Walking;
                no = 2;
            }
            else
            {
                img = NinjaVsZombie.Properties.Resources.Zombie3_Walking;
                no = 3;
            }

            
            PictureBox pbZombie = new PictureBox();
            pbZombie.Image = img;
            pbZombie.Width = img.Width;
            pbZombie.Height = img.Height; 
            pbZombie.Left = left;
            pbZombie.Top = this.Height - (pbSurface.Height + pbZombie.Height + 40);
            pbZombie.BackColor = Color.Transparent;
            this.Controls.Add(pbZombie);

            ProgressBar pbHelth = new ProgressBar();
            pbHelth.Value = 100;
            pbHelth.Left = pbZombie.Left - 10;
            pbHelth.Top = pbZombie.Top - 30;
            pbHelth.Size = new Size(119, 13);
            this.Controls.Add((pbHelth));

            return new Zombie(pbZombie, pbHelth, no);
        }

        

        private PictureBox generateKunai()
        {
            Image img = Properties.Resources.Kunai;
            PictureBox kunai = new PictureBox();
            kunai.Image = img;
            kunai.Height = img.Height;
            kunai.Width = img.Width;
            kunai.Left = ninja.PbNinja.Left;
            kunai.Top = ninja.PbNinja.Top + 45;
            kunai.BackColor = Color.Transparent;
            this.Controls.Add(kunai);
            return kunai;
        }

        private void NinjaMovements()
        {
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                if ((ninja.PbNinja.Left + ninja.PbNinja.Width) < this.Width)
                {
                    ninja.PbNinja.Left += 20;
                    ninja.NinjaHealth.Left = ninja.PbNinja.Left;
                    if (ninja.NinjaMove != 1)
                    {
                        Image img = Properties.Resources.Runing_Right;
                        ninja.changeNinjaImg(img);
                    }

                    ninja.NinjaMove = 1;
                }
            }
            else if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                if (ninja.PbNinja.Left > 0)
                {
                    ninja.PbNinja.Left -= 20;

                    ninja.NinjaHealth.Left = ninja.PbNinja.Left;
                    if (ninja.NinjaMove != 2)
                    {
                        Image img = Properties.Resources.Runing_Left;
                        ninja.changeNinjaImg(img);
                    }

                    ninja.NinjaMove = 2;
                }
            }
            else if (Keyboard.IsKeyPressed(Key.Space))
            {
                if (ninja.NinjaMove != 3)
                {
                    Image img = Properties.Resources.Attack_Right;
                    ninja.changeNinjaImg(img);
                }

                ninja.NinjaMove = 3;
            }
            else if (Keyboard.IsKeyPressed(Key.X))
            {
                if (ninja.NinjaMove != 4)
                {
                    if (totalKunai > 0)
                    {
                        Image img = Properties.Resources.Throw_Right;
                        ninja.changeNinjaImg(img);
                        kunais.Add(generateKunai());
                        totalKunai--;
                    }
                }

                ninja.NinjaMove = 4;
            }
            else
            {
                if (ninja.NinjaMove != 0)
                {
                    Image img1 = NinjaVsZombie.Properties.Resources.Idle_Right;
                    ninja.changeNinjaImg(img1);
                }
                ninja.NinjaMove = 0;
            }
        }

        private void moveKunai()
        {
            for(int i = 0; i < kunais.Count; i++)
            {

                kunais[i].Left += 30;
                if(kunais[i].Left > this.Width)
                {
                    kunais.Remove(kunais[i]);
                }
            }
        }

        

        private void isKunaiHit()
        {
            try
            {
                for (int i = 0; i < kunais.Count; i++)
                {
                    for (int x = 0; x < zombieList1.Count; x++)
                    {
                        if (kunais.Count != 0)
                        {
                            if (kunais[i].Bounds.IntersectsWith(zombieList1[x].PbZombie.Bounds))
                            {

                                this.Controls.Remove(kunais[i]);
                                kunais.Remove(kunais[i]);

                                zombieList1[x].HealthBar.Value -= 50;
                                // removeZombie(zombieList1[x]) ;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void removeZombie()
        {
            for(int i = 0; i < zombieList1.Count ; i++)
            {
                if (zombieList1[i].HealthBar.Value <= 0)
                {
                    this.Controls.Remove(zombieList1[i].PbZombie);
                    this.Controls.Remove(zombieList1[i].HealthBar);
                    zombieList1.Remove(zombieList1[i]);
                    score++;
                    lblScore.Text = "SCORE : " + score.ToString();
                }
            }
        }

        private void isSwordHit()
        {
            try
            {

                for (int x = 0; x < zombieList1.Count; x++)
                {
                    if (ninja.NinjaMove == 3)
                    {
                        if (ninja.PbNinja.Bounds.IntersectsWith(zombieList1[x].PbZombie.Bounds))
                        {
                            if (zombieList1[x].HealthBar.Value > 0)
                            {
                                zombieList1[x].HealthBar.Value -= 25;
                            }
                        }
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        private void newZombie()
        {
            if( wait == 0)
            {
                Random rand = new Random();
                Zombie pbZombie = generateZombie1(rand.Next(this.Width - 200, this.Width));
                zombieList1.Add(pbZombie);
                wait = 30;
            }
            wait--;
        }

        private void MoveZombies()
        {
            foreach (Zombie z in zombieList1)
            {
                if (z.Move == true)
                {
                    z.PbZombie.Left -= 5;
                    z.HealthBar.Left = z.PbZombie.Left;
                }
            }
        }


        private void attackByZombie()
        {
            foreach (Zombie z in zombieList1)
            {
                if(z.PbZombie.Bounds.IntersectsWith(ninja.PbNinja.Bounds))
                {
                    if (z.Move != false)
                    {
                        Image img;
                        if (z.Number == 1)
                        {
                            img = NinjaVsZombie.Properties.Resources.Zombie1_Attacking;
                        }
                        else if(z.Number == 2)
                        {
                            img = NinjaVsZombie.Properties.Resources.Zombie2_Attacking;
                        }
                        else
                        {
                            img = NinjaVsZombie.Properties.Resources.Zombie3_Attacking;
                        }
                        z.setImage(img);
                    }
                    if (ninja.NinjaHealth.Value > 0)
                    {
                        ninja.NinjaHealth.Value -= 1;
                    }

                    z.Move = false;
                }
                else
                {
                    if (z.Move != true)
                    {
                        Image img;
                        if (z.Number == 1)
                        {
                            img = NinjaVsZombie.Properties.Resources.Zombie1_Walking;
                        }
                        else if (z.Number == 2)
                        {
                            img = NinjaVsZombie.Properties.Resources.Zombie2_Walking;
                        }
                        else
                        {
                            img = NinjaVsZombie.Properties.Resources.Zombie3_Walking;
                        }
                        z.setImage(img);
                    }
                    z.Move = true;
                }
            }
        }

        int wait = 30;

        private void makeKunaiLabel()
        {
            lblKunai = new Label();
            lblKunai.Text = "Kunai : " + totalKunai.ToString();
            lblKunai.Name = "lblKunai";
            lblKunai.Font = new Font(FontFamily.GenericSansSerif, 14, FontStyle.Bold);
            lblKunai.Size = new System.Drawing.Size(133, 26);
            lblKunai.Location = new System.Drawing.Point(12, 9);
            lblKunai.BackColor = Color.Transparent;
            this.Controls.Add(lblKunai);
        }

        private void makeScoreLabel()
        {
            lblScore = new Label();
            lblScore.Text = "Kunai : " + totalKunai.ToString();
            lblScore.Name = "lblScore";
            lblScore.BackColor = Color.Transparent;

            lblScore.AutoSize = true;
            lblScore.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblScore.Location = new System.Drawing.Point(12, 44);
            lblScore.Size = new System.Drawing.Size(113, 26);
            lblScore.Text = "SCORE : " + score.ToString();

            this.Controls.Add(lblScore);
        }

        private void checkIsGameOver()
        {
            if (ninja.NinjaHealth.Value <= 0)
            {
                Image img = NinjaVsZombie.Properties.Resources.Gameover_generated;
                frmGameEnd frm = new frmGameEnd(img);
                GameLoop.Enabled = false;
                DialogResult result = frm.ShowDialog();
                GameLoop.Stop();
            }
        }
        private void GameLoop_Tick(object sender, EventArgs e)
        {

            NinjaMovements();
            moveKunai();
            newZombie();
            isKunaiHit();
            isSwordHit();
            removeZombie();
            MoveZombies();
            attackByZombie();
            checkIsGameOver();

            lblKunai.Text = "Kunai : " + totalKunai.ToString();
        }
    }
}
