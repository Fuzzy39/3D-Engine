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
    public class basicReferenceCreator : ReferenceCreatorModule
    {
        internal override object run()
        {
            
            // so we loop  through all objects in the scene:
            for(int i =0; i< scene.members.Count; i++)
            {
                // and find everything.
                FSceneMember member = scene.members[i];
                
                if(member is FPolygon)
                {
                    throw new Exception("Polygons should not be in scenes! Perhaps this rule is dumb, but that's not my discresion.");
                }

                if (member is FCamera || member is FLightSource)
                {
                    //Console.WriteLine(((FCamera)member).position.X);
                    URS.Add(member);
                    continue;
                }  
                
                if(member is FObject)
                {
                    
                    FObject fobject = (FObject)member; // member is now an FObject in the eyes of the law!
                    
                    for (int j = 0; j < fobject.template.polygons.Count; j++)
                    {
                        //Console.WriteLine("Hola: " + i + " poly " + j+":");
                        FPolygon poly = new FPolygon(fobject.template.polygons[j].verticies, fobject.template.polygons[j].color, fobject.template.polygons[j].surfaceNormal);
                       
                        
                            //poly.verticies[k] = Vector3.Add(poly.verticies[k], fobject.position);
                        FPolygon finalPoly = new FPolygon(new Vector3[] { Vector3.Add(poly.verticies[0], fobject.position), Vector3.Add(poly.verticies[1], fobject.position), Vector3.Add(poly.verticies[2], fobject.position) }, poly.color, poly.surfaceNormal);
                            //Console.WriteLine(poly.verticies[k].X + ", "+ poly.verticies[k].Y+", "+ poly.verticies[k].Z);
                        
                        
                        URS.Add(finalPoly);
                    }
                    continue;
                }

                throw new Exception("An unknown sceneMember has been given to basicReferenceCreator! how did this happen???");

            }
            //cool.
            
            return base.run();

        }
    }
}