using System.ComponentModel.DataAnnotations;

namespace ResturantAPI.Models;

public class Score
{
    [Key]
    public int? Id { get; set; }
    public int? score { get; set; }
    public DateTime? date_submit { get; set; }
    public int? RestId { get; set; }
}