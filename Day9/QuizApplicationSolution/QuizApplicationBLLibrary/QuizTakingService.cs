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
            Console.WriteLine($"\nTaking quiz: {quiz.Title}\n");
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
                int optionNumber = 1;
                foreach (var option in question.Options)
                {
                    Console.WriteLine($"{optionNumber} - {option}");
                    optionNumber++;
                }

                Console.Write("Your answer (Enter the option number): ");
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

       
            double score = (double)correctAnswers / totalQuestions * 100;
            Console.WriteLine($"\nYour final score: {correctAnswers} out of {totalQuestions} ({score}%).\n");
        }


        public void ReviewLastQuizAttempt(IQuizService quizService)
        {
            if (_quizAttempts.Any())
            {
                var lastAttempt = _quizAttempts.Last();
                Console.WriteLine("\nReviewing last quiz attempt:");
                Console.WriteLine($"\nQuiz ID: {lastAttempt.QuizId}");
                Console.WriteLine($"Start Time: {lastAttempt.StartTime}");
                Console.WriteLine($"End Time: {lastAttempt.EndTime}");
                Console.WriteLine("Question-wise responses:");

                foreach (var response in lastAttempt.Answers)
                {
                    var question = quizService.GetQuiz(lastAttempt.QuizId).Questions.Find(q => q.Id == response.QuestionId);

                    if (question != null)
                    {
                        Console.Write($"Question ID: {response.QuestionId}, Selected Option: {response.SelectedOption}, Correct: {response.IsCorrect}");
                        if (!response.IsCorrect)
                        {
                            Console.WriteLine($"Correct Option was: {question.Options[question.CorrectAnswerIndex]}");
                        }
                        else
                        {
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Question ID: {response.QuestionId}, Selected Option: {response.SelectedOption}, Correct: {response.IsCorrect}, Correct Answer: Not found");
                    }
                }
            }
            else
            {
                Console.WriteLine("No quiz attempts found for review.");
            }
        }


    }
}
