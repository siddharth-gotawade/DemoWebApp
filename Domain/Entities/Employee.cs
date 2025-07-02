using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        //public string? Grade { get; set; }
        public DateTime DOB { get; set; }
    }
}
