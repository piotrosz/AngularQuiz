using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularQuiz.Core.Model.Questions
{
    public class CategoryQuestionOption : Entity
    {
        public int CategoryQuestionId { get; set; }

        [Required]
        [StringLength(1024)]
        [JsonIgnore]
        public string Category { get; set; }

        [Required]
        [StringLength(5000)]
        public string Content { get; set; }

        [Required]
        public int OrderId { get; set; }
    }
}
