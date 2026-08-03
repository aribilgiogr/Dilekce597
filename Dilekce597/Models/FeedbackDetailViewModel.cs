using System.ComponentModel.DataAnnotations;

namespace Dilekce597.Models
{
    public class FeedbackDetailViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Ad Soyad")]
        public string FullName { get; set; } = null!;

        [Display(Name = "E-Posta Adresi")]
        public string Email { get; set; } = null!;

        [Display(Name = "Kategori")]
        public FeedbackCategory Category { get; set; }

        [Display(Name = "Mesaj")]
        public string Message { get; set; } = null!;

        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreatedAt { get; set; }
    }
}
