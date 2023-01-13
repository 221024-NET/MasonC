using System.ComponentModel.DataAnnotations;

namespace ResturantAPI.Models;

public class Restaurant
{
    [Key]
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Street_addr { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
}