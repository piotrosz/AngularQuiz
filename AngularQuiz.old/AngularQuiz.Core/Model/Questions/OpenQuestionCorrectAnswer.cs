using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AngularQuiz.Core.Model.Questions
{
    public class OpenQuestionCorrectAnswer : Entity
    {
        public OpenQuestionCorrectAnswer() {}

        public OpenQuestionCorrectAnswer(string singleCorrectAnswerOption)
        {
            if(singleCorrectAnswerOption == null)
            {
                throw new ArgumentNullException("singleCorrectAnswerOption");
            }

            CorrectAnswerOptions = new List<OpenQuestionCorrectAnswerOption> 
            {
                new OpenQuestionCorrectAnswerOption(singleCorrectAnswerOption)
            };
        }

        public OpenQuestionCorrectAnswer(params string[] multipleCorrectAnswerOptions)
        {
            if(multipleCorrectAnswerOptions == null)
            {
                throw new ArgumentNullException("multipleCorrectAnswerOptions");
            }

            var options = new List<OpenQuestionCorrectAnswerOption>();

            foreach(string option in multipleCorrectAnswerOptions)
            {
                options.Add(new OpenQuestionCorrectAnswerOption(option));
            }

            CorrectAnswerOptions = options;
        }

        public OpenQuestionCorrectAnswer(OpenQuestionCorrectAnswerOption singleCorrectAnswerOption)
        {
            CorrectAnswerOptions = new List<OpenQuestionCorrectAnswerOption> { singleCorrectAnswerOption };
        }

        public OpenQuestionCorrectAnswer(IEnumerable<OpenQuestionCorrectAnswerOption> correctAnswerOptions)
        {
            CorrectAnswerOptions = correctAnswerOptions.ToList();
        }

        public int OpenQuestionId { get; set; }

        public int OrderId { get; set; }

        public ICollection<OpenQuestionCorrectAnswerOption> CorrectAnswerOptions { get; set; }
    }
}
