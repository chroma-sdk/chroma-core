using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Chroma.NetCore.Api.Exceptions;

namespace Chroma.NetCore.Api.Chroma
{
    public class Color
    {
        private int r;
        private int g;
        private int b;

        private string color;

        public Color(string color)
        {
            this.color = color;

            ToRgb();
        }

        public Color(int r, int g, int b)
        {
            this.r = r;
            this.g = g;
            this.b = b;

            //Check borders
            if (this.r > 255) this.r = 255;
            if (this.g > 255) this.g = 255;
            if (this.b > 255) this.b = 255;
            if (this.r < 0) this.r = 0;
            if (this.g < 0) this.g = 0;
            if (this.b < 0) this.b = 0;
        }

        public static Color Black = new Color("000000");
        public static Color Red = new Color("ff0000");
        public static Color Green = new Color("00ff00");
        public static Color Blue = new Color("0000ff");
        public static Color HotPink = new Color(255, 105, 180);
        public static Color Orange = new Color("ffa500");
        public static Color Pink = new Color("ff00ff");
        public static Color Purple = new Color("800080");
        public static Color White = new Color(255, 255, 255);
        public static Color Yellow = new Color(255, 255, 0);


        private string ToRgb()
        {
            if (string.IsNullOrEmpty(color))
                return $"{r} {g} {b}";

            var colorComponents = Regex.Match(color, "^#?([a-f\\d]{2})([a-f\\d]{2})([a-f\\d]{2})$", RegexOptions.IgnoreCase);

            if(colorComponents.Groups.Count != 4)
                throw new ChromaNetCoreApiException("Invalid color format!");

            r = int.Parse(colorComponents.Groups[1].Value, NumberStyles.HexNumber);
            g = int.Parse(colorComponents.Groups[2].Value, NumberStyles.HexNumber);
            b = int.Parse(colorComponents.Groups[3].Value, NumberStyles.HexNumber);

            return $"{r} {g} {b}";
        }

        public int ToBgr()
        {
            return 0xAA00FF;
        }

        public override string ToString()
        {
            return color;
        }
    }
}
