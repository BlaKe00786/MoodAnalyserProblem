using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyserProject
{
    public class MoodAnalyser
    {
        private string message;
        public MoodAnalyser()
        {
        }
        public MoodAnalyser(string message)
        {
            this.message = message;
        }
        public string analyseMood()
        {
            try
            {
                if (this.message.Contains("sad", StringComparison.InvariantCultureIgnoreCase))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }catch(Exception exception)
            {
                Console.WriteLine("Exception NULL occured : " + exception);
                return "HAPPY";
            }
        }
    }
}
