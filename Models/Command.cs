using System.ComponentModel.DataAnnotations;

namespace CommanderMine.Models
{
    public class Command
    {

        public int Id { get; set; }

        [Required]
        public string HowTo { get; set; }
       
        [Required]
        [MaxLength(250)]
        public string Line { get; set; }
        [Required]
        public string platform { get; set; }
    }
}