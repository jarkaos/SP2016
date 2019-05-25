using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace GetListOfFarmSolutions
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (SPSolution x in SPFarm.Local.Solutions)
            {
                Console.WriteLine("Solution name: {0} Status: {1} ID: {2}", x.Name, x.Status, x.SolutionId);

            }

            Console.WriteLine("done");
            Console.ReadKey();
        }
    }
}
