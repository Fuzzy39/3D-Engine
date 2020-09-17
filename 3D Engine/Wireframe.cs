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
            for(int x = 0; x < LRS.Count; x++)
            {
                if (LRS[x] is FPolygon)
                {
                    for(int y = 0; y < 3; y++)
                    {
                        //Draw line from point 0 to 1
                        
                        //Draw line from 1 to 2
                        //Draw ling from 2 to 0
                    }
                    continue;
                }
            }
            return base.run();
        }
    }
}
