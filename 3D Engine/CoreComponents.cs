﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Numerics;

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


    class FPolygon
    {
        // okay, this should be pretty simple.
        // A polygon consists of 3 vectors, a base color, and texture.
        // We could get deeper into the weeds about this stuff, but we won't get there.
        protected Vector3[] verticies; // public is fine, right
        protected Color color;
        protected Texture texture;

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
    }

    class FTemplate{
        protected string name;
        protected ArrayList<FPolygon> polygons;
    }

    class FObject{
        protected ArrayList<FPolygon> polygons;
        protected Vector3 origin_pos;
    }

  


}
