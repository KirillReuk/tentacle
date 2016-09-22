using System.Collections.Generic;
using System.Drawing;

namespace KitGenerator
{
    public class KitLayer
    {
        public string name;
        public string imageLocation;
        public List<Color> colors;
        public double rotation;
        public Rectangle location;
        public bool systemLayer;

        public KitLayer(string _name, string _imageLocation, List<Color> _colors, double _rotation, Rectangle _location)
        {
            name = _name;
            imageLocation = _imageLocation;
            colors = _colors;
            rotation = _rotation;
            location = _location;
            systemLayer = false;
        }

        public KitLayer(string _name, List<Color> _colors)
        {
            name = _name;
            colors = _colors;
            systemLayer = true;
        }

        public KitLayer()
        {
        }
    }
}
