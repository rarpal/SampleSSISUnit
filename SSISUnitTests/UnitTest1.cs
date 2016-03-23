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

        public void TestSuiteAssertCompleted(object sender, AssertCompletedEventArgs e)
        {
            if (e.AssertName != null)
            {
                testResult = e.TestExecResult;
                isTestPassed = e.TestExecResult.TestPassed;
            }
        }

        [TestMethod]
        public void TestPackage()
        {
            testSuite = new SsisTestSuite(@"C:\Users\Ravi\PalProjects\RandD\SampleSSISUnit\SSISUnitTests\ssisUnitExample.ssisUnit");
            test = testSuite.Tests["TestPackage"];
            context = testSuite.CreateContext();
            bool rs = test.Execute(context);
            Assert.AreEqual<bool>(true, rs);
        }

        [TestMethod]
        public void TestBatch1Staging()
        {
            testSuite = new SsisTestSuite(@"C:\Users\Ravi\PalProjects\RandD\SampleSSISUnit\SSISUnitTests\ssisUnitExample.ssisUnit");
            test = testSuite.Tests["TestBatch1Staging"];
            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = false;
            context = testSuite.CreateContext();
            bool rs = test.Execute(context);
            Assert.AreEqual<bool>(true, isTestPassed);
            testSuite.AssertCompleted -= TestSuiteAssertCompleted;
        }

        [TestMethod]
        public void TestBatch1NewRecords()
        {
            testSuite = new SsisTestSuite(@"C:\Users\Ravi\PalProjects\RandD\SampleSSISUnit\SSISUnitTests\ssisUnitExample.ssisUnit");
            test = testSuite.Tests["TestBatch1NewContacts"];
            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = false;
            context = testSuite.CreateContext();
            bool rs = test.Execute(context);
            Assert.AreEqual<bool>(true, isTestPassed);
            testSuite.AssertCompleted -= TestSuiteAssertCompleted;

        }

    }
}
