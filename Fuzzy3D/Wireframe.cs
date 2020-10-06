using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.ComponentModel;

using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;

namespace Fuzzy3D
{
    internal class WireFrame : WireFrameModule
    {
        Color linecolor = new Color(16, 64, 80);
        private void Bresenham(int x, int y, int x2, int y2)
        {

            
                int w = x2 - x;
                int h = y2 - y;
                int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
                if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
                if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
                if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
                int longest = Math.Abs(w);
                int shortest = Math.Abs(h);
                if (!(longest > shortest))
                {
                    longest = Math.Abs(h);
                    shortest = Math.Abs(w);
                    if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                    dx2 = 0;
                }
                int numerator = longest >> 1;
                for (int i = 0; i <= longest; i++)
                {
                    if (x >= 0 & y >= 0 & x < ScreenState.GetLength(1) & y < ScreenState.GetLength(1))
                    {
                        ScreenState[x, y] = linecolor;
                    }
                    numerator += shortest;
                    if (!(numerator < longest))
                    {
                        numerator -= longest;
                        x += dx1;
                        y += dy1;
                    }
                    else
                    {
                        x += dx2;
                        y += dy2;
                    }
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
                            for(int vertY= (int)((A.Y<B.Y)?A.Y:B.Y); vertY< (int)((A.Y > B.Y) ? A.Y : B.Y); vertY++)
                            {
                                ScreenState[(int)A.X, vertY] = linecolor;
                            }
                        }
                        //Bresenham( (int)(A.X<B.X?A.X:B.X), (int)(A.X < B.X ? A.Y : B.Y), (int)(A.X > B.X ? A.X : B.X), (int)(A.X > B.X ? A.Y : B.Y));
                        Bresenham((int)A.X, (int)A.Y, (int)B.X, (int)B.Y);
                        int x = (int)A.X;
                        int y = (int)A.Y;
                        if (x >= 0 & y >= 0 & x < ScreenState.GetLength(1) & y < ScreenState.GetLength(1))
                        {
                            ScreenState[(int)x, (int)y] = Color.White;
                           
                        }
                        x = (int)B.X;
                        y = (int)B.Y;
                        if (x >= 0 & y >= 0 & x < ScreenState.GetLength(1) & y < ScreenState.GetLength(1))
                        {
                            ScreenState[(int)x, (int)y] = Color.White;

                        }
                    }

                }
            }

            
            return base.run();
        }
    }
}
