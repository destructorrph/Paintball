using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Paintball
{
    class Target
    {
        private static Random ifRand = new Random();
        private Brush myBrush;
        private Rectangle myRectangle;
        private Rectangle myBounds;
        private int dx, dy;
        private int willChangeDirection;
        private int changeDirection;
        private int chooseChangeDirection;


        public Target(Rectangle aRectangle, Rectangle aBounds, Brush aBrush, int aSpeed)
        {
            myBrush = aBrush;
            myRectangle = aRectangle;
            dx = dy = aSpeed;
            myBounds = aBounds;
        }

        public void paint(Graphics g)
        {
            g.FillRectangle(Brushes.Black, myRectangle);
        }

        public bool isHit(Point location)
        {
            return myRectangle.Contains(location);
        }

        public void move()
        {
            myRectangle.Offset(dx, dy);

            if (myRectangle.Bottom >= myBounds.Bottom ||    //The next 2 if statements make sure it doesent go out of bounds
                myRectangle.Top <= myBounds.Top)
            {
                dy = -dy;
            }

            if (myRectangle.Left <= myBounds.Left ||
                myRectangle.Right >= myBounds.Right)
            {
                dx = -dx;
            }


            if (myRectangle.X <= myBounds.X || myRectangle.Y <= myBounds.Y || myRectangle.X >= myBounds.Right || myRectangle.Y >= myBounds.Bottom)
            {

            }
            else { 
            
            
            willChangeDirection = ifRand.Next(4);

            if (willChangeDirection == ifRand.Next(4))      //Decides if its even going to change direction
            {
                changeDirection = ifRand.Next(2);

                    if (changeDirection == ifRand.Next(2))  //Decides what direction to change to
                    {

                        chooseChangeDirection = ifRand.Next(2);


                        if (chooseChangeDirection == 0)
                        {

                        }
                        else if (chooseChangeDirection == 1)
                        {
                            dx = -dx;
                        }
                        else if (chooseChangeDirection == 2)
                        {
                            dy = -dy;
                        }
                    }

                }
            }
                
        }
    }
}
