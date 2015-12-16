using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace _03_design_hw
{
    public class Options
    {
        [Option('w', "words", Required = true, HelpText = "Path to file with words")] 
        public string PathToWords { get; set; }

        [Option('t', "trash", Required = true, HelpText = "Path to file with trash words")]
        public string PathToTrash { get; set; }

        [Option('c', "cloud", Required = true, HelpText = "Path to result image")]
        public string PathToCloud { get; set; }
    }
}
