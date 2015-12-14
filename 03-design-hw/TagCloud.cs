using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_design_hw
{
    class TagCloud
    {
        public Bitmap _cloudMap;
        private Color _bgColor;
        private Size _size;

        public TagCloud(Size size, Color bgColor)
        {
            _size = size;
            _bgColor = bgColor;
            _cloudMap = FillCloudMap(new Bitmap(size.Width, size.Height), bgColor);
        }
        private static Bitmap FillCloudMap(Bitmap empty, Color bgColor)
        {
            var newBitmap = empty;
            for (var x = 0; x < empty.Width; x++)
                for (var y = 0; y < empty.Height; y++)
                    empty.SetPixel(x, y, bgColor);
            return newBitmap;
        }

        private bool CheckProbableTagPosition(Point position, Size tagSize)
        {
            for (var x = position.X; x <= position.X + tagSize.Width; x++)
            {
                for (var y = position.Y; y <= position.Y + tagSize.Height; y++)
                {
                    if (x >= _size.Width || y >= _size.Height || x < 0 || y < 0 ||
                        !_cloudMap.GetPixel(x, y).ToArgb().Equals(_bgColor.ToArgb()))
                        return false;
                }
            }
            return true;
        }

        public Point GetProperTagPosition(Size tagSize, int stepsNumber = 100)
        {
            var rand = new Random();
            var leftEdge = (_size.Width - tagSize.Width) / 2;
            var rightEdge = leftEdge + tagSize.Width;
            var horizontalStep = Math.Max(1, leftEdge / stepsNumber);
            var topEdge = (_size.Height - tagSize.Height) / 2;
            var bottomEdge = topEdge + tagSize.Height;
            var verticalStep = Math.Max(1, topEdge / stepsNumber);
            for (var step = 0; step < stepsNumber; step++)
            {
                var x = rand.Next(leftEdge, rightEdge - tagSize.Width);
                var y = rand.Next(topEdge, bottomEdge - tagSize.Height);
                var position = new Point(x, y);
                if (CheckProbableTagPosition(position, tagSize))
                    return position;
                leftEdge -= horizontalStep;
                topEdge -= verticalStep;
                bottomEdge += verticalStep;
                rightEdge += horizontalStep;
            }
            return new Point(rand.Next(0, _size.Width), rand.Next(0, _size.Height));
        }
    }
}
