using System.ComponentModel.DataAnnotations;

namespace ResturantAPI.Models;

public class RestConnCuisine
{
    [Key]
    public int Id { get; set; }
    public int RestId  { get; set; }
    public int CuisineId { get; set; }
}