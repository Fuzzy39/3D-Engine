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
    class Transformer : TransformerModule
    {
        internal override object run()
        {
            //check if multiple cameras are active
            //This variable checks for cameras in the scene if it is aready set then there is multiple cameras in the scene if
            //at the end of this is still -1 then there aren't any both cases we would return an error
            int camera = -1;
            for(int x = 0; x < URS.Count; x++)
            {
                if(URS[x] is FCamera)
                {
                    if (((FCamera)URS[x]).active)
                    {
                        if (camera == -1)
                        {
                            camera = x;
                        }
                        else
                        {
                            //Throwing an error that I found in an example of how to use throw as I am rather new to it
                            throw new IndexOutOfRangeException();
                        }
                    }
                }
            }
            if(camera == -1)
            {
                throw new IndexOutOfRangeException();
            }

            Vector3 cam = ((FCamera)URS[camera]).position;
            //Looping through the URS to set to the LRS
            for (int y = 0; y < URS.Count; y++)
            {

                if (URS[y] is FPolygon)
                {
                    Vector3[] prev = ((FPolygon)URS[y]).verticies;
                    Vector3[] next = { Vector3.Subtract(prev[0], cam), Vector3.Subtract(prev[1], cam), Vector3.Subtract(prev[2], cam) };
                    LRS.Add(new FPolygon(next, ((FPolygon)URS[y]).color));
                    continue;
                }
                if (URS[y] is FCamera)
                {
                    Vector3 prev = ((FCamera)URS[y]).position;
                    LRS.Add( new FCamera(Vector3.Subtract(prev,cam), ((FCamera)URS[y]).FOV));
                    continue;
                }

                throw new Exception("Transformer does not currently handle Lightsources!");
            }
            return base.run();
        }
    }
}