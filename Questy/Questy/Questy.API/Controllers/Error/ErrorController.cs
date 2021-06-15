using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using Questy.Domain.Entities.System;
using Questy.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questy.API.Controllers.Error
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class ErrorController : BaseController
    {
        public ErrorController(IServiceProvider serviceProvider,
            IRepositoryWrapper repositories, 
            IConfiguration configuration) : base(serviceProvider, repositories, configuration)
        {
        }

        [Route("/error")]
        public void Error(string appName)
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var errorLog = new ErrorLog
            {
                App = string.IsNullOrEmpty(appName) ? "API" : appName,
                Date = DateTime.Now,
                Source = context.Error.Source,
                StackTrace = context.Error.StackTrace,
                Message = context.Error.Message,
                AuditUser = "ErrorLogger",
                LastUpdated = DateTime.Now
            };

            repositories.ErrorLogs.Create(errorLog);
            repositories.Save();

            var errorEmailGroup = configuration.GetSection("SMTP:ErrorEmailGroup").Get<List<string>>();

            foreach (var emailAddress in errorEmailGroup)
            {

                // create email message
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(configuration.GetSection("SMTP:Email").Value));
                email.To.Add(MailboxAddress.Parse(emailAddress));
                email.Subject = "Email Tracker";
                email.Body = new TextPart(TextFormat.Html) { Text = $"<h1>Error: {context.Error.Message}</h1><br/>{context.Error.StackTrace}" };

                // send email
                using var smtp = new SmtpClient();
                // gmail
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate(configuration.GetSection("SMTP:Email").Value, configuration.GetSection("SMTP:Password").Value);
                smtp.Send(email);
                smtp.Disconnect(true);
            }

        }
    }
}
