using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace GetListOfFarmAndServices
{
    class Program
    {
        static void Main(string[] args)
        {
            SPFarm farm = SPFarm.Local;
            Console.WriteLine("My farm name is: {0} Farm Type is: {1} Status: {2}",
                farm.Name,
                farm.TypeName,
                farm.Status);

            //ShowAllServers(farm);
            ShowAllServices(farm);
            Console.ReadKey();
        }

        private static void ShowAllServers(SPFarm farm)
        {
            foreach (SPService service in farm.Services)
            {
                Console.WriteLine("Service Name: {0} Status: {1}", service.Name, service.Status);
            }

        }

        private static void ShowAllServices(SPFarm farm)
        {
            foreach (SPServer server in farm.Servers)
            {
                Console.WriteLine("Server Name: {0} Role: {1}", server.Name, server.Role);
            }

        }
    }
}
