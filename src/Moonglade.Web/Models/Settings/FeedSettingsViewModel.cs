using System.ComponentModel.DataAnnotations;

namespace Moonglade.Web.Models.Settings
{
    public class FeedSettingsViewModel
    {
        [Display(Name = "RSS项目")]
        public int RssItemCount { get; set; }

        [Required]
        [Display(Name = "版权")]
        [MaxLength(64)]
        public string RssCopyright { get; set; }

        [Required]
        [Display(Name = "描述")]
        [MaxLength(512)]
        public string RssDescription { get; set; }

        [Required]
        [Display(Name = "RSS生成器名称")]
        [MaxLength(64)]
        public string RssGeneratorName { get; set; }

        [Required]
        [Display(Name = "标题")]
        [MaxLength(64)]
        public string RssTitle { get; set; }

        [Required]
        [Display(Name = "作者姓名")]
        [MaxLength(32)]
        public string AuthorName { get; set; }

        [Display(Name = "使用完整的博客文章内容而不是摘要")]
        public bool UseFullContent { get; set; }

        public FeedSettingsViewModel()
        {
            RssItemCount = 20;
        }
    }
}
