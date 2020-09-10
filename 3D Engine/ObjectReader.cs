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
            List<FPolygon> currant_shape_holder;
            Vector3[] current_polygon = new Vector3[3];
            //Add cube
            //Instead of creating 12 different variables for each triangle I just use the current polygon and reset it each time
            //Then I just push the polygon to the array of polygons which I can just to the templates
            //First triangle on the first yz plane
            current_polygon[0] = new Vector3(0, 0, 0);
            current_polygon[1] = new Vector3(0, 1, 0);
            current_polygon[3] = new Vector3(0, 0, 1);
            currant_shape_holder.Add(FPolygon(current_polygon, color.grey);
            //second triangle on the first yz plane
            current_polygon[0] = new Vector3(0, 1, 0);
            current_polygon[1] = new Vector3(0, 1, 1);
            current_polygon[2] = new Vector3(0, 0, 1);
            currant_shape_holder.Add(FPolygon(current_polygon, color.grey);
            //First triangle on the first xz plane
            current_polygon[0] = new Vector3(0, 0, 0);
            current_polygon[1] = new Vector3(1, 0, 0);
            current_polygon[2] = new Vector3(0, 0, 1);
            currant_shape_holder.Add(FPolygon(current_polygon, color.grey);
            //Second triangle on the first xz plane
            current_polygon[0] = new Vector3(1, 0, 1);
            current_polygon[1] = new Vector3(1, 0, 0);
            current_polygon[2] = new Vector3(0, 0, 1);
            currant_shape_holder.Add(FPolygon(current_polygon, color.grey);
            //First triangle on the first xy plane
            current_polygon[0] = new Vector3(0, 0, 0);
            current_polygon[1] = new Vector3(1, 0, 0);
            current_polygon[2] = new Vector3(0, 1, 0);
            currant_shape_holder.Add(FPolygon(current_polygon, color.grey);
            //Second triangle on the first xy plane
            current_polygon[0] = new Vector3(1, 1, 0);
            current_polygon[1] = new Vector3(1, 0, 0);
            current_polygon[2] = new Vector3(0, 0, 1);
            currant_shape_holder.Add(FPolygon(current_polygon, color.grey);

            //First triangle on the second yz plane
            current_polygon[0] = new Vector3(1, 1, 1);
            current_polygon[1] = new Vector3(1, 1, 0);
            current_polygon[2] = new Vector3(1, 0, 1);
            currant_shape_holder.Add(FPolygon(current_polygon, color.grey);
            //second triangle on the second yz plane
            current_polygon[0] = new Vector3(1, 0, 0);
            current_polygon[1] = new Vector3(1, 1, 0);
            current_polygon[2] = new Vector3(1, 0, 1);
            currant_shape_holder.Add(FPolygon(current_polygon, color.grey);
            //First triangle on the second xz plane
            current_polygon[0] = new Vector3(0, 1, 0);
            current_polygon[1] = new Vector3(1, 1, 0);
            current_polygon[2] = new Vector3(0, 1, 1);
            currant_shape_holder.Add(FPolygon(current_polygon, color.grey);
            //Second triangle on the second xz plane
            current_polygon[0] = new Vector3(1, 1, 1);
            current_polygon[1] = new Vector3(1, 1, 0);
            current_polygon[2] = new Vector3(0, 1, 1);
            currant_shape_holder.Add(FPolygon(current_polygon, color.grey);
            //First triangle on the second xy plane
            current_polygon[0] = new Vector3(0, 0, 1);
            current_polygon[1] = new Vector3(1, 0, 1);
            current_polygon[2] = new Vector3(0, 1, 1);
            currant_shape_holder.Add(FPolygon(current_polygon, color.grey);
            //Second triangle on the second xy plane
            current_polygon[0] = new Vector3(1, 1, 1);
            current_polygon[1] = new Vector3(1, 0, 1);
            current_polygon[2] = new Vector3(0, 1, 1);
            currant_shape_holder.Add(FPolygon(current_polygon, color.grey);
            Template.Add(FTemplate(current_shape_holder));
            Template[0].name = "Cube";

            return (base.run());
        }
    }
}
