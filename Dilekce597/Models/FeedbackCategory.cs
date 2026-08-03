using System.ComponentModel.DataAnnotations;

namespace Dilekce597.Models
{
    public enum FeedbackCategory
    {
        [Display(Name = "Şikayet")]
        Complaint = 1,

        [Display(Name = "Görüş / Öneri")]
        Suggestion = 2,

        [Display(Name = "Teknik Destek")]
        TechnicalSupport = 3
    }
}
