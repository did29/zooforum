namespace zooforum.Data.DataModel
{
    public class Answer
    {
        public string Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string QuestionId { get; set; }

        public virtual Question Question { get; set; }
    }
}
