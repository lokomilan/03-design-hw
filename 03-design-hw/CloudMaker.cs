using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Drawing.Imaging;


namespace _03_design_hw
{
    class CloudMaker
    {
        private readonly IEnumerable<string> _words;

        public CloudMaker(string pathToSource)
        {
            _words = File.ReadLines(pathToSource);
        }

        private Dictionary<string, int> GetStatistics(IEnumerable<string> words)
        {
            var stats = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (stats.ContainsKey(word))
                    stats[word] += 1;
                else
                {
                    stats[word] = 1;
                }
            }
            return stats;
        }

        private IOrderedEnumerable<KeyValuePair<string, int>> GetTagDict(Dictionary<string, int> statistics, 
            int minTagHeight, int maxTagHeight)
        {
            var tagDict = new Dictionary<string, int>();
            var minFreq = statistics.Min(x => x.Value);
            var maxFreq = statistics.Max(x => x.Value);
            int diff = maxFreq - minFreq;
            double ratio = maxTagHeight/minTagHeight;
            foreach (var pair in statistics)
            {
                var currentFreq = pair.Value;
                var relativeHeight = ratio*(currentFreq - minFreq)/diff;
                var currentTagHeight = Math.Max(minTagHeight*relativeHeight, minTagHeight);
                tagDict.Add(pair.Key, (int)currentTagHeight);
            }
            return tagDict.OrderByDescending(x => x.Value);
        }

        public TagCloud GetCloud(IOrderedEnumerable<KeyValuePair<string, int>> tagDict, Size size, Color bgColor)
        {
            var tagCloud = new TagCloud(size, bgColor);
            var gr = Graphics.FromImage(tagCloud.CloudMap);
            var rand = new Random();
            foreach (var pair in tagDict)
            {
                var font = new Font("Tahoma", pair.Value);
                var tagSize = gr.MeasureString(pair.Key, font).ToSize();
                var position = tagCloud.GetProperTagPosition(tagSize);
                gr.DrawString(pair.Key, font, Brushes.Black, position);
            }
            return tagCloud;
        }

        public void SaveCloud(string pathToCloud)
        {
            var statistics = GetStatistics(_words);
            var tagDict = GetTagDict(statistics, 10, 100);
            var cloud = GetCloud(tagDict, new Size(1024, 768), Color.Aqua);
            cloud.CloudMap.Save(pathToCloud, ImageFormat.Png);
        }
    }
}
