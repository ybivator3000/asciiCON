using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIConvertor
{
    public class BitmapToASCIIConvertor
    {
        private readonly char[] _asciitable = { '.', ',', ':', '+', '*','?', '%', '$', '#', '@' };
        //private readonly char[] _asciitable = {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','0','1','2','3','4','5','6','7','8','9','<','>','|',',','.','-','#','+','!','$','%','&','/','(',')','=','?','*',':',';'};
        private readonly Bitmap _bitmap;

        public BitmapToASCIIConvertor(Bitmap bitmap)
        {
            _bitmap = bitmap;
        }
        public string Convert()
        {
            int height = _bitmap.Height;
            int width = _bitmap.Width;
            string result = "";
            int mapIndex;

            for (int y = 0; y < _bitmap.Height; y++)
            {
                for (int x = 0; x < _bitmap.Width; x++)
                {
                   // mapIndex = (int)Map(_bitmap.GetPixel(x, y).R, 0, 255, 0, _asciitable.Length - 1);
                    mapIndex = (int)(_bitmap.GetPixel(x, y).R * (double)(_asciitable.Length) / 255);
                    result += _asciitable[mapIndex];
                }
                result += "\n";
            }
            return result;
        }
        
        private float Map(float valueToMap, float start1, float stop1, float start2, float stop2)
        {
            return ((valueToMap - start1) / (stop1 - start1)) * (stop2 -start2) + start2;
            /*var result =(int)(valueToMap / 25.6);
            
            if (result >= 0 && result < 1)
            {
                return 9;
            } else if (result >= 1 && result < 2)
            {
                return 8;
            }
            else if (result >= 2 && result < 3)
            {
                return 7;
            }
            else if (result >= 3 && result < 4)
            {
                return 6;
            }
            else if (result >= 4 && result < 5)
            {
                return 5;
            }
            else if (result >= 5 && result < 6)
            {
                return 4;
            }
            else if (result >= 6 && result < 7)
            {
                return 3;
            }
            else if (result >= 7 && result < 8)
            {
                return 2;
            }
            else if (result >= 8 && result < 9)
            {
                return 1;
            }
            else if (result >= 9)
            {
                return 0;
            }

            return result; */
        }
    }
}
