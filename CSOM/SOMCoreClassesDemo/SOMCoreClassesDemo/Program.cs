using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace SOMCoreClassesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            SPFarm currentFarm = SPFarm.Local;
            Console.WriteLine("Farm: " + currentFarm.Name);

            foreach (SPService service in currentFarm.Services)
            {
                if (service is SPWebService)
                {
                    SPWebService currentWebService = service as SPWebService;
                    Console.WriteLine("SPWebService: " + currentWebService.DisplayName);

                    foreach (SPWebApplication webApp in currentWebService.WebApplications)
                    {
                        Console.WriteLine("--Web Application: " + webApp.DisplayName + " contains " + webApp.Sites.Count.ToString() + " SPSite objects");

                        foreach (SPSite siteCollection in webApp.Sites)
                        {
                            Console.WriteLine("----Site Collection: " + siteCollection.Url + " contains " + siteCollection.AllWebs.Count.ToString() + " spWeb");
                            foreach (SPWeb web in siteCollection.AllWebs)
                            {
                                Console.WriteLine("------Web Site: " + web.Title + " contains " + web.Lists.Count.ToString() + " sites");
                                Console.WriteLine("------------Lists: ");
                                foreach(SPList list in web.Lists)
                                {
                                    Console.WriteLine("-------------" + list.Title);
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}
