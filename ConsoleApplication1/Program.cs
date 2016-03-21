using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SsisUnit;
using SsisUnitBase.EventArgs;

namespace ConsoleApplication1
{
    class Program
    {
        static string resultvalue;
        
        static void Main(string[] args)
        {
            SsisTestSuite testSuite = new SsisTestSuite(@"C:\Users\Ravi\PalProjects\RandD\SampleSSISUnit\SSISUnitTests\ssisUnitExample.ssisUnit");
            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            testSuite.CommandCompleted += TestSuiteCommandCompleted;
            Test test = testSuite.Tests["Get Table Count"];
            Context context = testSuite.CreateContext();
            //var target = new SqlCommand(testSuite);
            bool rs = test.Execute(context);
            //TreeItem<Log> ti = context.Log;
            //testSuite.Execute();

            Console.ReadKey();
        }

        static void TestSuiteAssertCompleted(object sender, AssertCompletedEventArgs e)
        {
            if (e.AssertName == "Verify Table Count")
            {
                resultvalue = e.TestExecResult.TestResultMsg;
                if (e.TestExecResult.TestPassed)
                {
                    Console.WriteLine(e.AssertName + " Passed" + " with value :" + resultvalue);
                }
                else
                {
                    Console.WriteLine(e.AssertName + " Failed" + " with value :" + resultvalue);
                }
            }
        }

        static void TestSuiteCommandCompleted(object sender, CommandCompletedEventArgs e)
        {
            Console.WriteLine("Result of " + e.CommandName + " " + e.Results);
        }
    }
}
