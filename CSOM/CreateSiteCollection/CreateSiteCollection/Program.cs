using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace CreateSiteCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            SPSite site = new SPSite("http://sp2016:41056");
            SPWebApplication webapp = site.WebApplication;

            webapp.Sites.Add("/sites/Training",
                "Training Site",
                "SPS 2013 Training",
                1033,
                "STS#0",
                @"AMERICO\administrator",
                "Administrator",
                "sp_install@americo.local");

            Console.WriteLine("Done!");
            Console.ReadKey();

        }
    }
}
