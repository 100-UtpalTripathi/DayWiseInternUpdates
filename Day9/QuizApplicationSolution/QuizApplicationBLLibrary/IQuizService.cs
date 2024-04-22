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
        void EditQuiz(int id, Quiz updatedQuiz);
        void DeleteQuiz(int id);
        List<Quiz> GetPublishedQuizzes();
        Quiz GetQuiz(int id);
        void PublishQuiz(int id);
    }

    
}
