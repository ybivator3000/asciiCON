using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Drawing.Imaging;
//using AForge.Video.FFMPEG;

namespace ASCIIConvertor
{
    class Program
    {
        private const double WIDTH_OFFSET = 1.5;
         
        [STAThread]
        static void Main(string[] args)
        {
            char[] _asciitable = { '.', ',', ':', '+', '*', '?', '%', '$', '#', '@' };

            string path = @"";

            // var reader = new VideoFileReader();
            //reader.Open(path);
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Images | *.bmp; *.png; *.jpg; *.gif"
            };
            

            
            //Console.WriteLine("Press any key to continue...");

            while (true)
            {
                //Console.ReadKey();

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    continue;
                }

                //Console.Clear();

                //Bitmap bitmap = new Bitmap(openFileDialog.FileName);
                Bitmap image = new Bitmap(openFileDialog.FileName);
                string fileFormat = "";
                int idx = 1;
                while (openFileDialog.FileName[openFileDialog.FileName.Length - idx] != '.')
                {
                    fileFormat += openFileDialog.FileName[openFileDialog.FileName.Length - idx];
                    idx++;
                }
                fileFormat = fileFormat.Mirror();
                //var newBit = new Bitmap();
                //ShowFrame(ref bitmap);
                //MessageBox.Show($"{bitmap.GetFrameCount(FrameDimension.Time)} heigth {bitmap.Height}");
                if (openFileDialog.FileName[openFileDialog.FileName.Length- 1] == 'f')
                {

                    Image[] bitMaps = CreateFramesArray(image);
                    while (true)
                    {
                        for (int i = 0; i < bitMaps.Length; i++)
                        {
                            Bitmap bitmap = new Bitmap(bitMaps[i]);
                            ShowFrame(ref bitmap);
                            //if (i == bitMaps.Length)
                            //  i = 0;
                            //Console.ReadKey();

                        }
                    }
                } else
                {
                    image = ResizeImg(image);
                    image.ToGrayScale();

                    //image.Save(@"C:\Users\777\Pictures\Saved Pictures\name1232131231123." + fileFormat, image.RawFormat);
                    var convertor = new BitmapToASCIIConvertor(image);
                    Console.Write(convertor.Convert());
                    Console.SetCursorPosition(0, 0);
                }
                /*for(int i = 0; i < bitmap.GetFrameCount(FrameDimension.Time); i++)
                {
                    Console.Clear();
                    bitmap.SelectActiveFrame(FrameDimension.Time, i);
                    ShowFrame(ref bitmap);
                }*/
                /*
                ShowFrame(ref bitmap);

                Console.ReadKey();
                Console.Clear();
                bitmap.SelectActiveFrame(FrameDimension.Time, 40);
                ShowFrame(ref bitmap);*/

                /*while (true)
                {
                    Console.Clear();
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        for (int x = 0; x < bitmap.Width; x++)
                        {
                            Console.Write(rows[y, x]);
                        }
                        Console.WriteLine();
                    }
                }*/

            }
        }
        private static Image[] CreateFramesArray(Image img)
        {
            List<Image> images= new List<Image>();
            int length = img.GetFrameCount(FrameDimension.Time);
            for(int i = 0;i < length; i++)
            {
                img.SelectActiveFrame(FrameDimension.Time, i);
                images.Add(new Bitmap(img));
            }
            return images.ToArray();
        }
        private static void ShowFrame(ref Bitmap bitmap)
        {
            bitmap = ResizeBitmap(bitmap);
            bitmap.ToGrayScale();
            var convertor = new BitmapToASCIIConvertor(bitmap);
            Console.Write(convertor.Convert());
            //var rows = convertor.Convert();S
            //string testString = "";
            //for(int i =0; i < testString.
            /*
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                   //testString += rows[y, x];
                    Console.Write(rows[y, x]);
                }
                //testString += "\n";
                Console.Write("\n");
            }*/
            //Console.Write(testString);
            bitmap.Dispose();
            Console.SetCursorPosition(0, 0);

        }
        private static Bitmap ResizeBitmap(Bitmap bitmap)
        {
            double maxHeight = Console.WindowHeight ;
            double maxWidth = Console.WindowWidth;
            
           var newHeight = (maxWidth / 2.55) * (bitmap.Height / bitmap.Width);
            double newWidth = ((double)maxHeight * 2) * ((double)bitmap.Width / bitmap.Height);
            if (bitmap.Width > newWidth || bitmap.Height > maxHeight)
            {
                bitmap = new Bitmap(bitmap, new Size((int)(newWidth), (int)maxHeight));
            }

            return bitmap;
        }
        private static Bitmap ResizeImg(Bitmap bitmap)
        {
            double maxWidth = Console.WindowWidth;
            double newHeight = (double)maxWidth / 4  * ((double)bitmap.Height / bitmap.Width);
            
            if (bitmap.Width > maxWidth || bitmap.Height > newHeight)
            {
                bitmap = new Bitmap(bitmap, new Size((int)(maxWidth), (int)newHeight));
            }

            return bitmap;
        }
    }
}
