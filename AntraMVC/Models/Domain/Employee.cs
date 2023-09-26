using System.ComponentModel.DataAnnotations;

namespace AntraMVC.Models.Domain
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        [Range(1, 80, ErrorMessage = "age should be 1-80")]
        public int Age { get; set; }
        [Required]
        public string Desciption { get; set; }
       
    }
}
