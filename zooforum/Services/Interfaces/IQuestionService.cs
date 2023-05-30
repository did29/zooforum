using zooforum.Services.ViewModels;

namespace zooforum.Services.Interfaces
{
    public interface IQuestionService
    {
        Task DeleteQuestion(string id);
        Task CreateAsync(QuestionViewModel model);
        QuestionViewModel UpdateById(string id);
        Task UpdateAsync(QuestionViewModel model);
    }
}
