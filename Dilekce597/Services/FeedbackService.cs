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
    }
}
