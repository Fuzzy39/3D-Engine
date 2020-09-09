using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3D_Engine
{
    static class Fuzzy3D
    {



        /* What's This?
         * ----------------------
         * If the name didn't clue you on, This is the core of Fuzzy3D!
         * This is the primary, if not, only part of the engine the user will have to interact with.
         * Probably. Time will tell on that, but that's is the plan.
         * 
         * I could type more, but I don't have a very conncrete concept of how this will work.
         * I should figure that out
         * 
         * 
         * NOTE: All of the errors written to the console should be replaced with throwing exceptions once this thing works.
         */



        private static bool initalized = false; // The engine must be initalized to be uzed.

        private const int MAX_MODULES = 8;
        private const int MIN_MODULES = 5; // Note that no optional Modules can exist between or before manditory ones.

        private static Vector2 screenSize;
        public static void initialize(Module[] setup, GraphicsDeviceManager graphics)
        {
            // Basically, for the engine to work, the user has to decide the modules that it will recive.

            // First, check that the core moudule is intact. ( it isn't there isn't anything here )
            string[] requiredTypes = { "Module","ModuleTypes","FScene","FTemplate","Templates", "FObject", "FPolygon", "FCamera", "FLightSource" };
            int failedTypes = 0;

            // loop through and make sure all required types exist.
            for(int i=0; i<requiredTypes.Length; i++)
            {
                if (Type.GetType("_3D_Engine." + requiredTypes[i])==null)
                {
                    failedTypes++;
                    Console.WriteLine("Fuzzy3D: Fatal Error: Core module is missing components: Cannot find type " + requiredTypes[i]);
                } 
            }

            // If something is broken, we shouldn't continue.
            if( failedTypes!=0)
            {
                Console.WriteLine("Fuzzy3D: Core module init failed. " + (requiredTypes.Length - failedTypes) + " of " + requiredTypes.Length+" Components were found.");
                return;
            }

           

            


            //Finished init of core module.
            Console.WriteLine("Fuzzy3D: Core module initalized. Initalizing other Modules.");

            

            // Now find modules.
            // First we have to figure out if the engine has been supplied with the required modules
            
            // If the array is too small to fit all required modules, or larger than the amount of total modules, we fail init.
            if(setup.Length < MIN_MODULES || setup.Length > MAX_MODULES ) // These numbers shouldn't change, but this is kind of bad practice.
            {
                Console.WriteLine("Fuzzy3D: Module init failed. The module setup is incorrectly formatted.");
                return;
            }


            // Now we look to see which modules the user has included.
            // The goal here:
            // All 5 of the required modules must be present.
            // No duplicates of any type must be present.
            // We need to come out of this knowing what all of the modules are.

            // So we should loop through the setup.

            Module[] modules = new Module[MAX_MODULES];
            foreach (ModuleTypes i in Enum.GetValues(typeof(ModuleTypes)))
            {
                if ((int)i <= MIN_MODULES) // If it is a primary module...
                {
                    if (setup[(int)i] != null && setup[(int)i].moduleType == i) // and it is the proper type... and not null...
                    {
                        modules[(int)i] = setup[(int)i];
                    }
                    else
                    {
                        Console.WriteLine("Fuzzy3D: Module init failed. A primary Module is of the wrong type or not present.");
                        return;
                    }
                }
                else
                {

                    // seconday modules are allowed to be null.
                    if(setup[(int)i] != null)
                    {
                        modules[(int)i] = null;
                        continue;
                    }

                    if ( setup[(int)i].moduleType == i) // and it is the proper type...
                    {
                        modules[(int)i] = setup[(int)i];
                    }
                    else
                    {
                        Console.WriteLine("Fuzzy3D: Module init failed. A secondary Module is of the wrong type.");
                        return;
                    }
                }

                // intitialize all of the modules
                modules[(int)i].init(graphics);

            }
            initalized = true;



            // Now we need to initalize the objects.
            modules[(int)ModuleTypes.ObjectReader].run();


        }

        public static void Render()
        {
            if(!initalized)
            {
                throw new Exception("Fuzzy3D has not been properly initalized. Have you called Fuzzy3D.initalize?");
            }

            Console.WriteLine("Rendering code has not yet been written.");
        }

    }
}