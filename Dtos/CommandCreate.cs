
using System.ComponentModel.DataAnnotations;

namespace CommanderMine.Dtos
{
    public class CommandCreate
    {

        [Required]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string platform { get; set; }

    }
}