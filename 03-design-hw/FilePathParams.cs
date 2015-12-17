using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_design_hw
{
    public class FilePathParams
    {
        public string PathToWords { get; set; }
        public string PathToTrash { get; set; }
        public string PathToCloud { get; set; }

        public FilePathParams(string pathToWords, string pathToTrash, string pathToCloud)
        {
            PathToWords = pathToWords;
            PathToTrash = pathToTrash;
            PathToCloud = pathToCloud; 
        }
    }
}