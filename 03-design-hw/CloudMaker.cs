using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization.Advanced;

namespace _03_design_hw
{
    class CloudMaker
    {
        //private static string _path;
        private IEnumerable<string> _words;

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

        //private int DefineFontSize(int curFreq, int maxSize, int minsize)
        //{
        //    var maxFreq = _statistics.First().Value;
        //    var minFreq = _statistics.Last().Value;
        //    var factor = (double)maxSize * (curFreq - minFreq) / minsize / (maxFreq - minFreq);
        //    return Math.Max(minsize, (int)(minsize * factor));
        //}

        //private Point GetRandomPosition(Random rand, int width, int height, int wordHeight, int wordLength)
        //{
        //    var x = rand.Next(0, width - wordLength);
        //    var y = rand.Next(0, height - wordHeight);
        //    return new Point(x, y);
        //}

       

        //private bool CheckProbableTagPosition(HashSet<Point> cloudMap, Point position, Size tagSize)
        //{
        //    for (var x = position.X; x <= position.X + tagSize.Width; x++)
        //    {
        //        for (var y = position.Y; y <= position.Y + tagSize.Height; y++)
        //        {
        //            if (cloudMap.Contains(new Point(x, y)))
        //                return false;
        //        }
        //    }
        //    return true;
        //}

        //private HashSet<Point> UpdateCloudMap(HashSet<Point> cloudMap, Point position, Size tagSize)
        //{
        //    var newCloudMap = cloudMap;
        //    for (var x = position.X; x <= position.X + tagSize.Width; x++)
        //    {
        //        for (var y = position.Y; y <= position.Y + tagSize.Height; y++)
        //        {
        //            newCloudMap.Add(new Point(x, y));
        //        }
        //    }
        //    return newCloudMap;
        //}

        public TagCloud GetCloud(IOrderedEnumerable<KeyValuePair<string, int>> tagDict, Size size, Color bgColor)
        {
            var tagCloud = new TagCloud(size, bgColor);
            var gr = Graphics.FromImage(tagCloud._cloudMap);
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
            //Console.WriteLine(Color.Black.ToKnownColor());
            cloud._cloudMap.Save(pathToCloud, ImageFormat.Png);
        }

        //public void DrawCloud(string path)
        //{
        //    var bm = new Bitmap(1024, 768);
        //    var gr = Graphics.FromImage(bm);
        //    var rand = new Random();
        //    foreach (var pair in _statistics)
        //    {
        //        var fontSize = DefineFontSize(pair.Value, 100, 10);
        //        var font = new Font("Tahoma", fontSize);
        //        var size = gr.MeasureString(pair.Key, font);
        //        var position = GetRandomPosition(rand, 1024, 768, fontSize, 200);
        //        gr.DrawString(pair.Key, font, Brushes.Black, position.X, position.Y);
        //    }
        //    bm.Save(path, ImageFormat.Png);
        //}
    }
}
