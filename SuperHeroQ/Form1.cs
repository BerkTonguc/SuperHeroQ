using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SuperHeroQ
{
   
    public partial class Form1 : Form
    {
        int heroSpeed, muttaFuckaX, muttaFuckaY, muttaFucka2X, muttaFucka2Y, score;
        bool heroup, herodown, heroleft, heroright, isHeroDead;

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();

            resetGame();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                heroup = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                herodown = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                heroleft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                heroright = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                heroup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                herodown = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                heroleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                heroright = false;
            }
            if (e.KeyCode == Keys.Enter && isHeroDead == true)
            {
                resetGame();
            }
        }      
     
        private void timer1_Tick(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + score;

            if (heroleft == true)
            {
                hero.Left -= heroSpeed;
            }
            if (heroright == true)
            {
                hero.Left += heroSpeed;
            }
            if (herodown == true)
            {
                hero.Top += heroSpeed;
            }
            if (heroup == true)
            {
                hero.Top -= heroSpeed;
            }

            if (hero.Left < -10)
            {
                hero.Left = 680;
            }
            if (hero.Left > 680)
            {
                hero.Left = -10;
            }

            if (hero.Top < -10)
            {
                hero.Top = 550;
            }
            if (hero.Top > 550)
            {
                hero.Top = 0;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "diamond" && x.Visible == true)
                    {
                        if (hero.Bounds.IntersectsWith(x.Bounds))
                        {
                            score += 1;
                            x.Visible = false;
                        }
                    }

                    if ((string)x.Tag == "fire")
                    {
                        if (hero.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameOver("Qazim's ass is on fire!");
                        }
                    }

                    if ((string)x.Tag == "evil")
                    {
                        if (hero.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameOver("Do not hurt Qazim no more!");
                        }
                    }
                }
            }
            
            muttaFucka.Left -= muttaFuckaX;
            muttaFucka.Top -= muttaFuckaY;

            if (muttaFucka.Top < 0 || muttaFucka.Top > 550)
            {
                muttaFuckaY = -muttaFuckaY;
            }

            if (muttaFucka.Left < 0 || muttaFucka.Left > 675)
            {
                muttaFuckaX = -muttaFuckaX;
            }

            muttaFucka2.Left -= muttaFucka2X;
            muttaFucka2.Top -= muttaFucka2Y;

            if (muttaFucka2.Top < 0 || muttaFucka2.Top > 550)
            {
                muttaFucka2Y = -muttaFucka2Y;
            }

            if (muttaFucka2.Left < 0 || muttaFucka2.Left > 675)
            {
                muttaFucka2X = -muttaFucka2X;
            }

            if (score == 4)
            {
                gameOver("Victory shall be Qazim's!");
                fire16.Image = Properties.Resources.sexy2;
                fire17.Image = Properties.Resources.sexy2;
                fire18.Image = Properties.Resources.sexy2;
                fire19.Image = Properties.Resources.sexy2;
               
            }
        }
               
        private void resetGame()
        {
            fire16.Image = Properties.Resources.fire;
            fire17.Image = Properties.Resources.fire;
            fire18.Image = Properties.Resources.fire;
            fire19.Image = Properties.Resources.fire;


            txtScore.Text = "Score: 0";
            score = 0;

            muttaFuckaX = 8;
            muttaFuckaY = 8;
            muttaFucka2X = 4;
            muttaFucka2Y = 5;
            heroSpeed = 8;

            isHeroDead = false;

            hero.Left = 30;
            hero.Top = 45;

            muttaFucka.Left = 525;
            muttaFucka.Top = 235;

            muttaFucka2.Left = 129;
            muttaFucka2.Top = 360;

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    x.Visible = true;
                }
            }

            timer1.Start();
        }

        private void gameOver(string message)
        {
            isHeroDead = true;
            
            timer1.Stop();

            txtScore.Text = "Score: " + score + Environment.NewLine + message;
        }
    }
}
