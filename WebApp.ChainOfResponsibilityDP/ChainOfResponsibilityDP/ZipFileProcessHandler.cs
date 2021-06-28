using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ChainOfResponsibilityDP.ChainOfResponsibilityDP
{
    public class ZipFileProcessHandler<T> : ProcessHandler
    {

        public override object handle(object o)
        {
            var excelMemoryStream =  o as MemoryStream;

            excelMemoryStream.Position = 0;

            using (var zipstream = new MemoryStream())
            {
                using (var  archive = new ZipArchive(zipstream, ZipArchiveMode.Create,true))
                {
                    var zipFile = archive.CreateEntry($"{typeof(T).Name}.xlsx");

                    using (var zipEntry = zipFile.Open())
                    {
                        excelMemoryStream.CopyTo(zipEntry);
                    }
                }
                return base.handle(zipstream);
            }
        }
    }
}
