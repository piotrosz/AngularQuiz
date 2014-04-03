using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace AngularQuiz.Core.Model
{
    public class UserQuizScore : Entity
    {
        public int UserQuizScorePackageId { get; set; }

        public int QuizId { get; set; }

        [Required]
        public int Points { get; set; }

        [Required]
        public int MaxPoints { get; set; }
    }
}
