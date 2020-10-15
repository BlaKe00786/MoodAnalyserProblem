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
            object obj = MoodAnalyserfactory.CreateMoodAnalyser("MoodAnalyserProject.MoodAnalyser", "MoodAnalyser");
            expected.Equals(obj);
        }
        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject_UsingParameterizedConstructor()
        {
            object expected = new MoodAnalyser("HAPPY");
            object obj = MoodAnalyserfactory.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyserProject.MoodAnalyser", "MoodAnalyser", "SAD");
            expected.Equals(obj);
        }
    }
}
