using System.Collections.Generic;

namespace QuizAPI.Models
{
    public class Content
    {
        public string question { get; set; }
        public string correct_answer { get; set; }
        public List<string> incorrect_answers { get; set; }        
    }

    public class Questions
    {
        public string UserAnswer { get; set; }
        public List<Content> results { get; set; }
    }
}