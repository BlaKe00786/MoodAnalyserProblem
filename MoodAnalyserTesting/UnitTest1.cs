using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserProject;
namespace MoodAnalyserTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject()
        {
            string message = null;
            object expected = new MoodAnalyser(message);
            object obj = MoodAnalyserReflector.CreateMoodAnalyser("MoodAnalyserProject.MoodAnalyser", "MoodAnalyser");
            expected.Equals(obj);
        }
        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject_UsingParameterizedConstructor()
        {
            object expected = new MoodAnalyser("HAPPY");
            object obj = MoodAnalyserReflector.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyserProject.MoodAnalyser", "MoodAnalyser", "SAD");
            expected.Equals(obj);
        }
        [TestMethod]
        public void GivenMessage_ShouldReturnMood()
        {
            string message = "I am feeling happy";
            string expected = "HAPPY";
            string result = MoodAnalyserReflector.InvokeAnalyseMood(message, "analyseMood");
            Assert.AreEqual(expected,result);
            
        }
    }
}
