using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace ListOfAdmins
{
    class Program
    {
        static void Main(string[] args)
        {
            SPSite site = new SPSite(@"http://dev.demo.local");
            SPWeb web = site.RootWeb;

            SPUserCollection admins = web.SiteAdministrators;

            foreach (SPUser user in admins)
            {
                Console.WriteLine("User name is {0}", user.LoginName);
            }

            Console.ReadLine();
        }
    }
}
