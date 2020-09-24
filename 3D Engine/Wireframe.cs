using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.ComponentModel;
using _3D_Engine;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;

namespace _3D_Engine
{
    class WireFrame : WireFrameModule
    {
        //How does this work? hell if I know!
        private void Bresenham(int x0, int y0, int x1, int y1)
        {
            if (Math.Abs(y1 - y0) < Math.Abs(x1 - x0))
            {
                low(x0, y0, x1, y1);
            }
            else
            {
                if (y0 > y1)
                {
                    high(x1, y1, x0, y0);
                }
                else
                {
                    high(x0, y0, x1, y1);
                }
            }
         }
        
        private void low(int x0, int y0, int x1, int y1)
        { 

            int dx = x1 - x0;
            int dy = y1 - y0;
            int yi = 1;
            if (dy < 0)
            {
                yi = -1;
                dy = -dy;
            }
            int D = (2 * dy) - dx;
            int y = y0;

            for (int x = x0; x < x1; x++)
            {
                ScreenState[x, y] = new Color(50, 50, 50);
                if (D > 0)
                {
                    y = y + yi;
                    D = D + (2 * (dy - dx));
                }
                else
                {
                    D = D + 2 * dy;
                }
            }
            
        }

        private void high(int x0, int y0, int x1, int y1)
        {

            int dx = x1 - x0;
            int dy = y1 - y0;
            int xi = 1;
            if (dx < 0)
            {
                xi = -1;
                dx = -dx;
            }
            int D = (2 * dx) - dy;
            int x = x0;
            try
            {
                for (int y = y0; y < y1; x++)
                {
                    ScreenState[x, y] = new Color(50, 50, 50);
                    if (D > 0)
                    {
                        x = x + xi;
                        D = D + (2 * (dx - dy));
                    }
                    else
                    {
                        D = D + 2 * dx;
                    }
                }
            }
            catch
            {
                Console.WriteLine("This catch statement prevents everything from breaking. Something is clearly wrong...");
            }

        }
        internal override object run()
        {
            
            // first of all, make the screen black:
            for (int x = 0; x < ScreenState.GetLength(0); x++)
            {
                for (int y = 0; y < ScreenState.GetLength(1); y++)
                {

                    ScreenState[x, y] = Color.Black;

                }
            }

            for (int i = 0; i < LRS.Count; i++)
            {
                
                if (LRS[i] is FPolygon)
                {
                    FPolygon poly = (FPolygon)LRS[i];
                    for (int j = 0;j < poly.verticies.Length;j++)
                    {
                        // get the 2 vector3s we will be drawing the line from.
                        Vector2 A = poly.screenVerticies[j];
                        Vector2 B;
                        if (j == poly.verticies.Length - 1)
                        {
                            B = poly.screenVerticies[0];
                        }
                        else
                        {
                            B = poly.screenVerticies[j + 1];
                        }
                        if(A.X==-1||B.Y==-1)
                        {
                            continue;
                        }
                        if(A.X==B.X)
                        {
                            // okay, vertical line.
                            for(int y= (int)((A.Y<B.Y)?A.Y:B.Y); y< (int)((A.Y > B.Y) ? A.Y : B.Y); y++)
                            {
                                ScreenState[(int)A.X, y] = new Color(50, 50, 50);
                            }
                        }
                        //Bresenham( (int)(A.X<B.X?A.X:B.X), (int)(A.X < B.X ? A.Y : B.Y), (int)(A.X > B.X ? A.X : B.X), (int)(A.X > B.X ? A.Y : B.Y));
                        Bresenham((int)A.X, (int)A.Y, (int)B.X, (int)B.Y);
                        ScreenState[(int)A.X, (int)A.Y] = Color.White;
                        ScreenState[(int)B.X, (int)B.Y] = Color.White;
                    }
                    
                }
            }

            
            return base.run();
        }
    }
}
