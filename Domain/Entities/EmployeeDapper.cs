using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class EmployeeDapper
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        //public string? Grade { get; set; }
        public DateTime DOB { get; set; }
    }
}
