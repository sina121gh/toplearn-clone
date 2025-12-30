using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TopLearn.Web.Pages.Admin.Users
{
    public class DeletedUsersListModel : PageModel
    {
        #region Dependency Injection

        private readonly IUserService _userService;

        public DeletedUsersListModel(IUserService userService)
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

            UsersViewModel = _userService.GetDeletedUsers(take, pageId, email, userName);
        }
    }
}
