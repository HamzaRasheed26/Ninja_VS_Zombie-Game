using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace NinjaVsZombie.CharactersBL
{
    internal class Zombie
    {
        private PictureBox pbZombie;
        private ProgressBar healthBar;
        private int number;
        private bool move;

        public Zombie(PictureBox pbZombie, ProgressBar healthBar, int number)
        {
            this.pbZombie = pbZombie;
            this.healthBar = healthBar;
            this.move = true;
            this.number = number;
        }

        public PictureBox PbZombie { get => pbZombie; set => pbZombie = value; }
        public bool Move { get => move; set => move = value; }
        public ProgressBar HealthBar { get => healthBar; set => healthBar = value; }
        public int Number { get => number; set => number = value; }

        public void setImage(Image img)
        {
            pbZombie.Image = img;
            pbZombie.Width = img.Width;
            pbZombie.Height = img.Height;
        }
    }
}
