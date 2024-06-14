using System.ComponentModel.DataAnnotations;

namespace Mail_App.Models
{
    public class UserSıgnViewModel
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı Adını giriniz...!")]
        public string UserName { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifreyi giriniz...!")]
        public string Password { get; set; }
    }
}
