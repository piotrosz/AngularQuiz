using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NgQuiz.Web.Models
{
    public class Phrase : Entity
    {
        [Required]
        [MinLength(3)]
        [MaxLength(1024)]
        public string Content { get; set; }

        [MinLength(3)]
        [MaxLength(1024)]
        public string Translation { get; set; }

        public DateTime DateAdded { get; set; }
    }
}