using System;
using System.Collections.Generic;

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

        public AskQuestionsStrategy()
        {
            IsLast = false;
        }

        public Quiz Quiz { get; set; }

        public abstract Question GetNextQuestion();

        public bool IsLast { get; set; }
    }

    // Asks all questions once in random order
    public class RandomQuestionsStrategy : AskQuestionsStrategy
    {
        private Queue<Question> queue = null;

        public RandomQuestionsStrategy() : base() { }

        public RandomQuestionsStrategy(Quiz quiz) : base(quiz) { }

        public override Question GetNextQuestion()
        {
            if (queue == null)
            {
                queue = new Queue<Question>();

                Quiz.Shuffle();

                foreach (var item in Quiz)
                    queue.Enqueue(item);
            }

            if (queue.Count == 1)
                IsLast = true;

            if (queue.Count == 0)
                return null;

            return queue.Dequeue();
        }
    }

    // Asks all questions one time in order starting from the oldest question
    public class QueueQuestionsStrategy : AskQuestionsStrategy
    {
        private Queue<Question> queue = null;

        public QueueQuestionsStrategy() : base() { }

        public QueueQuestionsStrategy(Quiz quiz) : base(quiz) { }

        public override Question GetNextQuestion()
        {
            if (queue == null)
            {
                queue = new Queue<Question>();

                foreach (var item in Quiz)
                    queue.Enqueue(item);
            }

            if (queue.Count == 1)
                IsLast = true;

            if (queue.Count == 0)
                return null;

            return queue.Dequeue();
        }
    }

    // Asks all question one time in order starting from the newest question
    public class StackQuestionsStrategy : AskQuestionsStrategy
    {
        private Stack<Question> stack = null;

        public StackQuestionsStrategy() : base() { }

        public StackQuestionsStrategy(Quiz quiz) : base(quiz) { }

        public override Question GetNextQuestion()
        {
            if (stack == null)
            {
                stack = new Stack<Question>();

                foreach (var item in Quiz)
                    stack.Push(item);
            }

            if (stack.Count == 1)
                IsLast = true;

            if (stack.Count == 0)
                return null;

            return stack.Pop();
        }
    }
}
