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
    public IActionResult Contact(EmailFormModel model)
{
    try
    {
        if (ModelState.IsValid)
        {
            var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            MailMessage message = new MailMessage();
            message.To.Add(new MailAddress("Brennanmj123@gmail.com")); // replace with valid value
            message.From = new MailAddress(model.FromEmail); // replace with valid value
            message.Subject = "Portofolio email";
            message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("brennanmj123@gmail.com", "cabn glzh rabp jgbm"); // replace with valid value
            smtp.Port = 587;
            smtp.EnableSsl = true;

            smtp.Send(message);
            return RedirectToAction("Sent");
            
        }
        return View(model);
    }
    catch (SmtpException ex)
    {
        Console.WriteLine("SMTP Exception: " + ex.Message);
        return View("Error");
    }
    catch (Exception ex)
    {
        // Log or handle other exceptions
        Console.WriteLine("Error: " + ex.Message);
        return View("Error");
    }
}

    public ActionResult Sent()
    {
        return View();
    }
}
