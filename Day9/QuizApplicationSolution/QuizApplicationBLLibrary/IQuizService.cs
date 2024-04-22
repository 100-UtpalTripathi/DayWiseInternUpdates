using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizApplicationModelLibrary;
namespace QuizApplicationBLLibrary
{
    public interface IQuizService
    {
        Quiz CreateQuiz(string title, string description, List<Question> questions);
        void EditQuiz(string title, Quiz updatedQuiz);
        void DeleteQuiz(string title);
        List<Quiz> GetPublishedQuizzes();
        Quiz GetQuiz(string title);
        void PublishQuiz(string title);
    }

    public interface IQuizTakingService
    {
        void TakeQuiz(Quiz quiz);
        void ReviewLastQuizAttempt();
    }
}
