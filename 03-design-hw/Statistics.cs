using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_design_hw
{
    public static class Statistics
    {

        public static IEnumerable<string> GetWords(string pathToWords)
        {
            return File.ReadLines(pathToWords);
        }

        public static HashSet<string> GetTrash(string pathToTrash)
        {
            var trashCan = new HashSet<string>();
            foreach (var word in File.ReadAllLines(pathToTrash))
            {
                trashCan.Add(word);
            }
            return trashCan;
        }

        public static Dictionary<string, int> GetFrequencyDict 
            (IEnumerable<string> words, HashSet<string> trash)
        {
            var frequencyDict = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (frequencyDict.ContainsKey(word))
                    frequencyDict[word]++;
                else if (!trash.Contains(word))
                {
                    frequencyDict.Add(word, 1);
                }
            }
            return frequencyDict;
        }

        public static List<KeyValuePair<string, int>> GetTagList
            (Dictionary<string, int> frequencyDict, int minTagFontSize, int maxTagFontSize, int top)
        {
            var tagDict = new Dictionary<string, int>();
            var minFreq = frequencyDict.Min(x => x.Value);
            var maxFreq = frequencyDict.Max(x => x.Value);
            int diff = maxFreq - minFreq;
            double ratio = (double)minTagFontSize / minTagFontSize;
            foreach (var pair in frequencyDict)
            {
                var currentFreq = pair.Value;
                var relativeHeight = ratio * (currentFreq - minFreq) / diff;
                var currentTagHeight = Math.Max(maxTagFontSize * relativeHeight, minTagFontSize);
                tagDict.Add(pair.Key, (int)currentTagHeight);
            }
            return tagDict
                .OrderByDescending(x => x.Value)
                .Take(top)
                .ToList();
        }
    }
}
