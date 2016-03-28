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
    public class UnitTest_LoadContacts
    {
        private SsisTestSuite testSuite;
        private TestResult testResult;
        private Test test;
        private Context context;
        private bool isTestPassed;

        [TestInitialize]
        public void Initialize()
        {

        }

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
            testSuite = new SsisTestSuite(@"C:\Users\Ravi\PalProjects\RandD\SampleSSISUnit\SSISUnitTests\UnitTest_LoadContacts.ssisUnit");
            test = testSuite.Tests["TestPackage"];
            context = testSuite.CreateContext();
            bool rs = test.Execute(context);
            Assert.AreEqual<bool>(true, rs);
        }

        [TestMethod]
        public void TestBatch1Staging()
        {
            testSuite = new SsisTestSuite(@"C:\Users\Ravi\PalProjects\RandD\SampleSSISUnit\SSISUnitTests\UnitTest_LoadContacts.ssisUnit");
            test = testSuite.Tests["TestBatch1Staging"];
            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = false;
            context = testSuite.CreateContext();
            bool rs = test.Execute(context);
            Assert.AreEqual<bool>(true, isTestPassed);
            testSuite.AssertCompleted -= TestSuiteAssertCompleted;
        }

        [TestMethod]
        public void TestBatch1NewContacts()
        {
            testSuite = new SsisTestSuite(@"C:\Users\Ravi\PalProjects\RandD\SampleSSISUnit\SSISUnitTests\UnitTest_LoadContacts.ssisUnit");
            test = testSuite.Tests["TestBatch1NewContacts"];
            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = false;
            context = testSuite.CreateContext();
            bool rs = test.Execute(context);
            Assert.AreEqual<bool>(true, isTestPassed);
            testSuite.AssertCompleted -= TestSuiteAssertCompleted;

        }

        [TestMethod]
        public void TestBatch1ContactValues()
        {
            testSuite = new SsisTestSuite(@"C:\Users\Ravi\PalProjects\RandD\SampleSSISUnit\SSISUnitTests\UnitTest_LoadContacts.ssisUnit");
            test = testSuite.Tests["TestBatch1ContactValues"];
            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = false;
            context = testSuite.CreateContext();
            bool rs = test.Execute(context);
            Assert.AreEqual<bool>(true, isTestPassed);
            testSuite.AssertCompleted -= TestSuiteAssertCompleted;
        }

        [TestMethod]
        public void TestBatch1NewDedupContact()
        {
            testSuite = new SsisTestSuite(@"C:\Users\Ravi\PalProjects\RandD\SampleSSISUnit\SSISUnitTests\UnitTest_LoadContacts.ssisUnit");
            test = testSuite.Tests["TestBatch1NewDedupContact"];
            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = false;
            context = testSuite.CreateContext();
            bool rs = test.Execute(context);
            Assert.AreEqual<bool>(true, isTestPassed);
            testSuite.AssertCompleted -= TestSuiteAssertCompleted;
        }

        [TestMethod]
        public void TestBatch1ContactsReload()
        {
            testSuite = new SsisTestSuite(@"C:\Users\Ravi\PalProjects\RandD\SampleSSISUnit\SSISUnitTests\UnitTest_LoadContacts.ssisUnit");
            test = testSuite.Tests["TestBatch1NewContacts"];
            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = false;
            context = testSuite.CreateContext();
            bool rs = test.Execute(context);
            test = testSuite.Tests["TestBatch1ContactsReload"];
            isTestPassed = false;
            rs = test.Execute(context);
            Assert.AreEqual<bool>(true, isTestPassed);
            testSuite.AssertCompleted -= TestSuiteAssertCompleted;
        }

        [TestMethod]
        public void TestBatch2NewContacts()
        {
            testSuite = new SsisTestSuite(@"C:\Users\Ravi\PalProjects\RandD\SampleSSISUnit\SSISUnitTests\UnitTest_LoadContacts.ssisUnit");
            test = testSuite.Tests["TestBatch1NewContacts"];
            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = false;
            context = testSuite.CreateContext();
            bool rs = test.Execute(context);
            test = testSuite.Tests["TestBatch2NewContacts"];
            isTestPassed = false;
            rs = test.Execute(context);
            Assert.AreEqual<bool>(true, isTestPassed);
            testSuite.AssertCompleted -= TestSuiteAssertCompleted;
        }

        [TestMethod]
        public void TestBatch2OldDedupContact()
        {
            testSuite = new SsisTestSuite(@"C:\Users\Ravi\PalProjects\RandD\SampleSSISUnit\SSISUnitTests\UnitTest_LoadContacts.ssisUnit");
            test = testSuite.Tests["TestBatch1NewContacts"];
            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = false;
            context = testSuite.CreateContext();
            bool rs = test.Execute(context);
            test = testSuite.Tests["TestBatch2OldDedupContact"];
            isTestPassed = false;
            rs = test.Execute(context);
            Assert.AreEqual<bool>(true, isTestPassed);
            testSuite.AssertCompleted -= TestSuiteAssertCompleted;
        }
    }
}
