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
           ////數字OK
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

            //因為執行檔EXE在BIN底下，所以相對的圖檔要這樣寫
            imgPath = "../../img/ajax.gif";
            var Results = Ocr.Read(imgPath);
            Console.Write(Path.GetFileName(imgPath) +" text is : ");
            Console.WriteLine(Results.Text);

            //var Ocr2 = new AdvancedOcr()
            //{
            //    CleanBackgroundNoise = false,
            //    EnhanceContrast = false,
            //    EnhanceResolution = true,
            //    Language = IronOcr.Languages.ChineseTraditional.OcrLanguagePack,
            //    Strategy = IronOcr.AdvancedOcr.OcrStrategy.Advanced,
            //    //ColorSpace = AdvancedOcr.OcrColorSpace.Color,
            //    DetectWhiteTextOnDarkBackgrounds = false,
            //    InputImageType = AdvancedOcr.InputTypes.AutoDetect,
            //    RotateAndStraighten = false,
            //    ReadBarCodes = false,
            //    ColorDepth = 0
            //};
            Ocr.EnhanceContrast = false;
            Ocr.EnhanceResolution = true;
            Ocr.Language = IronOcr.Languages.ChineseTraditional.OcrLanguagePack;

            imgPath = "../../img/ajax2.gif";
            var Result = Ocr.Read(imgPath);
            Console.Write(Path.GetFileName(imgPath) + " text is : ");
            Console.WriteLine(Result.Text);

            var Ocr3 = new AdvancedOcr()
            {
                CleanBackgroundNoise = true,
                EnhanceContrast = true,
                EnhanceResolution = true,
                Language = IronOcr.Languages.English.OcrLanguagePack,
                Strategy = IronOcr.AdvancedOcr.OcrStrategy.Advanced,
                ColorSpace = AdvancedOcr.OcrColorSpace.Color,
                DetectWhiteTextOnDarkBackgrounds = false,
                InputImageType = AdvancedOcr.InputTypes.Snippet,
                RotateAndStraighten = true,
                ReadBarCodes = false,
                ColorDepth = 4
            };
            
            imgPath = "../../img/imgcheck_pic.png";
            var Result3 = Ocr3.Read(imgPath);
            Console.Write(Path.GetFileName(imgPath) + " text is : ");
            Console.WriteLine(Result3.Text);

            Console.ReadKey();
        }
    }
}
