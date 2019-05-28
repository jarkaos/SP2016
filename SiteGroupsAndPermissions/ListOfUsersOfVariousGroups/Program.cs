using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;

namespace ListOfUsersOfVariousGroups
{
    class Program
    {
        static void Main(string[] args)
        {
            SPSite site = new SPSite(@"http://dev.demo.local");
            SPWeb web = site.RootWeb;

            //Visitors group
            SPGroup visitors = web.AssociatedVisitorGroup;

            foreach (SPUser user in visitors.Users)
            {
                Console.WriteLine("Visitor username is: {0}", user);
            }

            Console.WriteLine("-----------------------------------");

            //Members group
            SPGroup member = web.AssociatedMemberGroup;

            foreach (SPUser user in member.Users)
            {
                Console.WriteLine("Visitor username is: {0}", user);
            }

            Console.WriteLine("-----------------------------------");

            //Owneres group
            SPGroup owner = web.AssociatedOwnerGroup;

            foreach (SPUser user in owner.Users)
            {
                Console.WriteLine("Visitor username is: {0}", user);
            }

            Console.ReadLine();

        }
    }
}
