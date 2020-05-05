using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace Moonglade.Web.Models
{
    public class PostEditViewModel
    {
        [HiddenInput]
        public Guid PostId { get; set; }

        [Required(ErrorMessage = "请输入标题。")]
        [MaxLength(128)]
        public string Title { get; set; }

        [Required(ErrorMessage = "请输入slug.")]
        [RegularExpression(@"[a-z0-9\-]+", ErrorMessage = "只允许使用小写字母和连字符。")]
        [MaxLength(128)]
        public string Slug { get; set; }

        [JsonIgnore]
        public List<CheckBoxViewModel> CategoryList { get; set; }

        [Required(ErrorMessage = "请至少选择一个分类。")]
        public Guid[] SelectedCategoryIds { get; set; }

        [Required]
        [Display(Name = "启用评论")]
        public bool EnableComment { get; set; }

        [Required(ErrorMessage = "请输入内容。")]
        [JsonIgnore]
        [DataType(DataType.MultilineText)]
        public string EditorContent { get; set; }

        [Required]
        [Display(Name = "立即发布")]
        public bool IsPublished { get; set; }

        [Display(Name = "网站地图")]
        public bool ExposedToSiteMap { get; set; }

        [Display(Name = "Feed订阅")]
        public bool FeedIncluded { get; set; }

        [Display(Name = "标签")]
        [MaxLength(128)]
        public string Tags { get; set; }

        [Required(ErrorMessage = "请输入语言代码。")]
        [Display(Name = "内容语言")]
        [RegularExpression("^[a-z]{2}-[a-zA-Z]{2}$", ErrorMessage = "语言代码格式不正确，例如 en-us")]
        public string ContentLanguageCode { get; set; }

        [Display(Name = "发布日期")]
        [DataType(DataType.Date)]
        public DateTime? PublishDate { get; set; }

        [Display(Name = "更改发布日期")]
        public bool ChangePublishDate { get; set; }

        public PostEditViewModel()
        {
            PostId = Guid.Empty;
            ContentLanguageCode = "zh-cn";
        }
    }
}
