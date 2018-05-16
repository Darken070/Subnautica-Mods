using System;
using System.Reflection;

namespace AlexejheroYTB.Utilities
{
    public class Values
    {
        public Exception Swap<T>(T value1, T value2, out T newValue1, out T newValue2)
        {
            try
            {
                newValue1 = value2;
                newValue2 = value1;
                return null;
            }
            catch (Exception e)
            {
                newValue1 = default(T);
                newValue2 = default(T);
                return e;
            }
        }
        public class NullCheck
        {
            public bool One<T>(params T[] variables)
            {
                foreach (T variable in variables)
                {
                    if (variable == null) return true;
                }
                return false;
            }
            public bool All<T>(params T[] variables)
            {
                foreach (T variable in variables)
                {
                    if (variable != null) return false;
                }
                return true;
            }
        }
    }
    public class Console
    {
        public void Debug(string message, bool log = true, string customCallerName = null)
        {
            if (!log) return;
            var callerName = "";
            if (customCallerName == null)
            {
                callerName = Assembly.GetCallingAssembly().GetName().Name;
            }
            else
            {
                callerName = customCallerName;
            }
            if (log)
            {
                System.Console.WriteLine($"[AlexejheroYTB.Utilities:{callerName}] {message}");
            }
        }
    }
    public class QMods
    {
        public static void LoadDLL() { }
    }
}
