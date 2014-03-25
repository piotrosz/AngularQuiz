using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SimpleQuiz.Core.Model.Questions
{
    public interface IQuestion
    {
        int Id { get; set; }
        int QuizId { get; set; }
        int OrderId { get; set; }
        string Content { get; set; }
    }

    public abstract class Question<TEntity> : Entity, IQuestion where TEntity : Entity
    {
        [Required]
        public int QuizId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public string Content { get; set; }

        public abstract ICollection<TEntity> Answers { get; set; }
    }
}
