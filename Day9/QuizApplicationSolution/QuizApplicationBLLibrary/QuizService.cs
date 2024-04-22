using QuizApplicationDALLibrary;
using QuizApplicationModelLibrary;

namespace QuizApplicationBLLibrary
{
    public class QuizService : IQuizService
    {
        readonly QuizRepository _quizRepository;

        public QuizService()
        {
            _quizRepository = new QuizRepository();
        }

        public Quiz CreateQuiz(string title, string description, List<Question> questions)
        {
            var quiz = new Quiz(title, description, questions)
            {
                IsPublished = false // Initialize IsPublished to false
            };
            return _quizRepository.Add(quiz);
        }

        public void EditQuiz(int id, Quiz updatedQuiz)
        {
            var existingQuiz = _quizRepository.Get(id);
            if (existingQuiz != null)
            {
                _quizRepository.Update(id, updatedQuiz);
            }
            else
            {
                throw new KeyNotFoundException($"Quiz with id '{id}' not found.");
            }
        }

        public void DeleteQuiz(int id)
        {
            var existingQuiz = _quizRepository.Get(id);
            if (existingQuiz != null)
            {
                _quizRepository.Delete(id);
            }
            else
            {
                throw new KeyNotFoundException($"Quiz with id '{id}' not found.");
            }
        }

        public List<Quiz> GetPublishedQuizzes()
        {
            List<Quiz> publishedQuizzes = new List<Quiz>();
            foreach (var quiz in _quizRepository.GetAll())
            {
                if (quiz.IsPublished)
                {
                    publishedQuizzes.Add(quiz);
                }
            }
            return publishedQuizzes;
        }

        public Quiz GetQuiz(int id)
        {
            var existingQuiz = _quizRepository.Get(id);
            if (existingQuiz != null)
            {
               return existingQuiz;
            }
            else
            {
                throw new KeyNotFoundException($"Quiz with id '{id}' not found.");
            }
        }

        public void PublishQuiz(int id)
        {
            var existingQuiz = _quizRepository.Get(id);
            if (existingQuiz != null)
            {
                if (existingQuiz.IsPublished)
                {
                    // Quiz is already published
                    Console.WriteLine($"Quiz with id '{id}' is already published.");
                }
                else
                {
                    // Publish the quiz
                    existingQuiz.IsPublished = true;
                    _quizRepository.Update(id, existingQuiz);
                    Console.WriteLine($"Quiz with id '{id}' has been successfully published.");
                }
            }
            else
            {
                throw new KeyNotFoundException($"Quiz with id '{id}' not found.");
            }
        }

        public List<Quiz> GetAllQuizzes()
        {
            List<Quiz> allQuizzes = new List<Quiz>();

            // Get all quizzes from the repository
            allQuizzes.AddRange(_quizRepository.GetAll());

            return allQuizzes;
        }
    }
}
