using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopLearn.Core.DTOs.AdminDashboard
{
    public class DashboardViewModel
    {
        public int CourseCount { get; set; }

        public int UserCount { get; set; }

        public int TeacherCount { get; set; }

        public int OrderCountInMonth { get; set; }

        public int TotalOrderAmountInMonth { get; set; }
    }
}
