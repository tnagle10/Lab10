using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab10
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Movie test  = new Movie("Star Wars", "scifi");
            //bool found = test.findTitle("Star Wars");
            //Assert.AreEqual(found, true);
            
        }
    }
}
