using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Drawing;

namespace Paintball
{
    class PaintballClass
    {
        private SoundPlayer mySound;
        private Image myImage;

        public List<Point> shotLocation = new List<Point>();

        public PaintballClass (System.IO.Stream aSound, Image anImage)
        {
            mySound = new SoundPlayer();
            mySound.Stream = aSound;
            mySound.Load();

            myImage = anImage;
        }

        public void playSound()
        {
            mySound.Play();
        }
        
        public void displayLastShot(Graphics g)
        {
            if(shotLocation.Count >= 1)
            {
                 g.DrawImage(myImage, new Point( shotLocation.Last().X - 15, shotLocation.Last().Y - 15));
            }
        }
        
        public void locateShot(Point location)
        {
            shotLocation.Add(location);
        }

        public void reset()
        {
            shotLocation.Clear();
        }

        public void displayShot(Graphics g)
        {
            if (shotLocation.Count >= 1)
            {
                foreach (Point item in shotLocation)
                {
                    g.DrawImage(myImage, new Point(item.X - 15, item.Y - 15));
                }
            }
        }


    }
}
