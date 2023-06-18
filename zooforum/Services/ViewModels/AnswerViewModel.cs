using zooforum.Data.DataModel;

namespace zooforum.Services.ViewModels
{
    public class AnswerViewModel
    {
        public string Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }
    }
}
