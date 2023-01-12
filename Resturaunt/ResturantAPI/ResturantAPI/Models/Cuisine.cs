using System.ComponentModel.DataAnnotations;

namespace ResturantAPI.Models;

public class Cuisine
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }

}