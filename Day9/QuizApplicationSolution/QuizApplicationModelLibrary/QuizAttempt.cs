using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplicationModelLibrary
{
    public class QuizAttempt
    {
        public int Id { get; set; } // Unique Attempt ID
        public int QuizId { get; set; } 
        public DateTime StartTime { get; set; } 
        public DateTime EndTime { get; set; }
        public List<QuestionResponse> Answers { get; set; } 
    }
}
