
namespace QuizApplicationModelLibrary
{

    // Quiz class represents a quiz with a title, description, and a list of questions.
    public class Quiz
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public bool IsPublished { get; set; }
        public List<Question> Questions { get; set; }

        public Quiz(string title, string description, List<Question> questions)
        {
            Title = title;
            Description = description;
            Questions = questions;
            IsPublished = false;
        }
    }
}
