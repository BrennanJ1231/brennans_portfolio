using System.ComponentModel.DataAnnotations;
namespace my_portfolio.Models;
public class EmailFormModel
{
    //Email Sender Name
    [Required, Display(Name = "Your name")]
    public string FromName { get; set; }

    //Email Sender Email id
    [Required, Display(Name = "Your email"), EmailAddress]
    public string FromEmail { get; set; }

    // Message body
    [Required]
    public string Message { get; set; }
}