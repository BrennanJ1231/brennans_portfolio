using System.ComponentModel.DataAnnotations;

namespace my_portfolio.Models;

public class Project
{
    public int Id { get; set; }
    public string? Title { get; set; }
    [DataType(DataType.Date)]
    public DateTime ProjectDate { get; set; }
    public string Link { get; set; }
}