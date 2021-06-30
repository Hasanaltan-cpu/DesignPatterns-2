using BaseProject.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebApp.ObserverDP.Observer
{
    public class UserObserverSendEmail : IUserObserver
    {
        private readonly IServiceProvider _serviceProvider;

        public UserObserverSendEmail(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void CreateUser(AppUser appUser)
        {

            var logger = _serviceProvider.GetRequiredService<ILogger<UserObserverSendEmail>>();


            var mailMessage = new MailMessage();

            var smtpClient = new SmtpClient("Sunucu bilgisi");

            mailMessage.From = new MailAddress("Gönderilecek E-mail girilecek");
            mailMessage.To.Add(new MailAddress(appUser.Email));

            mailMessage.Subject = "Wellcome to hasanwebsite.com.tr.";
            mailMessage.Body = "<p>General rule of this website ; ..... </p>";
            mailMessage.IsBodyHtml = true;
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential("UserName", "Password");
            smtpClient.Send(mailMessage);
            logger.LogInformation($"E-mail has been sent to user :  { appUser.UserName}");










            throw new NotImplementedException();
        }
    }
}
