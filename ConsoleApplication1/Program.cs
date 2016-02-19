using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Dts.Runtime;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string pkgLocation;
            Package pkg;
            Application app;
            DTSExecResult pkgResults;

            pkgLocation = "C:\\Users\\Ravi\\PalProjects\\RandD\\SampleSSISUnit\\TestPackages\\Package1.dtsx";
            app = new Application();
            pkg = app.LoadPackage(pkgLocation, null);
            //pkgResult = pkg.Execute();

            //Console.WriteLine(pkgResults.ToString());
            Console.ReadKey();
        }
    }
}
