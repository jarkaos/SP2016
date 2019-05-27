using System;
using System.ComponentModel;
using System.IO;
using System.Web.UI.WebControls.WebParts;
using System.Linq;

namespace LINQDemo.VWPCourses
{
    [ToolboxItemAttribute(false)]
    public partial class VWPCourses : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public VWPCourses()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lbCourses.Items.Clear();
            QueryDemoDataContext qdc = new QueryDemoDataContext("http://dev.demo.local");

            qdc.ObjectTrackingEnabled = false;
            StringWriter log = new StringWriter();

            qdc.Log = log;

            var CoursesList = qdc.Courses;

            var Courses = from c in CoursesList 
                          where c.CourseCategory.Contains(lbCategory.Text)
                          select c;

            foreach (var Course in Courses)
            {
                lbCourses.Items.Add(Course.Title);
            }
            lblResultCount.Text = "Found: " + Courses.Count() + " items";

        }
    }
}
