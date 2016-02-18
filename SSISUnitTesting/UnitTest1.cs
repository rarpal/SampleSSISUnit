using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SsisUnit;
using System.Xml;
using System.Diagnostics;

namespace SSISUnitTesting
{
    [TestClass]
    public class UnitTest1 : ExternalFileResourceTestBase
    {
        private SsisTestSuite testSuite;
        private string testFile;

        [TestInitialize]
        public void Initialize()
        {
            testFile = UnpackToFile("SSISUnitTesting.UTSsisUnit.ssisUnit");
            testSuite = new SsisTestSuite(testFile);
        }

        [TestMethod]
        public void ExecuteResultsTest()
        {
            var target = new SqlCommand(testSuite);
            var doc = new XmlDocument();
            doc.Load(testFile);
            Debug.Assert(doc.DocumentElement != null, "doc.DocumentElement != null");
            Debug.Assert(doc.DocumentElement["Setup"] != null, "doc.DocumentElement != null");
            XmlNode command = doc.DocumentElement["Setup"]["SqlCommand"];

            object result = target.Execute(command, null, null);
            Assert.AreEqual(80, result);
        }
    }
}
