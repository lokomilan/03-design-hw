using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_design_hw
{
    public static class DefaultParams
    {
        public static FilePathParams FpParams = new FilePathParams("words.txt", "trash.txt", "cloud12312.png");
        public static CloudGraphicParams CgParams = CgParams = new CloudGraphicParams(
                new Size(1024, 768),
                Color.Aqua,
                Color.Black, 
                new FontFamily("Tahoma"),
                10,
                100);
        public static int Top = 100;

    }
}
