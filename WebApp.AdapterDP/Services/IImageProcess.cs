using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.AdapterDP.Services
{
   public  interface IImageProcess
    {
        void AddWaterMark(string text, string fileName, Stream imageStream);

    }
}
