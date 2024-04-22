using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplicationModelLibrary
{
    public class QuizAttempt
    {
        public int Id { get; set; } // Unique identifier for the attempt
        public int QuizId { get; set; } // ID of the quiz being attempted
        public DateTime StartTime { get; set; } // Start time of the attempt
        public DateTime EndTime { get; set; } // End time of the attempt
        public List<QuestionResponse> Answers { get; set; } // User responses for each question
    }
}
