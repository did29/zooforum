using zooforum.Data.DataModel;

namespace zooforum.Services.ViewModels
{
    public class QuestionViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }


        public virtual ICollection<Answer> Answers { get; set; }
    }
}
