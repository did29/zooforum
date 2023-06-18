using zooforum.Services.ViewModels;

namespace zooforum.Services.Interfaces
{
    public interface IQuestionService
    {
        Task DeleteQuestion(string id);
        Task CreateQuestion(QuestionViewModel model);
        QuestionViewModel UpdateById(string id);
        Task UpdateQuestion(QuestionViewModel model);
        List<QuestionViewModel> GetAll();
        Task SaveChangesAsync();
        QuestionViewModel GetDetailsById(string id);
        QuestionViewModel Find(string id);
        Task UpdateAsync(QuestionViewModel model);
    }
}
