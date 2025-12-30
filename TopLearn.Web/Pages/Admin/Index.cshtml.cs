using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using TopLearn.Core.DTOs.AdminDashboard;

namespace TopLearn.Web.Pages.Admin
{
    [PermissionChecker("پنل مدیریت")]
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly ICourseService _courseService;
        private readonly IOrderService _orderService;

        public IndexModel(IUserService userService,
            ICourseService courseService,
            IOrderService orderService)
        {
            _userService = userService;
            _courseService = courseService;
            _orderService = orderService;
        }

        public DashboardViewModel DashboardViewModel { get; set; }

        public async Task OnGet()
        {
            var date = DateTime.Now;

            DashboardViewModel = new DashboardViewModel
            {
                UserCount = await _userService.GetUserCountAsync(),
                TeacherCount = await _userService.GetTeacherCountAsync(),
                CourseCount = await _courseService.GetCourseCountAsync(),
                OrderCountInMonth = await _orderService.GetOrderCountOfMonthAsync(date),
                TotalOrderAmountInMonth = await _orderService.GetTotalOrderAmountOfMonthAsync(date)
            };
        }
    }
}
