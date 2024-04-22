using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplicationModelLibrary
{
    public class QuestionResponse
    {
        public int QuestionId { get; set; } // ID of the question
        public string SelectedOption { get; set; } // Option selected by the user
        public bool IsCorrect { get; set; } // Indicates whether the response is correct
    }
}
