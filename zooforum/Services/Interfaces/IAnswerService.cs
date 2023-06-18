using zooforum.Services.ViewModels;

namespace zooforum.Services.Interfaces
{
    public interface IAnswerService
    {
        Task DeleteAnswer(string id);
        Task CreateAnswer(AnswerViewModel model);
        AnswerViewModel UpdateById(string id);
        Task UpdateAnswer(AnswerViewModel model);
        List<AnswerViewModel> GetAll();
        Task SaveChangesAsync();
        AnswerViewModel GetDetailsById(string id);
        AnswerViewModel Find(string id);
        Task UpdateAsync(AnswerViewModel model);
    }
}
