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
    internal class SceneReader : SceneReaderModule{
        internal override object run()
        {
            scene.addObject(templates[0], new Vector3(0, 0, 0));
            //scene.addObject(templates[0], new Vector3(2, 2, 2));
           
          
            if (Fuzzy3D.activeCamera == null)
            {
                FCamera cam = new FCamera(new Vector3(-2, .5f, .5f), .5);
                cam.active = true;
                scene.members.Add(cam);
            }
            else
            {
                scene.members.Add(Fuzzy3D.activeCamera);
            }
            
            
            return (base.run());
        }
    }
}
