using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleQuiz.Core.Model
{
    public class QuestionCorrectAnswer : Entity
    {
        public QuestionCorrectAnswer() {}

        public QuestionCorrectAnswer(string singleCorrectAnswerOption)
        {
            if(singleCorrectAnswerOption == null)
            {
                throw new ArgumentNullException("singleCorrectAnswerOption");
            }

            CorrectAnswerOptions = new List<QuestionCorrectAnswerOption> 
            {
                new QuestionCorrectAnswerOption(singleCorrectAnswerOption)
            };
        }

        public QuestionCorrectAnswer(params string[] multipleCorrectAnswerOptions)
        {
            if(multipleCorrectAnswerOptions == null)
            {
                throw new ArgumentNullException("multipleCorrectAnswerOptions");
            }

            var options = new List<QuestionCorrectAnswerOption>();

            foreach(string option in multipleCorrectAnswerOptions)
            {
                options.Add(new QuestionCorrectAnswerOption(option));
            }

            CorrectAnswerOptions = options;
        }

        public QuestionCorrectAnswer(QuestionCorrectAnswerOption singleCorrectAnswerOption)
        {
            CorrectAnswerOptions = new List<QuestionCorrectAnswerOption> { singleCorrectAnswerOption };
        }

        public QuestionCorrectAnswer(IEnumerable<QuestionCorrectAnswerOption> correctAnswerOptions)
        {
            CorrectAnswerOptions = correctAnswerOptions;
        }

        public int QuestionId { get; set; }

        public int OrderId { get; set; }

        public virtual IEnumerable<QuestionCorrectAnswerOption> CorrectAnswerOptions { get; set; }
    }
}
