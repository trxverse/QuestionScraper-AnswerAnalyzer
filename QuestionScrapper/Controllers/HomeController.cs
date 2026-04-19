using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestionScrapper.Data;
using QuestionScrapper.Models;
using QuestionScrapper.Services;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace QuestionScrapper.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _env;
        private readonly PdfTextService _pdf;
        private readonly OcrService _ocr;
        private readonly QuestionParser _parser;
        private readonly ApplicationDbContext _context;



        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env,
            PdfTextService pdf,
            OcrService ocr,
            QuestionParser parser,
            ApplicationDbContext context)
        {
            _logger = logger;
            _env = env;
            _pdf = pdf;
            _ocr = ocr;
            _parser = parser;
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)

        {
            try
            {
                if (file == null || file.Length == 0)
                    return View("Index");

                // Create Upload folder if not exists
                var uploadFolder = Path.Combine(_env.WebRootPath, "uploads");

                if (!Directory.Exists(uploadFolder))
                    Directory.CreateDirectory(uploadFolder);

                // Save file
                var filePath = Path.Combine(uploadFolder, file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                string extractedText = "";

                // Detect file type
                var extension = Path.GetExtension(file.FileName).ToLower();

                if (extension == ".pdf")
                {
                    extractedText = _pdf.Extract(filePath);
                }
                else
                {
                    extractedText = "Ocr disables for test";
                    //extractedText = _ocr.RunOcr(filePath);
                }

                // Parse questions
                //var parsed = _parser.Parse(extractedText);


                ViewBag.Text = extractedText;

                return View("Result");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during file upload and extraction.");

                // Optional: pass error to view
                ViewBag.ErrorMessage = "Something went wrong while processing your file.";

                // Redirect or return the same view
                return View("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Save(string data)
        {
            try
            {
                if (string.IsNullOrEmpty(data))
                {
                    TempData["error"] = "no data to save";
                    return RedirectToAction("Result");
                }
                var question = new QuestionPaper
                {
                    ExtractedText = data,
                    CreatedAt = DateTime.Now
                };
                _context.QuestionPapers.Add(question);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    // This will show you the real error
                    Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");

                    if (ex.InnerException?.InnerException != null)
                    {
                        Console.WriteLine($"Detailed Error: {ex.InnerException.InnerException.Message}");
                    }
                    throw;
                }
                return RedirectToAction("Bank");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
        }

        public IActionResult Bank()
        {
            var questions = _context.QuestionPapers.ToList();
            return View(questions);
        }
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]
        //public async Task<IActionResult> Register

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
