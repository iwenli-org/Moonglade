using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Moonglade.Web.Models.Settings
{
    public class FriendLinkSettingsViewModelWrap
    {
        public FriendLinkSettingsViewModel FriendLinkSettingsViewModel { get; set; }

        public FriendLinkEditViewModel FriendLinkEditViewModel { get; set; }

        public IReadOnlyList<Model.FriendLink> FriendLinks { get; set; }

        public FriendLinkSettingsViewModelWrap()
        {
            FriendLinkEditViewModel = new FriendLinkEditViewModel();
        }
    }

    public class FriendLinkSettingsViewModel
    {
        [Display(Name = "显示友情链接")]
        public bool ShowFriendLinksSection { get; set; }
    }
}
