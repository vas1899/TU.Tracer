using System;
using System.Collections.Generic;

namespace Domain
{
    public class Workday
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid EmployeeId { get; set; }
        public int RoleID { get; set; }

        public ICollection<WorkdayEmployee> WorkdayEmployees { get; set; }

    }
}
