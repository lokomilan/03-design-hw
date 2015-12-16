using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using CommandLine;

namespace _03_design_hw
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();
            Parser.Default.ParseArguments(args, options);
            var cloudMaker = new CloudMaker(options.PathToWords, options.PathToTrash, options.PathToCloud);
            cloudMaker.SaveCloud();
        }
    }
}
