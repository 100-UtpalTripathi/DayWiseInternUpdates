using System;
using System.Collections.Generic;
using System.Linq;
using QuizApplicationBLLibrary;
using QuizApplicationModelLibrary;

namespace QuizApplicationBLLibrary
{
    public class QuizTakingService : IQuizTakingService
    {
        private readonly List<QuizAttempt> _quizAttempts; // Store quiz attempts for review

        public QuizTakingService()
        {
            _quizAttempts = new List<QuizAttempt>();
        }

        public void TakeQuiz(Quiz quiz)
        {
            Console.WriteLine($"Taking quiz: {quiz.Title}");
            var quizAttempt = new QuizAttempt
            {
                QuizId = quiz.Id,
                StartTime = DateTime.Now,
                Answers = new List<QuestionResponse>()
            };

            int totalQuestions = quiz.Questions.Count;
            int correctAnswers = 0;

            foreach (var question in quiz.Questions)
            {
                Console.WriteLine($"Question: {question.Text}");
                foreach (var option in question.Options)
                {
                    Console.WriteLine($"- {option}");
                }

                Console.Write("Your answer (enter the option number): ");
                int selectedOption;
                while (!int.TryParse(Console.ReadLine(), out selectedOption) || selectedOption < 1 || selectedOption > question.Options.Count)
                {
                    Console.WriteLine("Invalid input. Please enter a valid option number.");
                    Console.Write("Your answer: ");
                }

                var response = new QuestionResponse
                {
                    QuestionId = question.Id,
                    SelectedOption = question.Options[selectedOption - 1],
                    IsCorrect = selectedOption - 1 == question.CorrectAnswerIndex
                };

                if (response.IsCorrect)
                {
                    correctAnswers++;
                }

                quizAttempt.Answers.Add(response);
            }

            quizAttempt.EndTime = DateTime.Now;
            _quizAttempts.Add(quizAttempt);

            Console.WriteLine("Quiz completed successfully!");

            // Calculate and display final score
            double score = (double)correctAnswers / totalQuestions * 100;
            Console.WriteLine($"Your final score: {correctAnswers} out of {totalQuestions} ({score}%).");
        }


        public void ReviewLastQuizAttempt()
        {
            if (_quizAttempts.Any())
            {
                var lastAttempt = _quizAttempts.Last();
                Console.WriteLine("Reviewing last quiz attempt:");
                Console.WriteLine($"Quiz ID: {lastAttempt.QuizId}");
                Console.WriteLine($"Start Time: {lastAttempt.StartTime}");
                Console.WriteLine($"End Time: {lastAttempt.EndTime}");
                Console.WriteLine("Question-wise responses:");
                foreach (var response in lastAttempt.Answers)
                {
                    Console.WriteLine($"Question ID: {response.QuestionId}, Selected Option: {response.SelectedOption}, Correct: {response.IsCorrect}");
                }
            }
            else
            {
                Console.WriteLine("No quiz attempts found for review.");
            }
        }
    }
}
