using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;

namespace WebApp.ChainOfResponsibilityDP.ChainOfResponsibilityDP
{
    public class SendEmailProcessHandler:ProcessHandler
    {
        private readonly string _fileName;
        private readonly string _toEmail;

        public SendEmailProcessHandler(string fileName, string toEmail)
        {
            _fileName = fileName;
            _toEmail = toEmail;
        }

       public  override object handle(object o)
        {


            var zipMemoryStream = o as MemoryStream;
            zipMemoryStream.Position = 0;
            var mailMessage = new MailMessage();
            var spmtClient = new SmtpClient("srvm11.trww.com");
            mailMessage.From = new MailAddress("deneme@kariyersistem.com");
            mailMessage.To.Add(new MailAddress(_toEmail));
            mailMessage.Subject = "Zip dosyası";
            mailMessage.Body = "<p>Zip Dosyası ektedir. </p>";

            Attachment attachment = new Attachment(zipMemoryStream, _fileName, MediaTypeNames.Application.Zip);

            mailMessage.Attachments.Add(attachment);


            mailMessage.IsBodyHtml = true;
            spmtClient.Port = 587;
            spmtClient.Credentials = new NetworkCredential("deneme@kariyersistem.com", "Password12+");

            spmtClient.Send(mailMessage);

            return base.handle(null);// There is no , next chain that's why u can set to null. 
        }


    }
}
