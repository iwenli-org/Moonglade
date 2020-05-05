using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Moonglade.Web.Models.Settings
{
    public class GeneralSettingsViewModel
    {
        [Required]
        [Display(Name = "Meta Keyword")]
        [MaxLength(1024)]
        public string MetaKeyword { get; set; }

        [Required]
        [Display(Name = "Meta Description")]
        [MaxLength(1024)]
        public string MetaDescription { get; set; }

        [Required]
        [Display(Name = "Logo 文本")]
        [MaxLength(16)]
        public string LogoText { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z0-9\s.\-\[\]]+", ErrorMessage = "仅允许使用字母，数字，-和[]")]
        [Display(Name = "版权")]
        [MaxLength(64)]
        public string Copyright { get; set; }

        [Required]
        [Display(Name = "博客站点标题")]
        [MaxLength(16)]
        public string SiteTitle { get; set; }

        [Required]
        [Display(Name = "作者名称")]
        [MaxLength(32)]
        public string BloggerName { get; set; }

        [Required]
        [Display(Name = "作者描述")]
        [DataType(DataType.MultilineText)]
        [MaxLength(256)]
        public string BloggerDescription { get; set; }

        [Required]
        [Display(Name = "作者简介")]
        [MaxLength(32)]
        public string BloggerShortDescription { get; set; }

        [Display(Name = "Side Bar Pitch (HTML)")]
        [DataType(DataType.MultilineText)]
        [MaxLength(2048)]
        public string SideBarCustomizedHtmlPitch { get; set; }

        [Display(Name = "Footer Pitch (HTML)")]
        [DataType(DataType.MultilineText)]
        [MaxLength(4096)]
        public string FooterCustomizedHtmlPitch { get; set; }

        public TimeSpan SelectedUtcOffset { get; set; }

        [MaxLength(64)]
        public string SelectedTimeZoneId { get; set; }

        public List<SelectListItem> TimeZoneList { get; set; }

        [MaxLength(32)]
        public string SelectedThemeFileName { get; set; }

        public List<SelectListItem> ThemeList { get; set; }
    }
}
