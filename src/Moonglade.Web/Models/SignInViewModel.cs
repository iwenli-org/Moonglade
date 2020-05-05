using System.ComponentModel.DataAnnotations;

namespace Moonglade.Web.Models
{
    public class SignInViewModel
    {
        [Required]
        [Display(Name = "管理用户")]
        [MaxLength(32)]
        public string Username { get; set; }

        [Required]
        [Display(Name = "用户密码")]
        [DataType(DataType.Password)]
        [MaxLength(32)]
        public string Password { get; set; }
    }
}
