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

    /* What's This?
     * -------------------------
     * This file will eventually contain The components of the core module.
     * Simple enough, I think.
     * Only module is here for now.
     */
    public enum ModuleTypes
    {
        ObjectReader,
        SceneReader,
        ReferenceCreator,
        Transformer,
        Rasterizer,
        WireFrame,
        OcclusionEngine,
        TextureMapper,
        LightingEngine,
  
    }

    public abstract class Module // I'm not 100% sure weather this should be an interface or abstract class...
    {
        
        protected ModuleTypes _moduleType;
        public ModuleTypes moduleType
        {
            get { return _moduleType; }
        }

    internal GraphicsDeviceManager graphics;
        protected internal virtual void init( GraphicsDeviceManager graphics )
        {
            this.graphics = graphics;
        }
        
        // For when the module is run. Most will work once per frame, but some might run only on program init.

        // Aparently there is a way to have multiplle return types: ( int name, string name ) 
        // but then it requires you to return both, so we're using object as a stand in for anything.
        protected internal abstract object run();

      
    }


    public class FPolygon : FSceneMember
    {
        // okay, this should be pretty simple.
        // A polygon consists of 3 vectors, a base color, and texture.
        // We could get deeper into the weeds about this stuff, but we won't get there.

        // the user should not be able to change these at a whim, so they are internal
        internal Vector3[] verticies; 
        internal Color color;
        internal Texture texture;
        internal Vector2[] screenVerticies = { new Vector2(-1,-1), new Vector2(-1, -1) , new Vector2(-1, -1)};

        internal FPolygon (Vector3[] vertices, Color color)
        {
            if(vertices.Length!=3)
            {
                throw new System.Exception("Polygons require 3 Points!");
            }

            this.verticies = vertices;
            this.color = color;
            this.texture = null; // in case that wasn't already explicit, it's null.
        }

        internal FPolygon(Vector3[] vertices, Color color, Texture texture)
        {
            if (vertices.Length != 3)
            {
                throw new System.Exception("Polygons require 3 Points!");
            }

            this.verticies = vertices;
            this.color = color;
            this.texture = texture; 
        }



        internal void translate(float byX, float byY, float byZ )
        {
            for(int i = 0; i<verticies.Length;i++)
            {
                verticies[i].X += byX;
                verticies[i].Y += byY;
                verticies[i].Z += byZ;

            }
        }
    }


    enum Templates
    {
        // I think this should be empty.  
    }


    internal class FTemplate
    {
        internal string name="invalid";
        internal readonly List<FPolygon> polygons; // shouldn't change
        
        internal FTemplate(List<FPolygon> input, String name)
        {
            polygons = input;
            this.name = name;
            
        }
    }

    internal class FObject : FSceneMember
    {
        // HEY FOBJECT NEEDS A REFERENCE TO THE TEMPLATE IT IS COPYING.

        internal FTemplate template;
        internal Vector3 position = new Vector3();
        internal double scale;

        // Don't call these! call from scene!
        internal FObject(FTemplate shape, Vector3 position)
        {
            template = shape; // we want a record of the template, not sure how useful this is, but meh.
            this.position = position;
            scale = 1;

        }

        internal FObject(FTemplate shape, Vector3 position, double scale)
        {
            template = shape; // we want a record of the template, not sure how useful this is, but meh.
            this.position = position;
            if(scale<0)
            {
                throw new System.Exception("Objects cannot be negatively scaled!");
            }
            this.scale = scale;

        }

        internal FTemplate getGeometry()
        {
            return template;
        }

        
    }

  
    internal class FCamera : FSceneMember
    {
        internal double FOV; // Field of view, in degrees.
        internal Vector3 position;
        internal bool active; // whether the camera is the one being piped to the screen.
        public double Rotation = 0; // in Pi radians, where 2 is a full rotation.
        // And some variable for angle, that we will currently ignore.

        internal FCamera(Vector3 position, double FOV)
        {
         
            this.FOV = FOV;
            this.position = position;
            this.active = true;
        }

        public void translateRelative(Vector3 toTranslate)
        {
            double X = toTranslate.X;
            double Z = toTranslate.Z;
            double RadRot = -Rotation / (Math.PI);
            double NewX = (X * Math.Cos(RadRot)) - (Z * Math.Sin(RadRot));
            double NewZ = (X * Math.Sin(RadRot)) + (Z * Math.Cos(RadRot));

            position = Vector3.Add(position, new Vector3((float)NewX, toTranslate.Y, (float)NewZ));
        }
    }

    internal class FLightSource : FSceneMember
    { 
        FLightSource()
        {
            throw new Exception("Light sources have not been implemented.");
        }
    }

    internal interface FSceneMember{ }

    internal class FScene
    {
        internal List<FSceneMember> members = new List<FSceneMember>();
        
        internal void addObject (FTemplate shape, Vector3 position, double scale)
        {
            members.Add(new FObject(shape, position, scale));
        }

        internal void addObject(FTemplate shape, Vector3 position)
        {
            members.Add(new FObject(shape, position));
        }

    }

 

}
