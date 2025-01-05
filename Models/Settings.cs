using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LightKnowledge.aspx.Models
{
    [Table("Settings")]
    public class Settings
    {
        [Key]
        public string Key { set; get; }

        [Required]
        public string Value { set; get; }
    }
}
