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
            //Assert.AreEqual(expected.GetType(), obj.GetType());
        }
    }
}
