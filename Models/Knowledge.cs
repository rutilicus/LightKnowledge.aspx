using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LightKnowledge.aspx.Models
{
    [Table("Knowledge")]
    public class Knowledge
    {
        [Key]
        public int KnowledgeId {  get; set; }

        [Required]
        public String Title { get; set; }

        [Required]
        public string Description { get; set; }
    }
}