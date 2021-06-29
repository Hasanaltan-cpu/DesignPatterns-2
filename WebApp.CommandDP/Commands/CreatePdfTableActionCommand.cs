using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.CommandDP.Commands
{
    public class CreatePdfTableActionCommand<T> : ITableButtonActionCommand
    {

        private readonly PdfFile<T> _pdfFile;

        public CreatePdfTableActionCommand(PdfFile<T> pdfFile)
        {
            _pdfFile = pdfFile;
        }

        public IActionResult Execute()
        {
            var pdfMemoryStream = _pdfFile.Create();
            return new FileContentResult(pdfMemoryStream.ToArray(), _pdfFile.FileType)
            {
                FileDownloadName = _pdfFile.FileName
            }; 
        }
    }
}
