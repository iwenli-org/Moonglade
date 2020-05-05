using System.ComponentModel.DataAnnotations;

namespace Moonglade.Web.Models.Settings
{
    public class EmailSettingsViewModel
    {
        [Display(Name = "启用电子邮件通知")]
        public bool EnableEmailSending { get; set; }

        [Display(Name = "评价回复通知")]
        public bool SendEmailOnCommentReply { get; set; }

        [Display(Name = "新评价通知")]
        public bool SendEmailOnNewComment { get; set; }

        [Required]
        [Display(Name = "管理员邮箱")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(64)]
        public string AdminEmail { get; set; }

        [Required]
        [Display(Name = "管理员邮箱昵称")]
        [MaxLength(64)]
        public string EmailDisplayName { get; set; }

        [Display(Name = "禁止邮件域")]
        [MaxLength(1024)]
        public string BannedMailDomain { get; set; }
    }
}
