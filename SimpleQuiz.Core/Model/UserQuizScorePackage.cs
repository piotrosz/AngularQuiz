using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SimpleQuiz.Core.Model
{
    public class UserQuizScorePackage : Entity
    {
        public int ApplicationUserId { get; set; }

        public virtual IEnumerable<UserQuizScore> UserQuizScores { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}
