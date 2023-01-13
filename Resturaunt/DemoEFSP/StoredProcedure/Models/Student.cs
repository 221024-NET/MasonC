using System.ComponentModel.DataAnnotations;

namespace StoredProcedure.Models
{
    public class Student
    {
        [Key]
        public int? Id { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
    }
}