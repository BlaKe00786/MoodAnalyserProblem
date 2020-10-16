using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;
namespace MoodAnalyserProject
{
   public class MoodAnalyserReflector
    {
        private string message;
        public MoodAnalyserReflector(string message)
        {
            this.message = message;
        }
        public static string InvokeAnalyseMood(string message,string methodName)
        {
            if (message.Equals(null))
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NULL_MESSAGE, "ssage should not be null");
            }
            Assembly executing = Assembly.GetExecutingAssembly();
            Type moodAnalyseType = executing.GetType("MoodAnalyserProject.MoodAnalyser");
            MethodInfo methodInfo = moodAnalyseType.GetMethod(methodName);
            if(methodInfo.Equals(null))
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "No such method found");
            }
            object result = null;
            FieldInfo fields = moodAnalyseType.GetField("message");
            if (fields.Equals(null)) 
            {
                  throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_FIELD, "No such Field found");
            }
            object instance = Activator.CreateInstance(moodAnalyseType);
            fields.SetValue(instance, message);
            result = methodInfo.Invoke(instance, null);
            return (string)result;
                
        }

        public static object CreateMoodAnalyser(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch (ArgumentNullException)
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "Class not found");

                }
            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "Constructor is not found");
            }
        }
        public static object CreateMoodAnalyseUsingParameterizedConstructor(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyser);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                    object instance = ctor.Invoke(new object[] { message });
                    return instance;
                }
                else
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "Constructor is not found");
                }
            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "Class not found");
            }
        }
    }
}
