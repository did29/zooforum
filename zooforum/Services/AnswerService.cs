using zooforum.Data;
using zooforum.Services.Interfaces;
using zooforum.Services.ViewModels;
using zooforum.Data.DataModel;
using Microsoft.EntityFrameworkCore;

namespace zooforum.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly ApplicationDbContext context;
        public AnswerService(ApplicationDbContext post)
        {
            context = post;
        }

        public List<AnswerViewModel> GetAll()
        {
            return context.Answer.Select(answer => new AnswerViewModel()
            {
                Id = answer.Id,
                Content = answer.Content,
                CreatedAt = answer.CreatedAt

            }).ToList();
        }
        public async Task CreateAnswer(AnswerViewModel model)
        {
            Answer answer = new Answer
            {
                Id = Guid.NewGuid().ToString(),
                Content = model.Content,
                CreatedAt = model.CreatedAt
            };

            await context.Answer.AddAsync(answer);
            await context.SaveChangesAsync(); 
            
        }
        public async Task UpdateAsync(AnswerViewModel model)
        {
            var answer = await context.Answer.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (answer != null)
            {
                answer.Content = model.Content;
                answer.UpdatedAt = DateTime.Now;

                await context.SaveChangesAsync();
            }
        }
        public async Task SaveChangesAsync()
            {
                await context.SaveChangesAsync();
            }
        public async Task DeleteAnswer(string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("Eror!");
            }
            if (id != null)
            {
                var animalDb = context.Answer.FirstOrDefault(x => x.Id == id);
                context.Answer.Remove(animalDb);
                await context.SaveChangesAsync();
            }
        }
        public AnswerViewModel GetDetailsById(string id)
        {
            AnswerViewModel answer = context.Answer
                .Select(answer => new AnswerViewModel
                {
                    Id = answer.Id,
                    Content = answer.Content,
                    CreatedAt = answer.CreatedAt,
                }).SingleOrDefault(answer => answer.Id == id);

            return answer;
        }
        public AnswerViewModel Find(string id)
        {
            var answer = context.Answer.FirstOrDefault(x => x.Id == id);
            var answerViewModel = new AnswerViewModel()
            {
                Id = answer.Id,
                Content = answer.Content,
                CreatedAt = answer.CreatedAt,
            };

            return answerViewModel;
        }
        public async Task UpdateAnswer(AnswerViewModel model)
        {
            var answer = context.Answer.FirstOrDefault(x => x.Id == model.Id);

            if (answer != null)
            {
                answer.Content = model.Content;
                answer.CreatedAt = model.CreatedAt;

                await context.SaveChangesAsync();
            }
        }
        public AnswerViewModel UpdateById(string id)
        {
            AnswerViewModel answer = context.Answer
                .Select(answer => new AnswerViewModel
                {
                    Id = answer.Id,
                    Content = answer.Content,
                    CreatedAt = answer.CreatedAt,
                }).SingleOrDefault(answer => answer.Id == id);

            return answer;
        }
        public async Task Update(AnswerViewModel model)
        {
            Answer answer = context.Answer.Find(model.Id);

            bool isAnswerNull = answer == null;
            if (isAnswerNull)
            {
                return;
            }

            context.Answer.Update(answer);
            await context.SaveChangesAsync();
        }
    }
}
