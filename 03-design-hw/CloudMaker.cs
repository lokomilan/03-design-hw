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
        private readonly string PathToWords;
        private readonly string PathToTrash;
        private readonly string PathToCloud;

        public CloudMaker(string pathToWords, string pathToTrash, string pathToCloud)
        {
            PathToWords = pathToWords;
            PathToTrash = pathToTrash;
            PathToCloud = pathToCloud;
        }
        public TagCloud GetCloud(List<KeyValuePair<string, int>> tagDict, Size size, Color bgColor)
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

        public void SaveCloud()
        {
            var statistics = new Statistics(PathToWords, PathToTrash, 10, 100, 50);
            var cloud = GetCloud(statistics.TagList, new Size(1024, 768), Color.Aqua);
            cloud.CloudMap.Save(PathToCloud, ImageFormat.Png);
        }
    }
}
