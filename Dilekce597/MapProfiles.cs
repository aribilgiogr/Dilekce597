using AutoMapper;
using Dilekce597.Models;

namespace Dilekce597
{
    public class MapProfiles:Profile
    {
        public MapProfiles()
        {
            CreateMap<FeedbackCreateViewModel, Feedback>();
            CreateMap<Feedback, FeedbackListItemViewModel>();
            CreateMap<Feedback, FeedbackDetailViewModel>();
        }
    }
}
