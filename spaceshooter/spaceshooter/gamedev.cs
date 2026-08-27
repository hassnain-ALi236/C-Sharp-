using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using EZInput;

namespace spaceshooter
{
    public partial class gamedev : Form
    {
        PictureBox enemy;
        ProgressBar playerhealth;
        int enemyfiregeneration_time;
        int enemyfirecurrent_time;
        string enemydirection;
        int enemyspeed = 5;
        List<PictureBox> enemybullets;
        List<PictureBox> playerbullets;

        public gamedev()
        {
            InitializeComponent();
        }

        private void gamedev_Load(object sender, EventArgs e)
        {
            Start();
        }

        private void gameloop_Tick(object sender, EventArgs e)
        {
            moveplayer();
            moveenemy();
            creatbullet();
            movebullets();
            detectcollision();
        }

        private void Start()
        {
            gameloop.Enabled = true;
            this.Controls.Clear();
            this.BackgroundImage = Properties.Resources.background_jpg_1;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            playerbullets = new List<PictureBox>();
            enemybullets = new List<PictureBox>();
            creatplayer();
            createnemy();
        }

        private void creatplayer()
        {
            player = new PictureBox();
            Image img = Properties.Resources.ibbiplayer;
            player.Image = img;                                    // ✅ uncomment karo
            player.SizeMode = PictureBoxSizeMode.StretchImage;    // ✅ sirf yeh ek baar
            player.Width = 80;                                     // ✅ size
            player.Height = 80;
            player.BackColor = Color.Transparent;
            player.Top = (this.Height / 2) + 10;
            player.Left = (this.Width / 2) - 60;

            playerhealth = new ProgressBar();
            playerhealth.Value = 100;
            playerhealth.Width = 80;
            playerhealth.Top = player.Top + player.Height;
            playerhealth.Left = player.Left;

            this.Controls.Add(player);
            this.Controls.Add(playerhealth);
        }
        private void createnemy()
        {
            enemydirection = "right";
            enemy = new PictureBox();
            Image img = Properties.Resources.ibbienemy;
            enemy.Image = img;                                    // ✅ uncomment karo
            enemy.SizeMode = PictureBoxSizeMode.StretchImage;    // ✅ sirf yeh ek baar
            enemy.Width = 80;                                     // ✅ size
            enemy.Height = 80;
            enemy.BackColor = Color.Transparent;
            enemyfiregeneration_time = 10;
            enemyfirecurrent_time = 0;
            enemy.Top = 0;
            enemy.Left = 0;
            this.Controls.Add(enemy);
        }

        private void moveplayer()
        {
            if (Keyboard.IsKeyPressed(Key.RightArrow))
                player.Left += 10;
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
                player.Left -= 10;
            playerhealth.Left = player.Left;
            playerhealth.Top = player.Top + player.Height;
        }

        private void moveenemy()
        {
            if (enemy.Left <= 0)
                enemydirection = "right";
            if (enemy.Left >= (this.Width - enemy.Width - 39))
                enemydirection = "left";
            if (enemydirection == "left")
                enemy.Left -= enemyspeed;
            if (enemydirection == "right")
                enemy.Left += enemyspeed;
        }

        private void creatbullet()
        {
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                PictureBox bullet = new PictureBox();
                Image img = Properties.Resources.lazer;
                bullet.Image = img;
                bullet.Width = img.Width;
                bullet.Height = img.Height;
                bullet.BackColor = Color.Transparent;
                bullet.Top = player.Top - 22;
                bullet.Left = player.Left + 18;
                this.Controls.Add(bullet);
                playerbullets.Add(bullet);
            }

            enemyfirecurrent_time++;
            if (enemyfirecurrent_time == enemyfiregeneration_time)
            {
                PictureBox bullet = new PictureBox();
                Image img = Properties.Resources.redlazer;
                bullet.Image = img;
                bullet.Width = img.Width;
                bullet.Height = img.Height;
                bullet.BackColor = Color.Transparent;
                bullet.Top = enemy.Top + enemy.Height;
                bullet.Left = enemy.Left + 18;
                this.Controls.Add(bullet);
                enemybullets.Add(bullet);
                enemyfirecurrent_time = 0;
            }
        }

        private void movebullets()
        {
            List<PictureBox> toRemove = new List<PictureBox>();
            foreach (PictureBox bullet in playerbullets)
            {
                bullet.Top -= 20;
                if (bullet.Top < 0)
                {
                    this.Controls.Remove(bullet);
                    toRemove.Add(bullet);
                }
            }
            foreach (PictureBox b in toRemove)
                playerbullets.Remove(b);

            List<PictureBox> toRemove2 = new List<PictureBox>();
            foreach (PictureBox bullet in enemybullets)
            {
                bullet.Top += 20;
                if (bullet.Top > this.Height)
                {
                    this.Controls.Remove(bullet);
                    toRemove2.Add(bullet);
                }
            }
            foreach (PictureBox b in toRemove2)
                enemybullets.Remove(b);
        }

        private void detectcollision()
        {
            // Player bullet enemy ko lage
            for (int i = 0; i < playerbullets.Count; i++)
            {
                PictureBox bullet = playerbullets[i];
                Rectangle bulletRect = new Rectangle(
                    bullet.Left + 5, bullet.Top + 5,
                    bullet.Width - 10, bullet.Height - 10);
                Rectangle enemyRect = new Rectangle(
                    enemy.Left + 10, enemy.Top + 10,
                    enemy.Width - 20, enemy.Height - 20);
                if (bulletRect.IntersectsWith(enemyRect))
                {
                    enemy.Visible = false;
                    bullet.Visible = false;
                    player.Visible = false;
                }
            }

            // Enemy bullet player ko lage
            for (int i = 0; i < enemybullets.Count; i++)
            {
                PictureBox bullet = enemybullets[i];
                Rectangle bulletRect = new Rectangle(
                    bullet.Left + 5, bullet.Top + 5,
                    bullet.Width - 10, bullet.Height - 10);
                Rectangle playerRect = new Rectangle(
                    player.Left + 10, player.Top + 10,
                    player.Width - 20, player.Height - 20);
                if (bulletRect.IntersectsWith(playerRect))
                {
                    if (playerhealth.Value > 0)
                    {
                        playerhealth.Value -= 1;
                        bullet.Visible = false;
                        player.Visible = false;
                    }
                }
            }
        }

        private void gameover(Image img)
        {
            gameloop.Enabled = false;
            buttonrestart game = new buttonrestart(img);
            DialogResult result = game.ShowDialog();
            if (result == DialogResult.Yes)
                Start();
            if (result == DialogResult.No)
                this.Hide();
        }
    }
}