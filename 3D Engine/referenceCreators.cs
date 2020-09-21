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
    class basicReferenceCreator : ReferenceCreatorModule
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
                    
                    URS.Add(member);
                    continue;
                }  
                
                if(member is FObject)
                {
                    FObject fobject = (FObject)member; // member is now an FObject in the eyes of the law!
                    for(int j = 0; j< fobject.template.polygons.Count; j++)
                    {
                        
                        FPolygon poly = fobject.template.polygons[j];
                        URS.Add(poly);
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