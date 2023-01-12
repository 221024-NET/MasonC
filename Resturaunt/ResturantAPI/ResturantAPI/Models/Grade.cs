using System.ComponentModel.DataAnnotations;

namespace ResturantAPI.Models;

public class Grade
{
    [Key]
    public int Id { get; set; }
    public int grade { get; set; }
    public int RestId { get; set; }
    
}