using AutoMapper;
using Dilekce597.Data;
using Dilekce597.Models;
using Microsoft.EntityFrameworkCore;

namespace Dilekce597.Services
{
    public class FeedbackService(FeedbackDb db, IMapper mapper) : IFeedbackService
    {
        public async Task<bool> CreateAsync(FeedbackCreateViewModel model)
        {
            /*
            var feedback = new Feedback
            {
                FullName = model.FullName,
                Email = model.Email,
                Category = model.Category,
                Message = model.Message
            };
            */
            var feedback = mapper.Map<Feedback>(model);
            await db.Feedbacks.AddAsync(feedback);
            return (await db.SaveChangesAsync()) > 0;
        }

        public async Task<IEnumerable<FeedbackListItemViewModel>> GetAsync()
        {
            var feedbacks = await db.Feedbacks.OrderByDescending(x => x.CreatedAt).ToListAsync();
            return mapper.Map<IEnumerable<FeedbackListItemViewModel>>(feedbacks);
        }

        public async Task<FeedbackDetailViewModel> GetAsync(int id)
        {
            var feedback = await db.Feedbacks.FindAsync(id);
            return mapper.Map<FeedbackDetailViewModel>(feedback);
        }

        public async Task<IEnumerable<FeedbackListItemViewModel>> GetAsync(FeedbackFilterViewModel filterModel)
        {
            // SELECT * FROM Feedbacks hazırlandı ama execute edilmedi, WHERE ve benzeri eklemeleri bekliyor.
            var query = db.Feedbacks.AsNoTracking().AsQueryable();
            if (!string.IsNullOrWhiteSpace(filterModel.SearchTerm))
            {
                var term = filterModel.SearchTerm.Trim().ToUpper();
                query = query.Where(q =>
                                    q.FullName.ToUpper().Contains(term) ||
                                    q.Email.ToUpper().Contains(term) ||
                                    q.Message.ToUpper().Contains(term));
            }

            if (filterModel.Category.HasValue)
            {
                query = query.Where(q => q.Category == filterModel.Category.Value);
            }

            if (filterModel.StartDate.HasValue)
            {
                // Saat bilgisini 00:00:00.000 olarak alır.
                query = query.Where(q => q.CreatedAt >= filterModel.StartDate.Value.Date);
            }

            if (filterModel.EndDate.HasValue)
            {
                // Saat bilgisini 23:59:59.999 olarak alır.
                var endDate = filterModel.EndDate.Value.Date.AddDays(1).AddTicks(-1);
                query = query.Where(q => q.CreatedAt <= endDate);
            }

            var filteredFeedbacks = await query.OrderByDescending(q => q.CreatedAt).ToListAsync();
            return mapper.Map<IEnumerable<FeedbackListItemViewModel>>(filteredFeedbacks);
        }
    }
}
