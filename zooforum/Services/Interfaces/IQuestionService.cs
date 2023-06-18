using zooforum.Services.ViewModels;

namespace zooforum.Services.Interfaces
{
    public interface IQuestionService
    {
        Task DeleteQuestion(string id);
        Task CreateQuestion(QuestionViewModel model);
        QuestionViewModel UpdateById(string id);
        Task UpdateQuestion(QuestionViewModel model);
    }
}
