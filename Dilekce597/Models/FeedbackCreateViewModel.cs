using System.ComponentModel.DataAnnotations;

namespace Dilekce597.Models
{
    public class FeedbackCreateViewModel
    {
        [Display(Name = "Ad Soyad", Prompt = "Ad Soyad")]
        [Required(ErrorMessage = "Ad Soyad alanı zorunludur!")]
        [StringLength(100, ErrorMessage = "Ad Soyad en fazla 100 karakter olabilir!")]
        public string FullName { get; set; } = null!;

        [Display(Name = "E-Posta Adresi", Prompt = "E-Posta Adresi")]
        [Required(ErrorMessage = "E-Posta alanı zorunludur!")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz!")]
        public string Email { get; set; } = null!;

        [Display(Name = "Kategori", Prompt = "Kategori")]
        [Required(ErrorMessage = "Kategori seçimi zorunludur!")]
        public FeedbackCategory Category { get; set; }

        [Display(Name = "Mesaj", Prompt = "Mesaj")]
        [Required(ErrorMessage = "Mesaj alanı zorunludur!")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Mesaj 10 ile 1000 karakter arasında olmalıdır!")]
        public string Message { get; set; } = null!;
    }
}
