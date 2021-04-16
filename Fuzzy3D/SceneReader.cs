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
    public class SceneReader : SceneReaderModule{
        internal override object run()
        {
            //Add the object to the scene
            scene.addObject(templates[0], new Vector3(0, 0, 0));
            //scene.addObject(templates[0], new Vector3(2, 2, 2));
           
          
            if (Fuzzy3D.activeCamera == null)
            {
                //Add a camera to the scene if there isn't one
                FCamera cam = new FCamera(new Vector3(-2, .5f, .5f), .5);
                cam.active = true;
                scene.members.Add(cam);
            }
            else
            {
                //Push the already active camera to the scene members
                scene.members.Add(Fuzzy3D.activeCamera);
            }
            
            
            return (base.run());
        }
    }

    public class MultiSceneReader : SceneReaderModule
    {
        internal override object run()
        {
            
            //Add the object to the scene
            for(int i = 0;  i<templates.Count; i++)
            {
               
                scene.addObject(templates[i], new Vector3(0, 0, 2 * i ));
               
            }



            if (Fuzzy3D.activeCamera == null)
            {
                //Add a camera to the scene if there isn't one
                FCamera cam = new FCamera(new Vector3(-2, .5f, .5f), .5);
                cam.active = true;
                scene.members.Add(cam);
            }
            else
            {
                //Push the already active camera to the scene members
                scene.members.Add(Fuzzy3D.activeCamera);
            }


            return (base.run());
        }
    }
}
