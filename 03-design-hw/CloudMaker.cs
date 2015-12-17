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
        public FilePathParams FpParams { get; set; }
        public CloudGraphicParams CgParams { get; set; }
        public int Top { get; set; }

        public CloudMaker(FilePathParams fpParams, CloudGraphicParams cgParams, int top)
        {
            FpParams = fpParams;
            CgParams = cgParams;
            Top = top;
        }

        public CloudMaker()
        {
            FpParams = DefaultParams.FpParams;
            CgParams = DefaultParams.CgParams;
            Top = DefaultParams.Top;
        }

        public CloudMaker(string pathToWords, string pathToTrash, string pathToCloud)
        {
            FpParams = new FilePathParams(pathToWords, pathToTrash, pathToCloud);
            CgParams = DefaultParams.CgParams;
            Top = DefaultParams.Top;
        }
    

        public TagCloud GetCloud(List<KeyValuePair<string, int>> tagDict)
        {
            var tagCloud = new TagCloud(CgParams.Size, CgParams.BgColor);
            var gr = Graphics.FromImage(tagCloud.CloudMap);
            var rand = new Random();
            foreach (var pair in tagDict)
            {
                var font = new Font(CgParams.TextFontFamily, pair.Value);
                var tagSize = gr.MeasureString(pair.Key, font).ToSize();
                var position = tagCloud.GetProperTagPosition(tagSize);
                gr.DrawString(pair.Key, font, new SolidBrush(CgParams.TextColor), position);
            }
            return tagCloud;
        }

        public void SaveCloud()
        {
            var words = Statistics.GetWords(FpParams.PathToWords);
            var trash = Statistics.GetTrash(FpParams.PathToTrash);
            var freqDict = Statistics.GetFrequencyDict(words, trash);
            var tagList = Statistics.GetTagList(freqDict, 10, 100, 50);
            var cloud = GetCloud(tagList);
            cloud.CloudMap.Save(FpParams.PathToCloud, ImageFormat.Png);
        }
    }
}
