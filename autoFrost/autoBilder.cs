using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace autoFrost
{
    class autoBilder
    {
        public static void build(string grayFrostSln, string executable)
        {
            string cSharpArray = writeCSharp(executable);
            writeFile(cSharpArray, grayFrostSln + "\\GrayFrostCSharp\\payload.cs", true);
            autoBuild(grayFrostSln + "\\GrayFrostCSharp\\GrayFrostCSharp.csproj");
            string cppArray = writeCPP(grayFrostSln + "\\GrayFrostCSharp\\bin\\Debug\\GrayFrostCSharp.exe");
            writeFile(cppArray, grayFrostSln + "\\GrayFrost\\slate.h");
            autoBuild(grayFrostSln + "\\GrayFrost\\GrayFrost32.vcxproj", "/property:Configuration=Release;Platform=x86");
            autoBuild(grayFrostSln + "\\GrayFrost\\GrayFrost64.vcxproj", "/property:Configuration=Release;Platform=x64");
            return;
        }

        public static void autoBuild(string memoryHijackerPath, string args = null)
        {
            string msBuildPath = GetFullPath("msbuild.exe");


            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = msBuildPath;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = args + " " + memoryHijackerPath;

            try
            {
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch
            {

            }

        }

        public static string GetFullPath(string fileName)
        {
            if (File.Exists(fileName))
                return Path.GetFullPath(fileName);

            var values = Environment.GetEnvironmentVariable("PATH");
            foreach (var path in values.Split(';'))
            {
                var fullPath = Path.Combine(path, fileName);
                if (File.Exists(fullPath))
                    return fullPath;
            }
            return null;
        }

        private static bool IsValidPath(string path)
        {
            Regex driveCheck = new Regex(@"^[a-zA-Z]:\\$");
            if (!driveCheck.IsMatch(path.Substring(0, 3))) return false;
            string strTheseAreInvalidFileNameChars = new string(Path.GetInvalidPathChars());
            strTheseAreInvalidFileNameChars += @":/?*" + "\"";
            Regex containsABadCharacter = new Regex("[" + Regex.Escape(strTheseAreInvalidFileNameChars) + "]");
            if (containsABadCharacter.IsMatch(path.Substring(3, path.Length - 3)))
                return false;

            DirectoryInfo dir = new DirectoryInfo(Path.GetFullPath(path));
            if (!dir.Exists)
                return false;
            return true;
        }

        public static string writeCSharp(string path)
        {
            bool flag = true;
            byte[] array = File.ReadAllBytes(path);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("public static byte[] g_bInjectCode = new byte[]");
            stringBuilder.Append(Environment.NewLine + "\t");
            stringBuilder.Append("{");
            stringBuilder.Append(Environment.NewLine + "\t");
            int num = 0;
            byte[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                byte b = array2[i];
                num++;
                if (num > 100)
                {
                    num = 0;
                    stringBuilder.Append(Environment.NewLine + "\t");
                }
                if (!flag)
                {
                    stringBuilder.Append(",0x" + b.ToString("X"));
                }
                else
                {
                    stringBuilder.Append("0x" + b.ToString("X"));
                    flag = false;
                }
            }
            stringBuilder.Append(Environment.NewLine + "\t");
            stringBuilder.Append("};");
            return stringBuilder.ToString();
        }

        public static string writeCPP(string path)
        {
            bool flag = true;
            byte[] array = File.ReadAllBytes(path);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("#define SIZE " + array.Length.ToString());
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append("unsigned char data[" + array.Length.ToString() + "] = {");
            stringBuilder.Append(Environment.NewLine);
            int num = 0;
            byte[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                byte b = array2[i];
                num++;
                if (num > 30)
                {
                    num = 0;
                    stringBuilder.Append(Environment.NewLine);
                }
                if (!flag)
                {
                    stringBuilder.Append(",0x" + b.ToString("X"));
                }
                else
                {
                    stringBuilder.Append("0x" + b.ToString("X"));
                    flag = false;
                }
            }
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append("};");
            return stringBuilder.ToString();
        }

        public static void writeFile(string memHijacking, string path, bool csharp = false)
        {
            if (csharp)
            {
                memHijacking = "namespace GrayFrostCSharp { class payload { " + memHijacking + "} }";
            }
            File.WriteAllText(path, memHijacking);
        }
    }
}

