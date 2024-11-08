using HotelProject.WebUI.Models.Mail;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

using MailKit.Net.Smtp;


namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminMailViewModel model)
        {
            MimeMessage mimeMessage=new MimeMessage();
            //kimden olacagı
            MailboxAddress mailboxAddressFrom=new MailboxAddress("HotelierAdmin", "berkomer16@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);
            //kime olacagı
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", model.ReceiverMail); 
            mimeMessage.To.Add(mailboxAddressTo);
            //mesaj icerigi
            var bodyBuilder=new BodyBuilder();
            bodyBuilder.TextBody=model.Body;
            mimeMessage.Body=bodyBuilder.ToMessageBody();

            mimeMessage.Subject=model.Subject;

            SmtpClient client=new SmtpClient();
            client.Connect("smtp.gmail.com", 587,false);
            client.Authenticate("berkomer16@gmail.com", "unyo dcxa oixx rmkj\r\n");
            client.Send(mimeMessage);
            client.Disconnect(true);
            return View();
        }
    }
}
