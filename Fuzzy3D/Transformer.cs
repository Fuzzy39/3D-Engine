using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.ComponentModel;


namespace Fuzzy3D
{
    public class Transformer : TransformerModule
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
                            Fuzzy3D.activeCamera = (FCamera)URS[camera];
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
            double camRot = ((FCamera)URS[camera]).Rotation;

            //Looping through the URS to set to the LRS
            //Console.WriteLine("Before Translation: " + URS.Count);
            List<FSceneMember> MRS = new List<FSceneMember>();
            for (int y = 0; y < URS.Count; y++)
            {

                if (URS[y] is FPolygon)
                {
                    Vector3[] prev = ((FPolygon)URS[y]).verticies;
                    Vector3[] next = { Vector3.Subtract(prev[0], cam), Vector3.Subtract(prev[1], cam), Vector3.Subtract(prev[2], cam) };
                   
                    MRS.Add(new FPolygon(next, ((FPolygon)URS[y]).color));
                    continue;
                }
                if (URS[y] is FCamera)
                {
                    //Console.WriteLine("WHat the fuck!");
                  
                    Vector3 prev = ((FCamera)URS[y]).position;
                    MRS.Add( new FCamera( Vector3.Subtract(prev,cam), ((FCamera)URS[y]).FOV));
                    continue;
                }

                throw new Exception("Transformer does not currently handle Lightsources!");
            }

            // Do the same but for rotation.
            // Note that this must occur after translation; It is dependent on it.
         
            for (int y = 0; y < MRS.Count; y++)
            {
              
                if (MRS[y] is FPolygon)
                {
                   
                 
                    Vector3[] prev = ((FPolygon)MRS[y]).verticies;
                    Vector3[] next = {Rotate2D(prev[0], camRot), Rotate2D(prev[1], camRot), Rotate2D(prev[2], camRot) };

                    
                    // Now we check about surface normal
                    if (((FPolygon)MRS[y]).surfaceNormal == null)
                    {
                        LRS.Add(new FPolygon(next, ((FPolygon)MRS[y]).color));
                    }
                    else
                    {
                        FPolygon poly = new FPolygon(next, ((FPolygon)MRS[y]).color);
                        poly.surfaceNormal = ((FPolygon)MRS[y]).surfaceNormal;

                        if ( Math.Abs(Math.Acos(poly.surfaceNormal.X))>Math.PI )
                        {
                            LRS.Add(poly);
                        }

                    }
                    
              
                    continue;
                }
                if (MRS[y] is FCamera)
                {
              
                    
                    Vector3 prev = ((FCamera)MRS[y]).position;
                  
                    LRS.Add(new FCamera ( Rotate2D(prev, camRot), ((FCamera)MRS[y]).FOV));
                    
                    continue;
                }

                throw new Exception("Transformer does not currently handle: "+URS[y].GetType());
            }
            //Console.WriteLine("After Rotation: " + LRS.Count);
            return base.run();
        }

        private Vector3 Rotate2D( Vector3 point, double Rotation ) // Where rotation is in pi radians.
        {
            double X = point.X;
            double Y = point.Z;
            double RadRot = Rotation / (Math.PI );
            double NewX = (X * Math.Cos(RadRot)) - (Y * Math.Sin(RadRot));
            double NewY = (X * Math.Sin(RadRot)) + (Y * Math.Cos(RadRot));
            return (new Vector3((float)NewX, point.Y, (float)NewY));
        }
    }
}