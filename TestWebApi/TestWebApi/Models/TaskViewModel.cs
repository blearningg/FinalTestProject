using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebApi.Models
{
    public class TaskViewModel
    {
       
            public int TaskID { get; set; }
            public Nullable<int> ParentID { get; set; }
            public int ProjectID { get; set; }
            public string TaskDesc { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }
            public Nullable<int> Priority { get; set; }
            public string Status { get; set; }

            public  string ParentTaskDesc { get; set; }
           public  string ProjectName { get; set; }
            public Nullable<int> UserID { get; set; }
    }
}