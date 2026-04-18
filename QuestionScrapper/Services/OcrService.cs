//using IronOcr;
//namespace QuestionScrapper.Services;
//public class OcrService
//{
//    public string RunOcr(string imagePath)

//    {
//        var ocr = new IronTesseract();

//        using (var ocrInput = new OcrInput())
//        {
//            ocrInput.AddImage(imagePath);

//            // Optionally Apply Filters if needed:
//            // ocrInput.Deskew();  // use only if image not straight
//            // ocrInput.DeNoise(); // use only if image contains digital noise

//            var ocrResult = ocr.Read(ocrInput);
//           return ocrResult.Text;
//        }













































using Tesseract;

namespace QuestionScrapper.Services;

public class OcrService
{
    public string RunOcr(string imagePath)
    {
        var tessPath = Path.Combine(Directory.GetCurrentDirectory(), "tessdata");

        var engine = new TesseractEngine(tessPath, "eng", EngineMode.Default); 
        using var img = Pix.LoadFromFile(imagePath);
        using var page = engine.Process(img);
        return page.GetText();
    }
}
