using zooforum.Data.DataModel;
using zooforum.Data;
using zooforum.Services.Interfaces;
using zooforum.Services.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace zooforum.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly ApplicationDbContext context;
        public QuestionService(ApplicationDbContext post)
        {
            context = post;
        }

        public List<QuestionViewModel> GetAll()
        {
            return context.Question.Select(question => new QuestionViewModel()
            {
                Id = question.Id,
                Title = question.Title,
                Description = question.Description,
                CreatedAt = question.CreatedAt

            }).ToList();
        }
        public async Task CreateQuestion(QuestionViewModel model)
        {
            Question question = new Question 
            {
                Id = Guid.NewGuid().ToString(),
                Title = model.Title,
                Description = model.Description,
                CreatedAt = model.CreatedAt
            };

            await context.Question.AddAsync(question);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(QuestionViewModel model)
        {
            var question = await context.Question.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (question != null)
            {
                question.Title = model.Title;
                question.Description = model.Description;
                question.CreatedAt = model.CreatedAt;

                await context.SaveChangesAsync();
            }
        }
        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
        public QuestionViewModel Find(string id)
        {
            var question = context.Question.FirstOrDefault(x => x.Id == id);
            var questionViewModel = new QuestionViewModel()
            {
                Id = question.Id,
                Title = question.Title,
                Description = question.Description,
                CreatedAt = question.CreatedAt
            };

            return questionViewModel;
        }
        public async Task DeleteQuestion(string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("Eror!");
            }
            if (id != null)
            {
                var animalDb = context.Question.FirstOrDefault(x => x.Id == id);
                context.Question.Remove(animalDb);
                await context.SaveChangesAsync();
            }
        }
        public QuestionViewModel GetDetailsById(string id)
        {
            QuestionViewModel question = context.Question
                .Select(question => new QuestionViewModel
                {
                    Id = question.Id,
                    Title = question.Title,
                    Description = question.Description,
                    CreatedAt = question.CreatedAt,
                }).SingleOrDefault(question => question.Id == id);

            return question;
        }
        public QuestionViewModel UpdateById(string id)
        {
            QuestionViewModel question = context.Question
                .Select(question => new QuestionViewModel
                {
                    Id = question.Id,
                    Title = question.Title,
                    Description = question.Description,
                    CreatedAt = question.CreatedAt,
                }).SingleOrDefault(question => question.Id == id);

            return question;
        }
        public async Task UpdateQuestion(QuestionViewModel model)
        {
            Question question = context.Question.Find(model.Id);

            bool isQuestionNull = question == null;
            if (isQuestionNull)
            {
                return;
            }

            context.Question.Update(question);
            await context.SaveChangesAsync();
        }
    }
}