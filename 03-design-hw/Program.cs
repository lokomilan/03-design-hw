using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_design_hw
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new SimpleStringStatsReader("src.txt");
            var wordSequence = reader.Stats;
            foreach (var word in wordSequence)
            {
                Console.WriteLine(word);
            }
        }
    }
}
