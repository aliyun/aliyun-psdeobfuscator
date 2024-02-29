using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;

namespace PSDeObfuscator
{
    class Logger
    {

        private static readonly string logFolderPath = @"C:\psdecode_dir";

        public sealed class LogWriter
        {
            private static readonly Lazy<LogWriter> lazy = new Lazy<LogWriter>(() => new LogWriter());
            private StreamWriter streamWriter;

            public static LogWriter Instance { get { return lazy.Value; } }

            private LogWriter()
            {
                int pid = Process.GetCurrentProcess().Id;
                string filePath = Path.Combine(logFolderPath, $"{pid}.log");
                Directory.CreateDirectory(logFolderPath);
                FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
                streamWriter = new StreamWriter(fileStream) { AutoFlush = true }; ;
            }

            public void WriteLine(string message)
            {
                streamWriter.WriteLine(message);
            }

            public void Close()
            {
                streamWriter.Close();
                streamWriter.Dispose();
            }
        }

        public static void WriteLog(string message)
        {
            LogWriter.Instance.WriteLine(message);
        }

        public sealed class ApiWriter
        {
            private static readonly Lazy<ApiWriter> lazy = new Lazy<ApiWriter>(() => new ApiWriter());
            private StreamWriter streamWriter;

            public static ApiWriter Instance { get { return lazy.Value; } }

            private ApiWriter()
            {
                int pid = Process.GetCurrentProcess().Id;
                string filePath = Path.Combine(logFolderPath, $"{pid}.json");
                Directory.CreateDirectory(logFolderPath);
                FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
                streamWriter = new StreamWriter(fileStream) { AutoFlush = true }; ;
            }

            public void WriteLine(string message)
            {
                streamWriter.WriteLine(message);
            }

            public void Close()
            {
                streamWriter.Close();
                streamWriter.Dispose();
            }
        }

        private static void WriteJson(string message)
        {
            ApiWriter.Instance.WriteLine(message);
        }

        public static void WriteJsonObject(object obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            WriteJson(json);
        }
    }
}
