using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SimpleQuiz.Core.Model
{
    public class Question : Entity
    {
        public Question() { }

        public Question(string content, string singleCorrectAnswer)
        {
            Content = content;
            CorrectAnswers = new List<QuestionCorrectAnswer>
            {
                new QuestionCorrectAnswer(singleCorrectAnswer)
            };
        }

        /// <param name="multipleCorrectAnswers">The correct answers. 
        /// All the answers have to be provided to answer the question. 
        /// All the answers have single option.</param>
        public Question(string content, params string[] multipleCorrectAnswers)
        {
            if(multipleCorrectAnswers == null)
            {
                throw new ArgumentNullException("multipleCorrectAnswers");
            }

            Content = content;
            CorrectAnswers = multipleCorrectAnswers.Select(a => new QuestionCorrectAnswer(a));
        }

        public int OrderId { get; set; }

        [Required]
        public string Content { get; set; }

        public virtual IEnumerable<QuestionCorrectAnswer> CorrectAnswers { get; set; }
    }
}
