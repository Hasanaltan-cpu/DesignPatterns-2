using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.CommandDP.Commands
{
    public class CreateExcellTableActionCommand<T> : ITableButtonActionCommand
    {
        private readonly ExcellFile<T> _excellFile;

        public CreateExcellTableActionCommand(ExcellFile<T> excellFile)
        {
            _excellFile = excellFile;
        }

        public IActionResult Execute()
        {
            var excellMemoryStream = _excellFile.Create();
            return new FileContentResult(excellMemoryStream.ToArray(), _excellFile.FileType)
            {
                FileDownloadName = _excellFile.FileName
            };
        }
    }
}
