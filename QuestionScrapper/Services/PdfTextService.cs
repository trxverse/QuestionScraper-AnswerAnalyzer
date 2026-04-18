
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;

namespace QuestionScrapper.Services;

public  class PdfTextService
{
    public  string Extract(string path)
    {
        using var reader = new PdfReader(path);
        using var doc = new PdfDocument(reader);

        var sb = new System.Text.StringBuilder();
        for (int i = 1; i <= doc.GetNumberOfPages(); i++)
        {
            sb.AppendLine(PdfTextExtractor.GetTextFromPage(
                doc.GetPage(i),
                new SimpleTextExtractionStrategy()
            ));
        }
        return sb.ToString();
    }
}
