using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using TopLearn.Core.Services.Interfaces;

namespace TopLearn.Web.Pages.Admin.Users
{
    [PermissionChecker("مدیریت کاربران")]
    public class UsersListModel : PageModel
    {
        #region Dependency Injection

        private readonly IUserService _userService;

        public UsersListModel(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        public UsersForAdminViewModel UsersViewModel { get; set; }

        [BindProperty(SupportsGet = true)]
        public int TakeCount { get; set; } = 10;

        [BindProperty(SupportsGet = true)]
        public string SearchByUserName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchByEmail { get; set; }

        public void OnGet(int take = 10, int pageId = 1, string userName = "", string email = "")
        {
            if (!string.IsNullOrEmpty(SearchByUserName))
                userName = SearchByUserName;

            if (!string.IsNullOrEmpty(SearchByEmail))
                email = SearchByEmail;

            if (TakeCount > 0)
                take = TakeCount;

            UsersViewModel = _userService.GetUsers(take, pageId, email, userName);
        }
    }
}
