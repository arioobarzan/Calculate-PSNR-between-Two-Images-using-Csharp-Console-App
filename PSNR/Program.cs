using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace PSNR
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int cc = 1;cc<52;cc++)
            try {
                    string addr1 = "D:\\results_dataset\\" + cc + "\\orig.jpg";
                    Bitmap img1 = new Bitmap(addr1);
                    Bitmap img2 = new Bitmap("D:\\results_dataset\\" + cc + "\\orig -res2.jpg");
                int sum = 0;
                for (int i = 0; i < img1.Width; i++)
                {
                    for (int j = 0; j < img1.Height; j++)
                    {
                        int Dr = img1.GetPixel(i, j).R - img2.GetPixel(i, j).R;
                        int Dg = img1.GetPixel(i, j).G - img2.GetPixel(i, j).G;
                        int Db = img1.GetPixel(i, j).B - img2.GetPixel(i, j).B;
                        int D = (Dr * Dr) + (Dg * Dg) + (Db * Db);
                        sum += D;

                    }
                }
                double MSE = sum / ((img1.Width + 1) * (img1.Height + 1));
                Double PSNR = 20 * (Math.Log10(255)) - 10 * (Math.Log10(MSE));
                Console.WriteLine(cc+": "+PSNR);
               // Console.ReadKey();
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
                Console.ReadKey();
                }
            Console.WriteLine("end");
            Console.ReadKey();
        }
    }
}