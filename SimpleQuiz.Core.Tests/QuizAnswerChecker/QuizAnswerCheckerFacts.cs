using SimpleQuiz.Core.AnswerCheck;
using SimpleQuiz.Core.Model;
using SimpleQuiz.Core.Model.Questions;
using SimpleQuiz.Core.Tests.Stubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SimpleQuiz.Core.Tests.QuizAnswerChecker
{
    public class QuizAnswerCheckerFacts
    {
        private Quiz _quiz;
        private QuizAnswersChecker _target;

        public QuizAnswerCheckerFacts()
        {
            _quiz = StubQuizes.Quiz;
            _target = new QuizAnswersChecker(new QuestionCheckStrategies
                {
                    CategoryQuestionStrategy = new CheckAnswerCategoryQuestionStrategy(),
                    OpenQuestionStrategy = new CheckAnswerOpenQuestionStrategy(),
                    TestQuestionStrategy = new CheckAnswerTestQuestionStrategy(),
                    SortQuestionStrategy = new CheckAnswerSortQuestionStrategy()
                });
        }

        [Fact]
        public void should_check_correct_answers()
        {
            // Arrange
            var userAnswers = new QuizUserAnswers();

            {
                var answer1 = new QuestionUserAnswer(_quiz.OpenQuestions.ElementAt(0).Id);
                answer1.Answers.Add("Kaczka");
                userAnswers.OpenQuestionsAnswers.Add(answer1);
            }
            {
                var answer2 = new QuestionUserAnswer(_quiz.OpenQuestions.ElementAt(1).Id);
                answer2.Answers.Add("red");
                userAnswers.OpenQuestionsAnswers.Add(answer2);
            }
            {
                var answer3 = new QuestionUserAnswer(_quiz.OpenQuestions.ElementAt(2).Id);
                answer3.Answers.Add("red");
                answer3.Answers.Add("black");
                answer3.Answers.Add("blue");
                userAnswers.OpenQuestionsAnswers.Add(answer3);
            }
            {
                var answer4 = new QuestionUserAnswer(_quiz.OpenQuestions.ElementAt(3).Id);
                answer4.Answers.Add("czerwony");
                answer4.Answers.Add("negro");
                answer4.Answers.Add("blue");
                userAnswers.OpenQuestionsAnswers.Add(answer4);
            }
            {
                var answer5 = new QuestionUserAnswer(_quiz.TestQuestions.ElementAt(0).Id);
                answer5.Answers.Add("A");
                userAnswers.TestQuestionsAnswers.Add(answer5);
            }
            {
                var answer6 = new QuestionUserAnswer(_quiz.TestQuestions.ElementAt(1).Id);
                answer6.Answers.Add("A");
                answer6.Answers.Add("B");
                answer6.Answers.Add("C");
                userAnswers.TestQuestionsAnswers.Add(answer6);
            }
            {
                var answer7 = new QuestionUserAnswer(_quiz.SortQuestions.ElementAt(0).Id);
                answer7.Answers.Add("A");
                answer7.Answers.Add("B");
                answer7.Answers.Add("C");
                userAnswers.SortQuestionsAnswers.Add(answer7);
            }

            {
                var answer8 = new QuestionUserAnswer(_quiz.CategoryQuestions.ElementAt(0).Id);
                answer8.Answers.Add("Alphabet");
                answer8.Answers.Add("Alphabet");
                answer8.Answers.Add("Number");
                answer8.Answers.Add("Bird");
                answer8.Answers.Add("Bird");
                userAnswers.CategoryQuestionsAnswers.Add(answer8);
            }

            // Act
            var result = _target.Check(_quiz, userAnswers);

            // Assert
            Assert.True(result.CorrectAnswersCount == userAnswers.TotalAnswersCount);
        }
    }
}
