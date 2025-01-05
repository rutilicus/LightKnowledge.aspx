using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LightKnowledge.aspx.Models
{
    [Table("KnowledgeTag")]
    public class KnowledgeTag
    {
        [Key]
        public int RelationId { get; set; }

        [Required]
        public int KnowledgeId { get; set; }

        [Required]
        public int TagId { get; set; }
    }
}