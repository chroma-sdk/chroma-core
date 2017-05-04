using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Chroma.NetCore.Tests.Base
{
    public class TestBase
    {

        static TestBase()
        {

        }

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = typeof(TestBase).GetTypeInfo().Assembly.CodeBase;
                var uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public static string GetTempDirectory
        {
            get { return Path.GetTempPath(); }
        }

        public static string GetTempTestFilename(string extension)
        {
            return Path.Combine(GetTempDirectory, String.Format("api_test_file_{0}{1}", DateTime.Now.Ticks, extension));
        }

        public static string GenerateGuid()
        {
            return Guid.NewGuid().ToString("N");
        }

        public static DateTime GenerateDate(int days, int hours, int minutes, bool secondsRandom = false)
        {
            var date = DateTime.Now.AddDays(days).AddHours(hours).AddMinutes(minutes);

            var ticks = DateTime.Now.Ticks.ToString();

            if (!secondsRandom)
                return date;

            Thread.Sleep(2);

            var rnd = new Random(Convert.ToInt32(ticks.Substring(ticks.Length - 8))).Next(0, 59);
            date = date.AddSeconds(rnd);

            return date;
        }

    }
}
