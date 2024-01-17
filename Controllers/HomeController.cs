using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using my_portfolio.Models;
using my_portfolio.Models;
using System.Net;
using System.Net.Mail;
namespace my_portfolio.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Skills()
    {
        return View();
    }
    public IActionResult About()
    {
        return View();
    }
    public IActionResult Contact()
    {
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Contact(EmailFormModel model)
    {
        if (ModelState.IsValid)
        {
            var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress("Brennanmj123@gmail.com"));  // replace with valid value 
            message.From = new MailAddress(model.FromEmail);  // replace with valid value
            message.Subject = "Your email subject";
            message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "brennanmj123@gmail.com",  // replace with valid value
                    Password = "Bj#12312002"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp-mail.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
                return RedirectToAction("Sent");
            }
        }
        return View(model);
    }
    public ActionResult Sent()
    {
        return View();
    }
}
