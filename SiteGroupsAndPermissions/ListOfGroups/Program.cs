using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;

namespace ListOfGroups
{
    class Program
    {
        static void Main(string[] args)
        {
            SPSite site = new SPSite(@"http://dev.demo.local");
            SPWeb web = site.RootWeb;

            SPGroupCollection groupColl = web.SiteGroups;

            foreach (SPGroup group in groupColl)
            {
                Console.WriteLine("Group name is {0}", group);
            }

            Console.ReadLine();
        }
    }
}
