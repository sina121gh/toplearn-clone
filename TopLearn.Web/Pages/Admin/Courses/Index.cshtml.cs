using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.DTOs.Course;

namespace TopLearn.Web.Pages.Courses
{
    [PermissionChecker("مدیریت دوره ها")]
    public class IndexModel : PageModel
    {
        private readonly ICourseService _courseService;

        public IndexModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public CoursesListForAdminViewModel CoursesViewModel { get; set; }

        [BindProperty(SupportsGet = true)]
        public int TakeCount { get; set; } = 10;

        public void OnGet(int take = 10, int pageId = 1)
        {
            if (TakeCount > 0)
                take = TakeCount;
            CoursesViewModel = _courseService.GetCoursesForAdmin(take, pageId);
        }
    }
}
