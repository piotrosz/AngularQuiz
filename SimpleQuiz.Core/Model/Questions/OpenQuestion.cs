using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuiz.Core.Model.Questions
{
    public class OpenQuestion : Question
    {
        public OpenQuestion() { }

        public OpenQuestion(string content, string singleCorrectAnswer)
        {
            Content = content;
            CorrectAnswers = new List<OpenQuestionCorrectAnswer>
            {
                new OpenQuestionCorrectAnswer(singleCorrectAnswer)
            };
        }

        /// <param name="multipleCorrectAnswers">The correct answers. 
        /// All the answers have to be provided to answer the question. 
        /// All the answers have single option.</param>
        public OpenQuestion(string content, params string[] multipleCorrectAnswers)
        {
            if (multipleCorrectAnswers == null)
            {
                throw new ArgumentNullException("multipleCorrectAnswers");
            }

            Content = content;
            CorrectAnswers = multipleCorrectAnswers.Select(a => new OpenQuestionCorrectAnswer(a)).ToList();
        }

        public virtual ICollection<OpenQuestionCorrectAnswer> CorrectAnswers { get; set; }
    }

}
