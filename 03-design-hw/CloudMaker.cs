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
        public Dictionary<FileAccess, string> Paths { get; set; }

        public CloudMaker(string pathToWords, string pathToTrash, string pathToCloud)
        {
            Paths = new Dictionary<FileAccess, string>();
            Paths.Add(FileAccess.PathToWords, pathToWords);
            Paths.Add(FileAccess.PathToTrash, pathToTrash);
            Paths.Add(FileAccess.PathToCloud, pathToCloud);
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
            var words = Statistics.GetWords(Paths[FileAccess.PathToWords]);
            var trash = Statistics.GetTrash(Paths[FileAccess.PathToTrash]);
            var freqDict = Statistics.GetFrequencyDict(words, trash);
            var tagList = Statistics.GetTagList(freqDict, 10, 100, 50);
            var cloud = GetCloud(tagList, new Size(1024, 768), Color.Aqua);
            cloud.CloudMap.Save(Paths[FileAccess.PathToCloud], ImageFormat.Png);
        }
    }
}
