using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebApi.Models
{
    public class ProjectViewModel
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public Nullable<int> Priority { get; set; }

        public Nullable<int> TotalTasks { get; set; }
        public Nullable<int> CompletedTasks { get; set; }
    }
}