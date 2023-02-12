using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameFrameWork;
using GameFrameWork.Movements;
using GameFrameWork.Enums;
using GameFrameWork.Fire;
using GameFrameWork.Collision;


namespace NinjaVsZombie
{
    public partial class FrmGame : Form
    {
        Game game;

        public FrmGame()
        {
            InitializeComponent();
            startGame();

        }

        private void startGame()
        {
            game = new Game();
            game.OnGameObjectAdded += Game_OnGameObjectAdded;
            game.OnGameObjectRemoved += Game_OnGameObjectRemoved;
            game.OnLeftMove += Player_OnLeftMove;
            game.OnRightMove += Player_OnRightMove;
            game.OnEnemyDie += Game_OnEnemyDie;
            game.OnPlayerDie += Game_OnPlayerDie;
            game.OnPictureBoxRemoved += Game_OnPictureBoxRemoved;
            game.OnProgressBarAdded += Game_OnProgressBarAdd;
            game.OnWinGame += Game_OnWinGame;

            Point boundary = new Point(this.Width, this.Height);
            IMovement move1 = new UsingKeyboard(10, boundary, Keys.Left, Keys.Right);
            PLayerFire fire = new PLayerFire(Properties.Resources.KunaiLeft, Properties.Resources.KunaiRight , ObjectTypes.PlayerFire,20, Keys.Z, Keys.X, boundary);
            game.addGameObjectPlayer(Properties.Resources.Idle_Left,"Ninja" , 707, 509, ObjectTypes.Player, move1, 100, fire);
            game.bringToFrontGameObject(ObjectTypes.Player);

            makeZombie();
            makePlatform();
            makeLadders();
            makeChest();

            CollisionClass c1 = new CollisionClass(ObjectTypes.Player, ObjectTypes.Ladder, new LadderColision());
            game.addCollision(c1);
            CollisionClass c2 = new CollisionClass(ObjectTypes.Player, ObjectTypes.Enemy, new PlayerFireCollision(25));
            game.addCollision(c2);
            CollisionClass c3 = new CollisionClass(ObjectTypes.Player, ObjectTypes.Enemy, new EnemyFireCollision(20));
            game.addCollision(c3);
            CollisionClass c4 = new CollisionClass(ObjectTypes.Player, ObjectTypes.Chest, new CollisionWithChest(Properties.Resources.Chest_02_Unlocked));
            game.addCollision(c4);

        }


        private void makeZombie()
        {
            GameObject player = game.FindGameObject("Ninja");
            
            EnemyFire fire = new EnemyFire(Properties.Resources.EnemyFire, Properties.Resources.EnemyFire, ObjectTypes.EnemyFire, 20,new Point(this.Width, this.Height), player);
            game.addGameObjectPlayer(Properties.Resources.Zombie2_Walking, "Zombie1", 1258, 510, ObjectTypes.Enemy, new HorizontalMovement(5, new Point(282, 1258), MoveNames.Left), 100,new EnemyFire(fire));
            game.addGameObjectPlayer(Properties.Resources.Zombie2_Walking, "Zombie2", 350, 254, ObjectTypes.Enemy, new HorizontalMovement(5, new Point(350, 1172), MoveNames.Right), 100, new EnemyFire(fire));
            game.addGameObjectPlayer(Properties.Resources.Zombie2_Walking, "Zombie3", 738, 19, ObjectTypes.Enemy, new HorizontalMovement(5, new Point(97, 738), MoveNames.Left), 100, new EnemyFire(fire));
        }

        private void makeChest()
        {
            game.addGameObject(Properties.Resources.Chest_02_Locked, "pbChest", 12, 87, new Point(90, 84), PictureBoxSizeMode.StretchImage, ObjectTypes.Chest , new Idle());
        }

        private void makeLadders()
        {
            game.addGameObject(Properties.Resources.Ladder, "pbLadder01", 189, 560, new Point(106, 102), PictureBoxSizeMode.StretchImage, ObjectTypes.Ladder, new Idle());
            game.addGameObject(Properties.Resources.Ladder, "pbLadder02", 189, 465, new Point(106, 102), PictureBoxSizeMode.StretchImage, ObjectTypes.Ladder, new Idle());
            game.addGameObject(Properties.Resources.Ladder, "pbLadder03", 189, 369, new Point(106, 102), PictureBoxSizeMode.StretchImage, ObjectTypes.Ladder, new Idle());
            game.addGameObject(Properties.Resources.Ladder, "pbLadder04", 833, 302, new Point(106, 102), PictureBoxSizeMode.StretchImage, ObjectTypes.Ladder, new Idle());
            game.addGameObject(Properties.Resources.Ladder, "pbLadder05", 833, 203, new Point(106, 102), PictureBoxSizeMode.StretchImage, ObjectTypes.Ladder, new Idle());
            game.addGameObject(Properties.Resources.Ladder, "pbLadder06", 833, 108, new Point(106, 102), PictureBoxSizeMode.StretchImage, ObjectTypes.Ladder, new Idle());

        }


        private void makePlatform()
        {
            game.addGameObject(Properties.Resources.Ground_03, "pbPlatform01", 0, 577, new Point(115, 85), PictureBoxSizeMode.StretchImage, ObjectTypes.Platform, new Idle());
            game.addGameObject(Properties.Resources.Ground_07, "pbPlatform02", 0, 657, new Point(115, 85), PictureBoxSizeMode.StretchImage, ObjectTypes.Platform, new Idle());
            game.addGameObject(Properties.Resources.Ground_02, "pbPlatform03", 112, 657, new Point(150, 85), PictureBoxSizeMode.StretchImage, ObjectTypes.Platform, new Idle());
            game.addGameObject(Properties.Resources.Ground_02, "pbPlatform04", 258, 657, new Point(150, 85), PictureBoxSizeMode.StretchImage, ObjectTypes.Platform, new Idle());
            game.addGameObject(Properties.Resources.Ground_02, "pbPlatform05", 405, 657, new Point(150, 85), PictureBoxSizeMode.StretchImage, ObjectTypes.Platform, new Idle());
            game.addGameObject(Properties.Resources.Ground_02, "pbPlatform06", 551, 657, new Point(150, 85), PictureBoxSizeMode.StretchImage, ObjectTypes.Platform, new Idle());
            game.addGameObject(Properties.Resources.Ground_02, "pbPlatform07", 696, 657, new Point(150, 85), PictureBoxSizeMode.StretchImage, ObjectTypes.Platform, new Idle());
            game.addGameObject(Properties.Resources.Ground_02, "pbPlatform08", 843, 657, new Point(148, 85), PictureBoxSizeMode.StretchImage, ObjectTypes.Platform, new Idle());
            game.addGameObject(Properties.Resources.Ground_02, "pbPlatform09", 985, 657, new Point(148, 85), PictureBoxSizeMode.StretchImage, ObjectTypes.Platform, new Idle());
            game.addGameObject(Properties.Resources.Ground_02, "pbPlatform10", 1121, 657, new Point(148, 85), PictureBoxSizeMode.StretchImage, ObjectTypes.Platform, new Idle());
            game.addGameObject(Properties.Resources.Ground_02, "pbPlatform11", 1261, 657, new Point(148, 85), PictureBoxSizeMode.StretchImage, ObjectTypes.Platform, new Idle());
            game.addGameObject(Properties.Resources.Ground_05, "pbPlatform12", 1258, 401, new Point(116, 67), PictureBoxSizeMode.StretchImage, ObjectTypes.Platform, new Idle());
            game.addGameObject(Properties.Resources.Ground_01, "pbPlatform13", 1258, 319, new Point(115, 85), PictureBoxSizeMode.StretchImage, ObjectTypes.Platform, new Idle());
            game.addGameObject(Properties.Resources.Ground_11, "pbPlatform14", 1147, 404, new Point(114, 67), PictureBoxSizeMode.StretchImage, ObjectTypes.Platform, new Idle());
            game.addGameObject(Properties.Resources.Ground_11, "pbPlatform15", 1011, 404, new Point(148, 67), PictureBoxSizeMode.StretchImage, ObjectTypes.Platform, new Idle());
            game.addGameObject(Properties.Resources.Ground_11, "pbPlatform16", 907, 404, new Point(114, 67), PictureBoxSizeMode.StretchImage, ObjectTypes.Platform, new Idle());
            game.addGameObject(Properties.Resources.Ground_11, "pbPlatform17", 812, 404, new Point(114, 67), PictureBoxSizeMode.StretchImage, ObjectTypes.Platform, new Idle());
            game.addGameObject(Properties.Resources.Ground_11, "pbPlatform18", 713, 404, new Point(114, 67), PictureBoxSizeMode.StretchImage, ObjectTypes.Platform, new Idle());
            game.addGameObject(Properties.Resources.Ground_11, "pbPlatform19", 607, 404, new Point(114, 67), PictureBoxSizeMode.StretchImage, ObjectTypes.Platform, new Idle());
            game.addGameObject(Properties.Resources.Ground_11, "pbPlatform20", 501, 404, new Point(114, 67), PictureBoxSizeMode.StretchImage, ObjectTypes.Platform, new Idle());
            game.addGameObject(Properties.Resources.Ground_11, "pbPlatform21", 392, 404, new Point(114, 67), PictureBoxSizeMode.StretchImage, ObjectTypes.Platform, new Idle());
            game.addGameObject(Properties.Resources.Ground_10, "pbPlatform22", 282, 404, new Point(114, 67), PictureBoxSizeMode.StretchImage, ObjectTypes.Platform, new Idle());
            game.addGameObject(Properties.Resources.Ground_12, "pbPlatform23", 706, 168, new Point(140, 67), PictureBoxSizeMode.StretchImage, ObjectTypes.Platform, new Idle());
            game.addGameObject(Properties.Resources.Ground_11, "pbPlatform24", 602, 168, new Point(114, 67), PictureBoxSizeMode.StretchImage, ObjectTypes.Platform, new Idle());
            game.addGameObject(Properties.Resources.Ground_11, "pbPlatform25", 507, 168, new Point(114, 67), PictureBoxSizeMode.StretchImage, ObjectTypes.Platform, new Idle());
            game.addGameObject(Properties.Resources.Ground_11, "pbPlatform26", 408, 168, new Point(114, 67), PictureBoxSizeMode.StretchImage, ObjectTypes.Platform, new Idle());
            game.addGameObject(Properties.Resources.Ground_11, "pbPlatform27", 302, 168, new Point(114, 67), PictureBoxSizeMode.StretchImage, ObjectTypes.Platform, new Idle());
            game.addGameObject(Properties.Resources.Ground_11, "pbPlatform28", 196, 168, new Point(114, 67), PictureBoxSizeMode.StretchImage, ObjectTypes.Platform, new Idle());
            game.addGameObject(Properties.Resources.Ground_11, "pbPlatform29", 87, 168, new Point(114, 67), PictureBoxSizeMode.StretchImage, ObjectTypes.Platform, new Idle());
            game.addGameObject(Properties.Resources.Ground_10, "pbPlatform30", -23, 168, new Point(114, 67), PictureBoxSizeMode.StretchImage, ObjectTypes.Platform, new Idle());
        }

        private void Game_OnWinGame(object sender, EventArgs e)
        {
            // win game
            Image img = NinjaVsZombie.Properties.Resources.WinImg3;
            FrmGameEnd frm = new FrmGameEnd(img);
            GameLoop.Enabled = false;
            DialogResult result = frm.ShowDialog();
            GameLoop.Stop();
        }

        private void Game_OnProgressBarAdd(object sender, EventArgs e)
        {
            ProgressBar bar = (ProgressBar)sender;
            this.Controls.Add(bar);
        }
        private void Game_OnGameObjectAdded(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            this.Controls.Add(pb);
        }
            

        private void Game_OnGameObjectRemoved(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            this.Controls.Remove(pb);
        }

        private void Game_OnPictureBoxRemoved(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            this.Controls.Remove(pb);
        }

        private void Game_OnEnemyDie(object sender, EventArgs e)
        {
            GameObjectPlayer enemy = (GameObjectPlayer)sender;

            this.Controls.Remove(enemy.Pb);
            this.Controls.Remove(enemy.HealthBar);

        }

        private void Game_OnPlayerDie(object sender, EventArgs e)
        {
            GameObjectPlayer player = (GameObjectPlayer)sender;

            this.Controls.Remove(player.Pb);
            this.Controls.Remove(player.HealthBar);


            Image img = NinjaVsZombie.Properties.Resources.Gameover_generated;
            FrmGameEnd frm = new FrmGameEnd(img);
            GameLoop.Enabled = false;
            DialogResult result = frm.ShowDialog();
            GameLoop.Stop();
        }


        private void Player_OnLeftMove(object sender, EventArgs e)
        {
            GameObject obj = (GameObject)sender;

            if (obj.Pb.Name == "Ninja")
            {
                obj.changeImage(NinjaVsZombie.Properties.Resources.Idle_Left);
            }

            if(obj.ObjType == ObjectTypes.Enemy && obj.Value != 0)
            {
                obj.changeImage(NinjaVsZombie.Properties.Resources.Zombie2_Walking);
                obj.Value = 0;
            }
        }

        private void Player_OnRightMove(object sender, EventArgs e)
        {
            GameObject obj = (GameObject)sender;

            if (obj.Pb.Name == "Ninja")
            {
                obj.changeImage(NinjaVsZombie.Properties.Resources.Idle_Right);
            }

            if (obj.ObjType == ObjectTypes.Enemy && obj.Value != 1)
            {
                obj.changeImage(NinjaVsZombie.Properties.Resources.Zombie2_WalkingRight);
                obj.Value = 1;
            }
        }



        private void GameLoop_Tick(object sender, EventArgs e)
        {
            game.update();
            game.createFire();
            game.gravityForPlayer("Ninja", 5);
            game.detectCollison();
        }
    }
}
