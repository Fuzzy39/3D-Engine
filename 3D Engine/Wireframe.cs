using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.ComponentModel;
using _3D_Engine;

namespace _3D_Engine
{
    class WireFrame : WireFrameModule
    {
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

                        if(A.X==-1 || B.X==-1) // check if it's undefined.
                        {
                          
                            continue;
                        }
                     
                        // Now we can draw the line.
                        //yeah...
                        //grab the rise and run.
                        double run = (int)Math.Abs(A.X - B.X);
                        double rise = (int)Math.Abs(A.Y - B.Y);
                        //now what?
                        // if it is vertical, it's simple.
                        if(A.X==B.X)
                        {
                            if(A.Y==B.Y) // the points are the same.
                            {
                                continue;
                            }

                            for(int y = (int)(A.Y<B.Y?A.Y:B.Y); y< (int)(A.Y > B.Y ? A.Y : B.Y);y++)
                            {
                                ScreenState[(int)A.X, y] = Color.White;
                            }

                        }
                        // plot it like a function?
                        int lesserX = (int)(A.X < B.X ? A.X : B.X);
                        int greaterX = (int)(A.X > B.X ? A.X : B.X);
                        for (int x = lesserX; x< greaterX; x++ )
                        {
                            //(
                            int y =(int)((lesserX == A.X ? A.Y : B.Y)  +((rise * (x - lesserX)) / (run)));
                            ScreenState[x, y] = Color.White;
                           
                        }

                        ScreenState[(int)A.X,(int)A.Y] = Color.Red;
                        ScreenState[(int)B.X, (int)B.Y] = Color.Red;
                    }
                    
                }
            }

            
            return base.run();
        }
    }
}
