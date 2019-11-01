using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronOcr;

namespace OCRConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            string imgPath = "";

            //=== 電話號碼圖片 ===
            var Ocr = new AdvancedOcr()
            {
                CleanBackgroundNoise = false,
                EnhanceContrast = true,
                EnhanceResolution = false,
                Language = IronOcr.Languages.English.OcrLanguagePack,
                Strategy = IronOcr.AdvancedOcr.OcrStrategy.Advanced,
                ColorSpace = AdvancedOcr.OcrColorSpace.Color,
                DetectWhiteTextOnDarkBackgrounds = false,
                InputImageType = AdvancedOcr.InputTypes.AutoDetect,
                RotateAndStraighten = false,
                ReadBarCodes = false,
                ColorDepth = 0
            };

            imgPath = "../../img/image1.gif"; //因為執行檔EXE在BIN底下，所以相對的圖檔要這樣寫
            Console.Write(Path.GetFileName(imgPath) + " text is : ");
            Console.WriteLine(Ocr.Read(imgPath).Text);

            //=== 中文地址圖片 ===
            Ocr.EnhanceContrast = false;
            Ocr.EnhanceResolution = true;
            Ocr.Language = IronOcr.Languages.ChineseTraditional.OcrLanguagePack;

            imgPath = "../../img/image2.gif";
            Console.Write(Path.GetFileName(imgPath) + " text is : ");
            Console.WriteLine(Ocr.Read(imgPath).Text);

            //=== 驗證碼圖片 ===
            Ocr.CleanBackgroundNoise = true;
            Ocr.EnhanceContrast = true;
            Ocr.EnhanceResolution = true;
            Ocr.Language = IronOcr.Languages.English.OcrLanguagePack;
            Ocr.InputImageType = AdvancedOcr.InputTypes.Snippet;
            Ocr.RotateAndStraighten = true;
            Ocr.ColorDepth = 4;

            imgPath = "../../img/image3.png";
            Console.Write(Path.GetFileName(imgPath) + " text is : ");
            Console.WriteLine(Ocr.Read(imgPath).Text);

            Console.ReadKey();
        }
    }
}
