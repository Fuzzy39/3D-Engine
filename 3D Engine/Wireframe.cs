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
        private void Bresenham(int x, int y, int x2, int y2)
        {
            

            int dx = x2 - x;
            int dy = y2 - y;
            int D = 2 * dy - dx;
            int j = y;

            for (int i = x; i < x2; i++)
            {
                
                try
                { 
                    ScreenState[i, j] = new Color(50, 50, 50);
                  
                    if (D > 0)
                    {
                        j = j + 1;
                        D = D - 2 * dx;
                    }
                }
                catch
                {
                    Console.WriteLine("WireFrame: Something's off..."); 
                }
                D = D + 2 * dy;
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
