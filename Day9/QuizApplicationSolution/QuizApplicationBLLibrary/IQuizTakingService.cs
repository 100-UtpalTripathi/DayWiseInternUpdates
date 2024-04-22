using QuizApplicationModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplicationBLLibrary
{
    public interface IQuizTakingService
    {
        void TakeQuiz(Quiz quiz);
        void ReviewLastQuizAttempt();
    }
}
