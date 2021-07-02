using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.AdapterDP.Services
{
    public class ImageProcessAdapter : IImageProcess
    {

        private readonly IAdvanceImageProcess _advanceImageProcess;

        public ImageProcessAdapter(IAdvanceImageProcess advanceImageProcess)
        {
            _advanceImageProcess = advanceImageProcess;
        }

        public void AddWaterMark(string text, string fileName, Stream imageStream)
        {
            _advanceImageProcess.AddWaterMarkImage(imageStream, text, $"wwwroot/watermarks/{fileName}", Color.FromArgb(128, 255, 255, 255), Color.FromArgb(0, 355, 355, 355));
        }
    }
}
