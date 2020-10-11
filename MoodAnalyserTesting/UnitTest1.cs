using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserProject;
namespace MoodAnalyserTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string expected = "HAPPY";
            MoodAnalyser moodanalyser = new MoodAnalyser(null);
            string result = moodanalyser.analyseMood();
            Assert.AreEqual(expected, result);
        }
    }
}
