using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3D_Engine
{

    /* What's This?
     * -------------------------
     * This file will eventually contain The components of the core module.
     * Simple enough, I think.
     * Only module is here for now.
     */
    enum ModuleTypes
    {
        ObjectReader,
        SceneReader,
        ReferenceCreator,
        Transformer,
        Rasterizer,
        OcclusionEngine,
        TextureMapper,
        LightingEngine
    }

    abstract class Module // I'm not 100% sure weather this should be an interface or abstract class...
    {
        // This is private to set and public to get.
        internal ModuleTypes _moduleType;
        public ModuleTypes moduleType
        {
            get { return this._moduleType; }
    
        }

        internal GraphicsDeviceManager graphics;
        internal virtual void init( GraphicsDeviceManager graphics )
        {
            this.graphics = graphics;
        }
        
        // For when the module is run. Most will work once per frame, but some might run only on program init.

        // Aparently there is a way to have multiplle return types: ( int name, string name ) 
        // but then it requires you to return both, so we're using object as a stand in for anything.
        internal abstract object run();

      
    }

  


}
