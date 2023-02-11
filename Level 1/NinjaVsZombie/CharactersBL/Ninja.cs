using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace NinjaVsZombie.CharactersBL
{
    public class Ninja
    {
        private PictureBox pbNinja;
        private ProgressBar ninjaHealth;
        private int ninjaMove;

        public Ninja(PictureBox pbNinja, ProgressBar ninjaHealth)
        {
            this.pbNinja = pbNinja;
            this.ninjaHealth = ninjaHealth;
            this.ninjaMove = 0;
        }

        public PictureBox PbNinja { get => pbNinja; set => pbNinja = value; }
        public int NinjaMove { get => ninjaMove; set => ninjaMove = value; }
        public ProgressBar NinjaHealth { get => ninjaHealth; set => ninjaHealth = value; }

        public void changeNinjaImg(Image img)
        {
            pbNinja.Image = img;
            pbNinja.Height = img.Height;
            pbNinja.Width = img.Width;
        }
    }
}
