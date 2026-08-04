using Dilekce597.Models;

namespace Dilekce597.Services
{
    public interface IFeedbackService
    {
        Task<bool> CreateAsync(FeedbackCreateViewModel model);
        Task<IEnumerable<FeedbackListItemViewModel>> GetAsync();
        Task<IEnumerable<FeedbackListItemViewModel>> GetAsync(FeedbackFilterViewModel filterModel);
        Task<FeedbackDetailViewModel> GetAsync(int id);
    }
}
