using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.IO;
using System.Data;
using Microsoft.Xna.Framework.Audio;

namespace Fuzzy3D
{
    public class ObjectReader : ObjectReaderModule
    {

        internal override object run()
        {

            /*
             * Hey! Just a future reminder!
             * Don't Repeat Yourself!
             * There was probably a way to do this ( with loops, for example ) where you don't need to write the same thing
             * 36 times.
             * It saves a bit of time.
             */
            //List<FPolygon> current_shape_holder = new List<FPolygon>();
            //Vector3[] current_polygon = new Vector3[3];

            //Add cube
            //Instead of creating 12 different variables for each triangle I just use the current polygon and reset it each time
            //Then I just push the polygon to the array of polygons which I can just to the templates
            //First triangle on the first yz plane
            /*
             current_polygon[0] = new Vector3(0, 0, 0);
             current_polygon[1] = new Vector3(0, 1, 0);
             current_polygon[2] = new Vector3(0, 0, 1);
             current_shape_holder.Add(new FPolygon(current_polygon, Color.Gray));
             current_polygon = new Vector3[3];
             //second triangle on the first yz plane
             current_polygon[0] = new Vector3(0, 1, 0);
             current_polygon[1] = new Vector3(0, 1, 1);
             current_polygon[2] = new Vector3(0, 0, 1);
             current_shape_holder.Add(new FPolygon(current_polygon, Color.Gray));
             current_polygon = new Vector3[3];
             //First triangle on the first xz plane
             current_polygon[0] = new Vector3(0, 0, 0);
             current_polygon[1] = new Vector3(1, 0, 0);
             current_polygon[2] = new Vector3(0, 0, 1);
             current_shape_holder.Add(new FPolygon(current_polygon, Color.Gray));
            current_polygon = new Vector3[3];

            //Second triangle on the first xz plane
            current_polygon[0] = new Vector3(1, 0, 1);
             current_polygon[1] = new Vector3(1, 0, 0);
             current_polygon[2] = new Vector3(0, 0, 1);
             current_shape_holder.Add(new FPolygon(current_polygon, Color.Gray));
            current_polygon = new Vector3[3];
            //First triangle on the first xy plane
            current_polygon[0] = new Vector3(0, 0, 0);
             current_polygon[1] = new Vector3(1, 0, 0);
             current_polygon[2] = new Vector3(0, 1, 0);
             current_shape_holder.Add(new FPolygon(current_polygon, Color.Gray));
            current_polygon = new Vector3[3];
            //Second triangle on the first xy plane
            current_polygon[0] = new Vector3(1, 1, 0);
             current_polygon[1] = new Vector3(1, 0, 0);
             current_polygon[2] = new Vector3(0, 0, 1);
             current_shape_holder.Add(new FPolygon(current_polygon, Color.Gray));

             //First triangle on the second yz plane
             current_polygon[0] = new Vector3(1, 1, 1);
             current_polygon[1] = new Vector3(1, 1, 0);
             current_polygon[2] = new Vector3(1, 0, 1);
             current_shape_holder.Add(new FPolygon(current_polygon, Color.Gray));
            current_polygon = new Vector3[3];
            //second triangle on the second yz plane
            current_polygon[0] = new Vector3(1, 0, 0);
             current_polygon[1] = new Vector3(1, 1, 0);
             current_polygon[2] = new Vector3(1, 0, 1);
             current_shape_holder.Add(new FPolygon(current_polygon, Color.Gray));
            current_polygon = new Vector3[3];
            //First triangle on the second xz plane
            current_polygon[0] = new Vector3(0, 1, 0);
             current_polygon[1] = new Vector3(1, 1, 0);
             current_polygon[2] = new Vector3(0, 1, 1);
             current_shape_holder.Add(new FPolygon(current_polygon, Color.Gray));
            current_polygon = new Vector3[3];
            //Second triangle on the second xz plane
            current_polygon[0] = new Vector3(1, 1, 1);
             current_polygon[1] = new Vector3(1, 1, 0);
             current_polygon[2] = new Vector3(0, 1, 1);
             current_shape_holder.Add(new FPolygon(current_polygon, Color.Gray));
            current_polygon = new Vector3[3];
            //First triangle on the second xy plane
            current_polygon[0] = new Vector3(0, 0, 1);
             current_polygon[1] = new Vector3(1, 0, 1);
             current_polygon[2] = new Vector3(0, 1, 1);
             current_shape_holder.Add(new FPolygon(current_polygon, Color.Gray));
            current_polygon = new Vector3[3];
            //Second triangle on the second xy plane
            current_polygon[0] = new Vector3(1, 1, 1);
             current_polygon[1] = new Vector3(1, 0, 1);
             current_polygon[2] = new Vector3(0, 1, 1);
             current_shape_holder.Add(new FPolygon(current_polygon, Color.Gray));
           */
            // finish up.
            /*
           current_polygon[0] = new Vector3(0, 0, 0);
            current_polygon[1] = new Vector3(0, 0, 1);
            current_polygon[2] = new Vector3(1, 0, .5f);
            current_shape_holder.Add(new FPolygon(current_polygon, Color.Gray));
            current_polygon = new Vector3[3];
            current_polygon[0] = new Vector3(0, 0, 0);
            current_polygon[1] = new Vector3(0, 0, 1);
            current_polygon[2] = new Vector3(0.5f, .866f, .5f);
            current_shape_holder.Add(new FPolygon(current_polygon, Color.Gray));
            current_polygon = new Vector3[3];
            current_polygon[0] = new Vector3(1, 0, .5f);
            current_polygon[1] = new Vector3(0, 0, 1);
            current_polygon[2] = new Vector3(0.5f, .866f, .5f);
            current_shape_holder.Add(new FPolygon(current_polygon, Color.Gray));
            current_polygon = new Vector3[3];
            current_polygon[0] = new Vector3(0, 0, 0);
            current_polygon[1] = new Vector3(1, 0, .5f);
            current_polygon[2] = new Vector3(0.5f, .866f, .5f);
            current_shape_holder.Add(new FPolygon(current_polygon, Color.Gray));

            //   current_shape_holder.Add(new FPolygon(current_polygon, Color.Gray));
            base.Templates.Add(new FTemplate(current_shape_holder, "Cube"));
         */
            return (base.run());
        }
    }

    public class FileObjectReader : ObjectReaderModule
    {

        internal override object run()
        {
            //For now just have one object
            const string file_name = "C:/Users/Owner/source/repos/qwerty4967/3D-Engine/Fuzzy3DModules/Monkey.stl";
            //Check to see if is good
            BinaryReader file_reader;
            List<FPolygon> polygons = new List<FPolygon>();
            
            try
            {
                file_reader = new BinaryReader(File.Open(file_name, FileMode.Open));
                file_reader.ReadBytes(80);//Skip the header which is useless to us
                ulong num_facets = file_reader.ReadUInt32();//get the number of facets
                //Console.WriteLine(num_facets);
                for(ulong counter = 0; counter < num_facets; counter++)//Loops through all of the facets
                {
                    //This code runs for each triangle which has 12, 4 byte float numbers the first three are for the normal of the triangle
                    //Have an array of vertices so it is easy to make an FPolygon from them
                    Vector3[] vertices = new Vector3[3];
                    //Get the normal, since it is only three things I will hard code
                    //Apparently ReadSingle returns a float so,
                    Vector3 normal = new Vector3(file_reader.ReadSingle(), file_reader.ReadSingle(), file_reader.ReadSingle());
                    vertices[0] = new Vector3(file_reader.ReadSingle(), file_reader.ReadSingle(), file_reader.ReadSingle());
                    vertices[1] = new Vector3(file_reader.ReadSingle(), file_reader.ReadSingle(), file_reader.ReadSingle());
                    vertices[2] = new Vector3(file_reader.ReadSingle(), file_reader.ReadSingle(), file_reader.ReadSingle());
                    polygons.Add(new FPolygon(vertices, new Color(0,0,0), normal));//Add polygon to the list
                    /*for(int h = 0; h < 3; h++)
                    {
                        
                        Console.Write("X. ");
                        Console.Write(vertices[h].X);
                        Console.Write(" ");
                        Console.Write("Y. ");
                        Console.Write(vertices[h].Y);
                        Console.Write(" ");
                        Console.Write("Z. ");
                        Console.Write(vertices[h].Z);
                        Console.WriteLine(" ");
                        
                    }
                    
                    Console.Write("X: ");
                    Console.Write(normal.X);
                    Console.Write(" ");
                    Console.Write("Y: ");
                    Console.Write(normal.Y);
                    Console.Write(" ");
                    Console.Write("X: ");
                    Console.Write(normal.Z);
                    Console.WriteLine(" ");
                    file_reader.ReadBytes(2);
                    */
                }
            }
            catch
            {
                Console.WriteLine("File can't be opened");
            }
            Templates.Add(new FTemplate(polygons, "Monkey"));//Add our generated list to the thing
            return base.run();
        }
    }
}
