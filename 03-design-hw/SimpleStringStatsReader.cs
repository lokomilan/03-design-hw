using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_design_hw
{
    public class SimpleStringStatsReader : IStatsReader
    {
        public string SourceFile { get; set; }
        public IOrderedEnumerable<KeyValuePair<string, int>> Stats { get; set; }

        public SimpleStringStatsReader(string sourceFile)
        {
            SourceFile = sourceFile;
            Stats = ReadStats();
        }

        private IOrderedEnumerable<KeyValuePair<string, int>> ReadStats()
        {
            var statsDict = new Dictionary<string, int>();
            foreach (var line in File.ReadAllLines(SourceFile))
            {
                var word = new Word(line);
                var key = word.Stem;
                if (statsDict.ContainsKey(key))
                    statsDict[key]++;
                else
                    statsDict[key] = 1;
            }
            var orderedSequence = statsDict.OrderByDescending(x => x.Value);
            return orderedSequence;
        }
    }
}
