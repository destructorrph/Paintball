using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paintball
{
    public partial class Form1 : Form
    {
        private Target targ;
        private PaintballClass shot;
        private static Random rand = new Random();
        private const int SPEED = 5;
        private int shotCount;
        private double time;


        public Form1()
        {
            InitializeComponent();
            int x1 = rand.Next(pictureBox1.Width - 15);
            int y1 = rand.Next(pictureBox1.Height - 15);
            targ = new Target(new Rectangle(x1, y1, 15, 15), pictureBox1.ClientRectangle, Brushes.Black, SPEED);
            shot = new PaintballClass(Paintball.Properties.Resources.Gunshot, Paintball.Properties.Resources.Untitled);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            shot.displayShot(e.Graphics);
            targ.paint(e.Graphics);
            shot.displayLastShot(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            targ.move();
            time += 0.1;
            Refresh();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            time = 0;
            shotCount = 0;
            shot.reset();
            timer1.Enabled = true;
            shot.reset();

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            shot.playSound();
            shot.locateShot(e.Location);
            shotCount++;
            if(targ.isHit(e.Location))
            {
                Refresh();
                timer1.Enabled = false;
                MessageBox.Show("Shots Fired: " + Convert.ToString(shotCount) + "\nLife Span: " + Math.Round(time, 2) + " seconds", "Game Over!");

            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                timer1.Enabled = false;
            }
            else
            {
                timer1.Enabled = true;
            }
        }
    }
        
}

