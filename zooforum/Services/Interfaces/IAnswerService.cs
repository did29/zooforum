using zooforum.Services.ViewModels;

namespace zooforum.Services.Interfaces
{
    public interface IAnswerService
    {
        Task DeleteAnswer(string id);
        Task CreateAsync(AnswerViewModel model);
        AnswerViewModel UpdateById(string id);
        Task UpdateAsync(AnswerViewModel model);
    }
}
