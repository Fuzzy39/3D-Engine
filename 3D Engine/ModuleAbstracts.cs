using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3D_Engine
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

    abstract class ObjectReaderModule : Module
    {
        internal ObjectReaderModule()
        {

            base._moduleType = ModuleTypes.ObjectReader;
        }
        
        internal List<FTemplate> Templates = new List<FTemplate>();//<3DObject>;

        internal override void init(GraphicsDeviceManager graphics)
        {
            base.init(graphics);
            
            
        }

        internal override object run() 
        {
            return Templates;
        }

    }

    abstract class SceneReaderModule : Module
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

    abstract class ReferenceCreatorModule : Module
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

    abstract class TransformerModule : Module
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

    abstract class RasterizerModule : Module
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
            int Height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            int Width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            screenState = new Color[Width/Fuzzy3D.scaleFactor, Height/Fuzzy3D.scaleFactor];
        }



        internal override object run()
        {
            
            return screenState;
        }
    }
    abstract class WireFrameModule : Module
    {
        internal Color[,] ScreenState;

        internal override void init(GraphicsDeviceManager graphics)
        {
            base.init(graphics);
            base._moduleType = ModuleTypes.Rasterizer;

            //This needs to get screen size...
            int Height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            int Width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            ScreenState = new Color[Width, Height];
        }



        internal override object run()
        {
            
            return ScreenState;
        }
    }
    // And when the core module is more complete, Secondary modules should be added.


}
