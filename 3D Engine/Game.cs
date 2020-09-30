using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3D_Engine
{
    /*
     * What's This?
     * ---------------------------
     * This file contains the 'game' that is using our 3D Engine. 
     * I've called the engine Fuzzy3D ( That can be changed, If you want.  )
     * Right now there isn't much to see, just the basics and a few lines to initialize the 3D engine.
     * We don't even try to render anything, because there's no engine, and it's made to crash, currently.
     * The Core module of the engine is located in Fuzzy3D.cs
     * cool, right?
     * no? whatever.
     */

   




    public class Game : Microsoft.Xna.Framework.Game
    {

        InputHelper inputHelper = new InputHelper();
        // The actual class that I was refering to above.

        // Monogame kinda requires these.
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        
        public Game()
        {
            // The constructor. It contains some basic setup.
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            // Thanks, monogame, we'll need this note.

            _graphics.PreferredBackBufferWidth = 600; 
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();
           
            Module[] moduleSetup = { new ObjectReader(), new SceneReader(), new basicReferenceCreator(), new Transformer(), new BasicRasterizer(), new WireFrame()};
            Console.WriteLine(moduleSetup[0].moduleType);
            Fuzzy3D.initialize(moduleSetup, _graphics, GraphicsDevice);
            base.Initialize();
        }


        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            inputHelper.Update();
            if (inputHelper.IsKeyDown(Keys.W))
            {
                Fuzzy3D.activeCamera.translateRelative(new Vector3(.05f, 0, 0));
            }

            if (inputHelper.IsKeyDown(Keys.A))
            {
                Fuzzy3D.activeCamera.translateRelative(new Vector3(0, 0, -.05f));
            }

            if (inputHelper.IsKeyDown(Keys.S))
            {
             
                Fuzzy3D.activeCamera.translateRelative(new Vector3(-.05f, 0, 0));
            }

            if (inputHelper.IsKeyDown(Keys.D) )
            {
                Fuzzy3D.activeCamera.translateRelative(new Vector3(0, 0, .05f));
            }

            if (inputHelper.IsKeyDown(Keys.LeftShift))
            {

                Fuzzy3D.activeCamera.translateRelative(new Vector3(0, .05f, 0));
            }

            if (inputHelper.IsKeyDown(Keys.LeftControl))
            {
                Fuzzy3D.activeCamera.translateRelative(new Vector3(0, -.05f, 0));
            }

            if (inputHelper.IsKeyDown(Keys.Left))
            {
                Fuzzy3D.activeCamera.Rotation += .05f;
            }

            if (inputHelper.IsKeyDown(Keys.Right))
            {
                Fuzzy3D.activeCamera.Rotation-= .05f;
            }

            if (inputHelper.IsMouseWheelScrolledUp())
            {
                Fuzzy3D.activeCamera.FOV += .05;
              
            }
            if (inputHelper.IsMouseWheelScrolledDown())
            {
                Fuzzy3D.activeCamera.FOV -= .05;
                
            }
            // TODO: Add your update logic here
            // We won't need this, at least not yet.

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.PowderBlue);
            // This is were the rendering function of the 3d engine should go, but it would cause a crash, 
            // as none of the manditory modules are there.
            // Fuzzy3D.Render();

            Fuzzy3D.Render(_spriteBatch);
            base.Draw(gameTime);
        
        }
    }
}
