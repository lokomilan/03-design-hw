using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace _03_design_hw
{
    class Program
    {
        static void Main(string[] args)
        {
            var cloudMaker = new CloudMaker("src.txt");
            cloudMaker.SaveCloud("test.png");
        }
    }
}
