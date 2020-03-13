using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;

namespace SeleniumExamples.Utils
{
    public static class RunSettings
    {

        public static Dictionary<string, string> GetRunSettings()
        {
            Dictionary<string, string> runsettings = new Dictionary<string, string>();
            var properties = typeof(RunSettings).GetProperties(BindingFlags.Static | BindingFlags.Public);

            foreach (PropertyInfo property in properties)
            {
                runsettings.Add(property.Name, property.GetValue(null).ToString());
            }
            return runsettings;
        }

        public static string browser { get { return TestContext.Parameters["Browser"].ToString(); } }
        public static string baseGoogleUrl { get { return TestContext.Parameters["BaseGoogleUrl"].ToString(); } }
    }
}
