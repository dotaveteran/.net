using System.ComponentModel.DataAnnotations;

namespace SchoolService.Models
{
    public class Shkola
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }       

        [Required]
        public string Post { get; set; }   

        [Required]
        public string Grade { get; set; }
    }
}