using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleQuiz
{
    public abstract class AskQuestionsStrategy
    {
        public AskQuestionsStrategy(Quiz quiz)
        {
            if (quiz == null || quiz.Count == 0)
                throw new ArgumentNullException("Quiz cannot be null");

            this.Quiz = quiz;
            IsLast = false;
        }

        public Quiz Quiz { get; set; }

        public abstract Question GetNextQuestion();

        public bool IsLast { get; set; }
    }

	// Asks all questions once in random order
    public class RandomQuestionsStrategy : AskQuestionsStrategy
    {
        private Queue<Question> queue;
     
        public RandomQuestionsStrategy(Quiz quiz) : base(quiz)
        {
            quiz.Shuffle();

            queue = new Queue<Question>();

            foreach (var item in quiz)
                queue.Enqueue(item);
        }
        
        public override Question GetNextQuestion()
        {
            if (queue.Count == 1)
                IsLast = true;

            if (queue.Count == 0)
                return null;

            return queue.Dequeue();
        }
    }

	// Asks all questions once starting from the oldest question
    public class QueueQuestionsStrategy : AskQuestionsStrategy
    {
        private Queue<Question> queue;

        public QueueQuestionsStrategy(Quiz quiz) : base(quiz)
        {
            queue = new Queue<Question>();

            foreach (var item in quiz)
                queue.Enqueue(item);
        }

        public override Question GetNextQuestion()
        {
            if (queue.Count == 1)
                IsLast = true;

            if (queue.Count == 0)
                return null;

            return queue.Dequeue();
        }
    }

	// Asks all question once starting from the newest question
    public class StackQuestionsStrategy : AskQuestionsStrategy
    {
        private Stack<Question> stack;

        public StackQuestionsStrategy(Quiz quiz) : base(quiz)
        {
            stack = new Stack<Question>();

            foreach (var item in quiz)
            {
                stack.Push(item);
            }
        }

        public override Question GetNextQuestion()
        {
            if (stack.Count == 1)
                IsLast = true;

            if (stack.Count == 0)
                return null;

            return stack.Pop();
        }
    }
}
