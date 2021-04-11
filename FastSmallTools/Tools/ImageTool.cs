using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using OpenCvSharp.Features2D;


namespace FastSmallTools.Tools
{
    class ImageTool
    {

        public static List<System.Drawing.Point> func(Bitmap bitmap1, Bitmap bitmap2)
        {
            //Mat img1 = new Mat(@"roll/0.png", ImreadModes.Unchanged);
            //Mat img2 = new Mat(@"roll/1.png", ImreadModes.Unchanged);
            Mat img1 = BitmapToMat(bitmap1);
            Mat img2 = BitmapToMat(bitmap2);
            SIFT sift = SIFT.Create(20);
            //KeyPoint[] k = sift.Detect(img1);
            // Detect the keypoints and generate their descriptors using SIFT
            KeyPoint[] keypoints1, keypoints2;
            var descriptors1 = new Mat<float>();
            var descriptors2 = new Mat<float>();
            sift.DetectAndCompute(img1, null, out keypoints1, descriptors1);
            sift.DetectAndCompute(img2, null, out keypoints2, descriptors2);

            // Match descriptor vectors
            var bfMatcher = new BFMatcher(NormTypes.L2, false);
            var flannMatcher = new FlannBasedMatcher();
            DMatch[] bfMatches = bfMatcher.Match(descriptors1, descriptors2);
            DMatch[] flannMatches = flannMatcher.Match(descriptors1, descriptors2);

            // Draw matches
            var bfView = new Mat();
            Cv2.DrawMatches(img1, keypoints1, img2, keypoints2, bfMatches, bfView);
            var flannView = new Mat();
            Cv2.DrawMatches(img1, keypoints1, img2, keypoints2, flannMatches, flannView);

            using (new Window("SIFT matching (by BFMather)", bfView))
            using (new Window("SIFT matching (by FlannBasedMatcher)", flannView))
            {
                Cv2.WaitKey();
            }
            List<System.Drawing.Point> points = new List<System.Drawing.Point>();
            
            foreach (DMatch match in bfMatches)
            {
                System.Drawing.Point p = new System.Drawing.Point();
                p.X = (int)(keypoints1[match.QueryIdx].Pt.X - keypoints2[match.TrainIdx].Pt.X);
                p.Y = (int)(keypoints1[match.QueryIdx].Pt.Y - keypoints2[match.TrainIdx].Pt.Y);
                points.Add(p);
            }

            return points;

        }

        public static Mat BitmapToMat(Bitmap srcbit)
        {
            int iwidth = srcbit.Width;
            int iheight = srcbit.Height;
            int iByte = iwidth * iheight * 3;
            byte[] result = new byte[iByte];
            int step;
            Rectangle rect = new Rectangle(0, 0, iwidth, iheight);
            BitmapData bmpData = srcbit.LockBits(rect, ImageLockMode.ReadWrite, srcbit.PixelFormat);
            IntPtr iPtr = bmpData.Scan0;
            Marshal.Copy(iPtr, result, 0, iByte);
            step = bmpData.Stride;
            srcbit.UnlockBits(bmpData);
            return new Mat(srcbit.Height, srcbit.Width, new MatType(MatType.CV_8UC3), result, step);
        }

        /// <summary>
        /// 图片距离计算
        /// </summary>
        /// <param name="bitmap1"></param>
        /// <param name="bitmap2"></param>
        /// <returns>Distance</returns>
        public static Double Calculate_Distance(Bitmap bitmap1, Bitmap bitmap2)
        {

            if (bitmap1.Width != bitmap2.Width || bitmap1.Height != bitmap2.Height)
            {
                Console.WriteLine("Width:" + bitmap1.Width.ToString() + "," + bitmap2.Width.ToString());
                Console.WriteLine("Height:" + bitmap1.Height.ToString() + "," + bitmap2.Height.ToString());
                return Double.MaxValue;
            }
            Double distance = 0;
            for (int i = 0; i < bitmap1.Width; i++)
            {
                for (int j = 0; j < bitmap1.Height; j++)
                {
                    Color c1 = bitmap1.GetPixel(i, j);
                    Color c2 = bitmap2.GetPixel(i, j);
                    distance += Math.Sqrt(Math.Pow((c1.R - c2.R), 2) +
                        Math.Pow((c1.G - c2.G), 2) + Math.Pow((c1.B - c2.B), 2));

                }

            }
            distance = distance / bitmap1.Width / bitmap1.Height;
            return distance;
        }

        /// <summary>
        /// 计算图片的CRC码
        /// </summary>
        /// <param name="bitmap">图片</param>
        /// <param name="horizontal">是否按水平方向计算</param>
        /// <param name="startIndex">起始计算点</param>
        /// <param name="endIndex">结束计算点</param>
        /// <returns></returns>
        public static List<int> GetBitmapCRCCode(Bitmap bitmap, bool horizontal, int startIndex, int endIndex)
        {
            List<int> crcList = new List<int>();
            int CRCCount = 0, pixelCount = 0;
            if (horizontal)
            {
                CRCCount = bitmap.Height; // 水平方向计算，每一行计算一次CRC
                pixelCount = bitmap.Width;//每一行有pixelCount个像素点
            }
            else
            {
                CRCCount = bitmap.Width; // 垂直方向计算，每一列计算一次CRC
                pixelCount = bitmap.Height;//每一列有pixelCount个像素点
            }
            if(startIndex < 0 || startIndex > endIndex || endIndex > pixelCount)
            {
                return crcList;  // 下标无效，返回空值
            }

            for (int j = 0; j < CRCCount; j++)
            {
                List<byte> row = new List<byte>();
                Color color;
                for (int i = startIndex; i < endIndex; i++)
                {
                    if (horizontal)
                    {
                        color = bitmap.GetPixel(i, j);
                    }
                    else
                    {
                        color = bitmap.GetPixel(j, i);
                    }
                    
                    row.Add(color.R);
                    row.Add(color.G);
                    row.Add(color.B);

                }
                crcList.Add(CheckCode.CRCCalc(row));
            }
            return crcList;
        }
        public static List<int> GetBitmapCRCCode(Bitmap bitmap, bool horizontal)
        {
            if (horizontal)
            {
                return GetBitmapCRCCode(bitmap, horizontal, 0, bitmap.Width);
            }
            else
            {
                return GetBitmapCRCCode(bitmap, horizontal, 0, bitmap.Height);
            }
            
        }
        public static bool FindMaxCommonList(List<int> intList1, List<int> intList2, ref int index1, ref int index2)
        {
            bool flag = false;
            index1 = 0;
            index2 = 0;
            int maxLength = 0;
            List<List<int>> record = new List<List<int>>();
            record.Add(new List<int>(intList1.Count));
            for (int i = 0; i < intList1.Count; i++)
            {
                record[0].Add(0);
            }
            Console.WriteLine("********************************");
            for (int i = 0; i < intList1.Count; i++)
            {
                List<int> temp = new List<int>();
                temp.Add(0);
                record.Add(temp);
                for (int j = 0; j < intList2.Count; j++)
                {
                    record[i + 1].Add(0);
                    if (intList1[i] == intList2[j])
                    {
                        record[i + 1][j + 1] = record[i][j] + 1;
                        if (record[i + 1][j + 1] > maxLength)
                        {
                            maxLength = record[i + 1][j + 1];
                            index1 = i + 1 - maxLength;
                            index2 = j + 1 - maxLength;
                            flag = true;
                            //Console.WriteLine(string.Format("i:{0},j:{1},l:{2},t:{3}", i, j, maxLength, record[i + 1][j + 1]));
                        }
                    }
                }

            }

            return flag;
        }

        public static bool FindMaxCommonEdge(List<int> intList1, List<int> intList2, ref int index1, ref int index2)
        {
            bool flag = false;
            index1 = 0;
            index2 = intList1.Count;
            if(intList1.Count != intList2.Count)
            {
                return false;
            }
            for(int i = 0; i < intList1.Count; i++)
            {
                if(intList1[i] != intList2[i])
                {
                    flag = true;
                    break;
                }
                else{
                    index1 = i;
                }
            }
            for (int i = intList1.Count-1; i >= 0; i--)
            {
                if (intList1[i] != intList2[i])
                {
                    flag = true;
                    index2 = i+1;
                    break;
                }
            }
            return flag;
        }


    }
}
