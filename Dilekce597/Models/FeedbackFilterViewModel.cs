using System.ComponentModel.DataAnnotations;

namespace Dilekce597.Models
{
    public class FeedbackFilterViewModel
    {
        [Display(Name = "Arama", Prompt = "Ad, E-Posta ve Mesaj...")]
        public string? SearchTerm { get; set; }

        [Display(Name = "Kategori", Prompt = "Kategori")]
        public FeedbackCategory? Category { get; set; }

        [Display(Name = "Başlangıç Tarihi", Prompt = "Başlangıç Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Bitiş Tarihi", Prompt = "Bitiş Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
    }
}
