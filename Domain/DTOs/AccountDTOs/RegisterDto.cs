using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.AccountDTOs
{
    public class RegisterDto
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Username { get; set; }

        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Phone { get; set; }
        
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Password { get; set; }
        
        [Display(Name = "تکرار رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Compare(nameof(Password), ErrorMessage = "رمز عبور و تکرار آن یکسان نیست!")]
        public string RePassword { get; set; }
    }
}