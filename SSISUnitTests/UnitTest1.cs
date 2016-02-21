using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SsisUnit;
using SsisUnitBase;
using SsisUnitBase.EventArgs;
using System.Xml;
using System.Diagnostics;

namespace SSISUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private SsisTestSuite testSuite;
        private string testFile;
        private TestResult testResult;
        private Test test;
        private Context context;
        private bool isTestPassed;

        [TestInitialize]
        public void Initialize()
        {

        }

        //[TestMethod]
        //public void TestMethod1()
        //{
        //    var target = new SqlCommand(testSuite);
        //    var doc = new XmlDocument();
        //    doc.Load(testFile);
        //    //Debug.Assert(doc.DocumentElement != null, "doc.DocumentElement != null");
        //    //Debug.Assert(doc.DocumentElement["Setup"] != null, "doc.DocumentElement != null");
        //    XmlNode command = doc.DocumentElement["Setup"]["SqlCommand"];

        //    object result = target.Execute(command, null, null);
        //    //object result = target.Execute();
        //    Assert.AreEqual(80, result);
        //}

        [TestMethod]
        public void TestMethod2()
        {
            testSuite = new SsisTestSuite(@"C:\Users\Ravi\PalProjects\RandD\SampleSSISUnit\SSISUnitTests\ssisUnitExample.ssisUnit");
            //testFile = UnpackToFile("SSISUnitTests.ssisUnitExample.ssisUnit");
            //testSuite = new SsisTestSuite(testFile);
            test = testSuite.Tests["Get Table Count"];
            context = testSuite.CreateContext();
            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = true;
            bool rs = test.Execute(context);
            
        }

        public void TestSuiteAssertCompleted(object sender, AssertCompletedEventArgs e)
        {
            if (e.AssertName == "Verify Table Count")
            {
                testResult = e.TestExecResult;
                isTestPassed = e.TestExecResult.TestPassed;
                Assert.AreEqual(true, isTestPassed);
            }
        }
    }
}
