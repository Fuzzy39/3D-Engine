using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Fuzzy3D
{
    /* What's this?
     * ---------------------
     * 
     * IMPORTANT NOTE: No actual module code goes here! read below.
     * 
     * 
     * This defines all of the modules in an abstract way.
     * this file only describes the features of each type of module, and not how they are supposed to implement these features.
     * This is to make it easier for different versions of modules to be swaped out for each other.
     * Yeah, makes sense, right?
     * If you aren't familiar with abstract classes, look them up.
     * 
     */

    public abstract class ObjectReaderModule : Module
    {
        protected internal ObjectReaderModule()
        {

            base._moduleType = ModuleTypes.ObjectReader;
        }
        
        //protected List<FTemplate> Templates = new List<FTemplate>();//<3DObject>;
        public List<FTemplate> Templates { get; protected set; } = new List<FTemplate>();
        internal override void init(GraphicsDeviceManager graphics)
        {
            base.init(graphics);
            
            
        }

        internal override object run() 
        {
            return Templates;
        }

    }

    public abstract class SceneReaderModule : Module
    {
        internal List<FTemplate> templates;
        internal FScene scene;
        internal SceneReaderModule()
        {
            base._moduleType = ModuleTypes.SceneReader;

        }
        internal override void init(GraphicsDeviceManager graphics)
        {
            base.init(graphics);


           scene=new FScene(/*stuff*/);
        }

        internal override object /*scene*/ run()
        {
            
          
            return scene;
        }



    }

    public abstract class ReferenceCreatorModule : Module
    {
        internal FScene scene;
        internal List<FSceneMember> URS; // Universal Referece System
        internal ReferenceCreatorModule()
        {

            base._moduleType = ModuleTypes.ReferenceCreator;
        }

        internal override void init(GraphicsDeviceManager graphics)
        {
            base.init(graphics);
          

            URS=new List<FSceneMember>(/*stuff*/); //< same thing
        }

        internal override object  run()
        {
            return URS;
            

        }
    }

    public abstract class TransformerModule : Module
    {
        internal List<FSceneMember> URS;
        internal List<FSceneMember> LRS; // Local Referece System
        internal TransformerModule()
        {
            base._moduleType = ModuleTypes.Transformer;
        }

        internal override void init(GraphicsDeviceManager graphics /*Scene URS*/)
        {
            base.init(graphics);
           
            
            LRS=new List<FSceneMember>();
        }

        internal override object /*ReferenceSystem*/ run()
        {
            
            return LRS;
        }
    }

    public abstract class RasterizerModule : Module
    {
        // I havent a clue what goes in here.
        internal List<FSceneMember> LRS;
        internal Color[,] screenState;
        internal RasterizerModule()
        {
            base._moduleType = ModuleTypes.Rasterizer;
        }

        internal override void init(GraphicsDeviceManager graphics)
        {
            base.init(graphics);
            

            //This needs to get screen size... 
            int Height = graphics.PreferredBackBufferHeight;
            int Width = graphics.PreferredBackBufferWidth;
           
            screenState = new Color[Width/Fuzzy3D.scaleFactor, Height/Fuzzy3D.scaleFactor];
        }



        internal override object run()
        {
            
            return screenState;
        }
    }
    public abstract class WireFrameModule : Module
    {
        internal List<FSceneMember> LRS;
        internal Color[,] ScreenState;

        internal WireFrameModule ()
        {
            base._moduleType = ModuleTypes.WireFrame;
        }

        internal override void init(GraphicsDeviceManager graphics)
        {
            base.init(graphics);


            //This needs to get screen size... 
            int Height = graphics.PreferredBackBufferHeight;
            int Width = graphics.PreferredBackBufferWidth;
           
            ScreenState = new Color[Width / Fuzzy3D.scaleFactor, Height / Fuzzy3D.scaleFactor];
        }



        internal override object run()
        {
            
            return ScreenState;
        }
        internal struct Line
        {
            internal Vector2 first;
            internal Vector2 second;
            internal Line(Vector2 first, Vector2 second)
            {
                this.first = first;
                this.second = second;
            }
        }
    }
    // And when the core module is more complete, Secondary modules should be added.


}
