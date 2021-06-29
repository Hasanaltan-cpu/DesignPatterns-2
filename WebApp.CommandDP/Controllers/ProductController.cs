using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.IO.Pipelines;
using System.Linq;
using System.Threading.Tasks;
using BaseProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.CommandDP.Commands;
using WebApp.CommandDP.Commands.Enums;
using WebApp.CommandDP.Models;

namespace WebApp.CommandDP.Controllers
{
    public class ProductController : Controller
    {

        private readonly AppIdentityDbContext _context;

        public ProductController(AppIdentityDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }


        public async Task<IActionResult> Create(int type)
        {
            var products = await _context.Products.ToListAsync();
            FileCreateInvoker fileCreateInvoker = new FileCreateInvoker();


            FileType fileType = (FileType)type;

            switch (fileType)
            {
                case FileType.ExcellFile:
                    ExcellFile<Product> excellFile = new(products);
                    fileCreateInvoker.SetCommand(new CreateExcellTableActionCommand<Product>(excellFile));
                    break;
                case FileType.Pdf:
                    PdfFile<Product> pdfFile = new(products, HttpContext);
                    fileCreateInvoker.SetCommand(new CreatePdfTableActionCommand<Product>(pdfFile));
                    break;
                default:
                    break;
            }

            return fileCreateInvoker.CreateFile();
        }



        public async Task<IActionResult> CreateFiles()
        {
            var products = await _context.Products.ToListAsync();
            ExcellFile<Product> excellFile = new(products);
            PdfFile<Product> pdfFile = new(products, HttpContext);
            FileCreateInvoker fileCreateInvoker = new FileCreateInvoker();

            fileCreateInvoker.AddCommand(new CreateExcellTableActionCommand<Product>(excellFile));
            fileCreateInvoker.AddCommand(new CreatePdfTableActionCommand<Product>(pdfFile));

            var fileResult = fileCreateInvoker.CreateFiles();
            using (var zipMemoryStream = new MemoryStream())
            {
                using(var archive = new ZipArchive(zipMemoryStream,ZipArchiveMode.Create))
                {
                    foreach (var item in fileResult)
                    {
                        var fileContent = item as FileContentResult;

                        var zipFile = archive.CreateEntry(fileContent.FileDownloadName);

                        using (var zipEntryStream = zipFile.Open())
                        {
                            await new MemoryStream(fileContent.FileContents).CopyToAsync(zipEntryStream);
                        }
                    }
                }


                return File(zipMemoryStream.ToArray(), "application/zip", "all.zip");
            }

        }

    }

}
