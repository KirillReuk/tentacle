using System.Collections.Generic;
using System.Drawing;

namespace KitGenerator
{
    public class KitLayer
    {
        const string blankImagePath = "..\\..\\..\\kits\\_blank.png";

        public string Name { get; set; }
        public string ImageLocation { get; set; }
        public List<Color> Colors { get; set; }
        public int Rotation { get; set; }
        public int XShift { get; set; }
        public int YShift { get; set; }
        public int Scaling { get; set; }
        public bool SystemLayer { get; set; }

        public KitLayer(string name, string imageLocation, List<Color> colors, int xShift, int yShift, int rotation, int scaling)
        {
            Name = name;
            ImageLocation = imageLocation;
            Colors = colors;
            Rotation = rotation;
            XShift = xShift;
            YShift = yShift;
            Scaling = scaling;
            SystemLayer = false;
        }

        public KitLayer(string name, string imageLocation, List<Color> colors)
        {
            Name = name;
            ImageLocation = imageLocation;
            Colors = colors;
            SystemLayer = true;
        }

        public KitLayer()
        {
            ImageLocation = blankImagePath;
        }
    }
}
