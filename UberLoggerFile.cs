using System.IO;
using UnityEngine;
using System;

/// <summary>
/// A basic file logger backend
/// </summary>
namespace HsufAOT
{
    using UberLogger;
    public class UberLoggerFile : UberLogger.ILogger
    {
        private StreamWriter LogFileWriter;
        private bool IncludeCallStacks;

        public static string LogFilePath { get; private set; }

        /// <summary>
        /// Constructor. Make sure to add it to UberLogger via Logger.AddLogger();
        /// filename is relative to Application.persistentDataPath
        /// if includeCallStacks is true it will dump out the full callstack for all logs, at the expense of big log files.
        /// </summary>
        public UberLoggerFile(string filename, bool includeCallStacks = true)
        {
            IncludeCallStacks = includeCallStacks;
#if UNITY_EDITOR
            filename = System.IO.Path.Combine("../../Logs", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "_" + filename.ToString());
            var fileLogPath = HsufFileUtility.GetModePath(filename, HsufFileMode.Editor);
#else
            var fileLogPath = HsufFileUtility.GetModePath(filename, HsufFileMode.Runtime_SerializedData);
#endif
            LogFilePath = fileLogPath;
            string folder = System.IO.Path.GetDirectoryName(fileLogPath);
            if (!System.IO.Directory.Exists(folder))
            {
                System.IO.Directory.CreateDirectory(folder);
            }
            Debug.Log("Initialising file logging to " + fileLogPath);
            LogFileWriter = new StreamWriter(fileLogPath, false);
            LogFileWriter.AutoFlush = true;
        }

        public void Log(LogInfo logInfo)
        {
            lock (this)
            {
                string title = "";
                switch (logInfo.Severity)
                {
                    case LogSeverity.Error:
                        title = "[ERROR]";
                        break;
                    case LogSeverity.Warning:
                        title = "[WARNING]";
                        break;
                    case LogSeverity.Message:
                        title = "[INFO]";
                        break;
                }
                LogFileWriter.WriteLine($"[{AOTTextUtility.GetLocalTime()}][{title}][{logInfo.Channel}]{logInfo.Message}");
                // Only include callstacks for errors and warnings, or if explicitly requested
                if ((IncludeCallStacks || logInfo.Severity >= LogSeverity.Warning) && logInfo.Callstack.Count > 0)
                {
                    foreach (var frame in logInfo.Callstack)
                    {
                        LogFileWriter.WriteLine(frame.GetFormattedMethodNameWithFileName());
                    }
                    LogFileWriter.WriteLine();
                }
            }
        }
    }
}
