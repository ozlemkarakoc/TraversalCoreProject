using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProject.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Lütfen Kullanıcı Adınız Giriniz")]
        public string username { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")]
        public string password { get; set; }
    }
}
