using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuiz.Core.Model.Questions
{
    public class OpenQuestion : Question<OpenQuestionCorrectAnswer>
    {
        public OpenQuestion() { }

        public OpenQuestion(string content, string singleCorrectAnswer)
        {
            Content = content;
            Answers = new List<OpenQuestionCorrectAnswer>
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
            Answers = multipleCorrectAnswers.Select(a => new OpenQuestionCorrectAnswer(a)).ToList();
        }

        public override QuestionType QuestionType
        {
            get { return QuestionType.Open; }
        }

        public override ICollection<OpenQuestionCorrectAnswer> Answers { get; set; }
    }

}
