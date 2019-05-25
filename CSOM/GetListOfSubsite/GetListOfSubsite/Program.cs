using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace GetListOfSubsite
{
    class Program
    {
        static void Main(string[] args)
        {
            SPSite site = new SPSite("http://sp2016:41056");

            foreach (SPWeb web in site.AllWebs)
            {
                Console.WriteLine("Title: {0} URL: {1}", web.Title, web.Url);
            }

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
