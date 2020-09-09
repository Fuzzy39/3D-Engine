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


    internal class FPolygon
    {
        // okay, this should be pretty simple.
        // A polygon consists of 3 vectors, a base color, and texture.
        // We could get deeper into the weeds about this stuff, but we won't get there.
        internal Vector3[] verticies; // public is fine, right
        internal Color color;
        internal Texture texture;

        public FPolygon (Vector3[] vertices, Color color)
        {
            if(vertices.Length!=3)
            {
                throw new System.Exception("Polygons require 3 Points!");
            }

            this.verticies = vertices;
            this.color = color;
            this.texture = null; // in case that wasn't already explicit, it's null.
        }

        public FPolygon(Vector3[] vertices, Color color, Texture texture)
        {
            if (vertices.Length != 3)
            {
                throw new System.Exception("Polygons require 3 Points!");
            }

            this.verticies = vertices;
            this.color = color;
            this.texture = texture; 
        }



        public void translate(float byX, float byY, float byZ )
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

    internal class FTemplate
    {
        internal string name;
        internal List<FPolygon> polygons;
        
        internal FTemplate(List<FPolygon> input)
        {
            polygons = input;
            
        }
    }

    internal class FObject
    {
        // HEY FOBJECT NEEDS A REFERENCE TO THE TEMPLATE IT IS COPYING.

        private FTemplate template;
        internal Vector3 position = new Vector3();
        internal double scale;

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
            this.scale = scale;

        }

        internal List<FPolygon> getGeometry()
        {
            return template.polygons;
        }

        
    }

  


}
