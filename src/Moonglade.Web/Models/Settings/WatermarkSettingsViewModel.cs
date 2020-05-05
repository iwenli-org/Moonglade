using System.ComponentModel.DataAnnotations;

namespace Moonglade.Web.Models.Settings
{
    public class WatermarkSettingsViewModel
    {
        [Required]
        [Display(Name = "启用水印")]
        public bool IsEnabled { get; set; }

        [Required]
        [Display(Name = "保留原图")]
        public bool KeepOriginImage { get; set; }

        [Required]
        [Display(Name = "字体大小")]
        public int FontSize { get; set; }

        [Required]
        [Display(Name = "水印文字")]
        [MaxLength(32)]
        public string WatermarkText { get; set; }
    }
}
