using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Diagnostics;                // for Debug
using System.Drawing;                    // for Color (add reference to  System.Drawing.assembly)
using System.Runtime.InteropServices;
namespace Lab3._2
{
    struct Color 
    {
        int r;
        int g;
        int b;
        //sdsdsdsd
        public Color(int r, int g, int b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public override string ToString()
        {
            return $"[{r}, {g}, {b}]";
        }
    }


    class Vector : IComparable<Vector>
    {
        public Color Color { get; set; }

        public int Angle { get; set; }

        public float Length { get; set; }

        public Vector()
        {
            this.Color = new Color();
            this.Angle = 0;
            this.Length = 0;

        }
        public Vector(Color color, int angle, int length)
        {
            Color = color;
            Angle = angle;
            Length = length;
        }

        public void ReduceVector(int value)
        {
            Length /= value;
        }
        public void IncreaseVector(int value)
        {
            Length *= value;
        }

        public void PrntInfo()
        {
            Console.WriteLine($"Color = {Color}, Angle = {Angle}, Length = {Length}.");
        }

        public int CompareTo(Vector? other)
        {
            return (int)(this.Length * 1000) - (int)(other.Length * 1000);
        }
    }
}
