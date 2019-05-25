using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace Create_Subsite
{
    class Program
    {
        static void Main(string[] args)
        {
            SPSite site = new SPSite("http://sp2016:41056");

            SPWeb web = site.AllWebs.Add("BlogSite", "Blog Site", "Some Description", 1033, "BLOG#0", false, false);

            
            Console.WriteLine("Done!");
            Console.ReadKey();

        
        }
    }
}
