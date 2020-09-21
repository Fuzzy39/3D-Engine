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
    class ObjectReader : ObjectReaderModule
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
            List<FPolygon> current_shape_holder = new List<FPolygon>();
            Vector3[] current_polygon = new Vector3[3];

            //Add cube
            //Instead of creating 12 different variables for each triangle I just use the current polygon and reset it each time
            //Then I just push the polygon to the array of polygons which I can just to the templates
            //First triangle on the first yz plane
            
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
           
            // finish up.
            
           /* current_polygon[0] = new Vector3(0, 0, 1);
            current_polygon[1] = new Vector3(0, 1, 0);
            current_polygon[2] = new Vector3(0, 0, 0);
            current_shape_holder.Add(new FPolygon(current_polygon, Color.Gray));
            current_polygon = new Vector3[3];
            current_polygon[0] = new Vector3(0, 0, -1);
            current_polygon[1] = new Vector3(0, 1, 0);
            current_polygon[2] = new Vector3(0, 0, 0);
            current_shape_holder.Add(new FPolygon(current_polygon, Color.Gray));*/

            //   current_shape_holder.Add(new FPolygon(current_polygon, Color.Gray));
            base.Templates.Add(new FTemplate(current_shape_holder, "Cube"));
            Console.WriteLine(current_shape_holder.Count);
            return (base.run());
        }
    }
}
