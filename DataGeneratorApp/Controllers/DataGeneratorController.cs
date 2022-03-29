using DataGeneratorApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataGeneratorApp.Controllers
{
    public class DataGeneratorController : Controller
    {
        private readonly DatabaseContext _context;
        public DataGeneratorController(DatabaseContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Data()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Data(string Items)
        {

            int abc = Int32.Parse(Items);
            string[] Name = new string[] { "Syed", "Abdllah", "Faheem", "Ashraf", "Ali", "Aslam", "Waseem", "Naeem", "Wafa", "Hussain","Abbas" };
            string[] ProductName = new string[] { "Iphone 13", "Iphone 12", "Samsung S-21", "Samsung S-20", "Pixel 6", "One Plus", "Samsung Note-20", "Samsung Note-21" };
            double[] Price = new double[] { 50.00, 55, 60, 35, 40, 45, 46, 48, 58, 96 };
            string[] Description = new string[] { "Samsung Galaxy-s21-5G is one of the top selling smartphones that is available Now.",
                      "Samsung Galaxy-s20 is one of the top selling smartphones that is available Now.",
                      "Iphone 13 is one of the top selling smartphones that is available Now.",
                      "Iphone 12 is one of the top selling smartphones that is available Now.",
                      "Pixel 6 is one of the top selling smartphones that is available Now.",
                      "Samsung Note-21 is one of the top selling smartphones that is available Now.",
                 };
            string[] ShortDescription = new string[] { "Samsung Galaxy-s21-5G is one of the top selling smartphones that is available Now.",
                      "Samsung Galaxy-s20 is one of the top selling smartphones that is available Now.",
                      "Iphone 13 is one of the top selling smartphones that is available Now.",
                      "Iphone 12 is one of the top selling smartphones that is available Now.",
                      "Pixel 6 is one of the top selling smartphones that is available Now.",
                      "Samsung Note-21 is one of the top selling smartphones that is available Now.",
                 };
            string[] ProfilePicture = new string[] { "354ebde0-bb74-4631-a37c-76bf17c5c2b8.png", "ab8c9388-1424-4c6e-8fb8-4eae5d6df691.png", "8110b343-7cd7-4d79-875d-b514cfff7a38.png", "85c4f258-9481-489d-a2eb-6535c54a9a49.png", "686a649d-ad77-4b52-879d-207bcb84de48.png", "94aef35d-79be-4ef1-b12a-f2cbf04ff09d.png", "087f2029-dde7-48fe-88a1-3fc4c3d5060a.png", "4c65120a-7a72-4e60-9e4c-e9d4d2cd8bbc.png" };

            for (int i = 0; i < abc; i++)
            {
                Random rnd = new Random();
                int RName = rnd.Next(ProductName.Length);
                int RPrice = rnd.Next(Price.Length);
                int RDescription = rnd.Next(Description.Length);
                int RSDescription = rnd.Next(ShortDescription.Length);
                int RProfilePic = rnd.Next(ProfilePicture.Length);
                var obj = new ProductModel()

                {

                    ProductName = ProductName[RName],
                    ProductPrice = (decimal)Price[RPrice],
                    Description = Description[RDescription],
                    ShortDescription = ShortDescription[RSDescription],
                    ProfilePicture = ProfilePicture[RProfilePic],
                     


                };
                _context.productmodels.Add(obj);
                _context.SaveChanges();

            }
            ViewBag.Message = string.Format(abc +" Items has been generated successfully");
            return View();
        }
    }
}
