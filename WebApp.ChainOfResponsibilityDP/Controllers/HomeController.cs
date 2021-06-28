using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BaseProject.Models;
using WebApp.ChainOfResponsibilityDP.ChainOfResponsibilityDP;
using WebApp.ChainOfResponsibilityDP.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppIdentityDbContext _context;


        public HomeController(ILogger<HomeController> logger,
                                AppIdentityDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public async Task<IActionResult> SendEmailAsync()
        {

            var products = await _context.Products.ToListAsync();
            var excellProcessHandler = new ExcellProcessHandler<Product>();

            var zipFileProcessHandler = new ZipFileProcessHandler<Product>();

            var sendEmailProcessHandler = new SendEmailProcessHandler("product.zip","hsnaltan13@gmail.com");

            excellProcessHandler.SetNext(zipFileProcessHandler).SetNext(sendEmailProcessHandler);

            excellProcessHandler.handle(products);

            return View(nameof(Index));
        }
    }
}
