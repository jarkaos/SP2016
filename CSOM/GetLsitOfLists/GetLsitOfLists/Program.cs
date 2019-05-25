using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace GetLsitOfLists
{
    class Program
    {
        static void Main(string[] args)
        {
            SPSite site = new SPSite("http://sp2016:41056");
            SPWeb web = site.OpenWeb();

            foreach (SPList list in web.Lists)
            {
                Console.WriteLine("Title: {0} RowCount: {1} Author: {2} Description: {3}", 
                    list.Title,
                    list.ItemCount,
                    list.Author,
                    list.Description);
            }

            Console.WriteLine("Total Lists: {0}", web.Lists.Count);
            Console.ReadKey();
        }
    }
}
