using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_design_hw
{
    public class CloudGraphicParams
    {
        public Size Size { get; set; }
        public Color BgColor { get; set; }
        public Color TextColor { get; set; }
        public FontFamily TextFontFamily { get; set; }
        public int MinTagFontSize { get; set; }
        public int MaxTagFontSize { get; set; }

        public CloudGraphicParams
            (Size size, Color bgColor, Color texColor, FontFamily textFontFamily, int minTagFontSize, int maxTagFontSize)
        {
            Size = size;
            BgColor = bgColor;
            TextColor = texColor;
            TextFontFamily = textFontFamily;
            MinTagFontSize = minTagFontSize;
            MaxTagFontSize = maxTagFontSize;
        }

    }
}
