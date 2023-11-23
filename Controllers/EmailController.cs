using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Org.BouncyCastle.Utilities;
using RailwayReservationJWT.Models;

namespace RailwayReservationJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendMail(EmailDTO emailDTO)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("railwayreservationcs@gmail.com"));
            email.To.Add(MailboxAddress.Parse(emailDTO.email));

            email.Subject = "Railway Tickets Booked";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text =emailDTO.body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate("railwayreservationcs@gmail.com", "wzxcxdosewnwtcsm");
            smtp.Send(email);
            smtp.Disconnect(true);


            return Ok();
        }
    }
}
