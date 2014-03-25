using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuiz.Core.Model.Questions
{
    public class SortQuestionOption : Entity
    {
        [Required]
        [StringLength(1024)]
        public string Content { get; set; }

        [Required]
        public int OrderId { get; set; }

        public int SortQuestionId { get; set; }
    }
}
