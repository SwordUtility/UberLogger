using System;
using System.Diagnostics;
using HsufAOT.UberLogger;

namespace HsufAOT
{
    public static partial class Log
    {

        [Conditional("ENABLE_LOG")]
        [Conditional("ENABLE_DEBUG_LOG")]
        [Conditional("ENABLE_INFO_LOG")]
        [Conditional("ENABLE_WARNING_LOG")]
        [Conditional("ENABLE_ERROR_LOG")]
        [Conditional("ENABLE_DEBUG_AND_ABOVE_LOG")]
        [Conditional("ENABLE_INFO_AND_ABOVE_LOG")]
        [Conditional("ENABLE_WARNING_AND_ABOVE_LOG")]
        [Conditional("ENABLE_ERROR_AND_ABOVE_LOG")]
        public static void AddDefaultFileLog()
        {
            Logger.AddLogger(new UberLoggerFile("hsuf_log.log"), false); // 默认文件log系统
        }

        static public void SetLogerForward(bool forward)
        {
            Logger.ForwardMessages = forward;
            UnityEngine.Debug.Log($"Log init :{Logger.ForwardMessages}");
        }

        [Conditional("ENABLE_LOG")]
        [Conditional("ENABLE_DEBUG_LOG")]
        [Conditional("ENABLE_DEBUG_AND_ABOVE_LOG")]
        [StackTraceIgnore]
        static public void Debug(string message, params object[] par)
        {
            Logger.Log("", null, LogSeverity.Message, message, par);
        }
        [Conditional("ENABLE_LOG")]
        [Conditional("ENABLE_DEBUG_LOG")]
        [Conditional("ENABLE_DEBUG_AND_ABOVE_LOG")]
        [StackTraceIgnore]
        static public void Debug(UnityEngine.Object context, string message, params object[] par)
        {
            Logger.Log("", context, LogSeverity.Message, message, par);
        }
        [Conditional("ENABLE_LOG")]
        [Conditional("ENABLE_DEBUG_LOG")]
        [Conditional("ENABLE_DEBUG_AND_ABOVE_LOG")]
        [StackTraceIgnore]
        static public void DebugChannel(UnityEngine.Object context, string channel, string message, params object[] par)
        {
            Logger.Log(channel, context, LogSeverity.Message, message, par);
        }
        [Conditional("ENABLE_LOG")]
        [Conditional("ENABLE_DEBUG_LOG")]
        [Conditional("ENABLE_DEBUG_AND_ABOVE_LOG")]
        [StackTraceIgnore]
        static public void DebugChannel(string channel, string message, params object[] par)
        {
            Logger.Log(channel, null, LogSeverity.Message, message, par);
        }

        [Conditional("ENABLE_LOG")]
        [Conditional("ENABLE_INFO_LOG")]
        [Conditional("ENABLE_DEBUG_AND_ABOVE_LOG")]
        [Conditional("ENABLE_INFO_AND_ABOVE_LOG")]
        [StackTraceIgnore]
        static public void Info(string message, params object[] par)
        {
            Logger.Log("", null, LogSeverity.Message, message, par);
        }
        [Conditional("ENABLE_LOG")]
        [Conditional("ENABLE_INFO_LOG")]
        [Conditional("ENABLE_DEBUG_AND_ABOVE_LOG")]
        [Conditional("ENABLE_INFO_AND_ABOVE_LOG")]
        [StackTraceIgnore]
        static public void Info(UnityEngine.Object context, string message, params object[] par)
        {
            Logger.Log("", context, LogSeverity.Message, message, par);
        }
        [Conditional("ENABLE_LOG")]
        [Conditional("ENABLE_INFO_LOG")]
        [Conditional("ENABLE_DEBUG_AND_ABOVE_LOG")]
        [Conditional("ENABLE_INFO_AND_ABOVE_LOG")]
        [StackTraceIgnore]
        static public void InfoChannel(UnityEngine.Object context, string channel, string message, params object[] par)
        {
            Logger.Log(channel, context, LogSeverity.Message, message, par);
        }
        [Conditional("ENABLE_LOG")]
        [Conditional("ENABLE_INFO_LOG")]
        [Conditional("ENABLE_DEBUG_AND_ABOVE_LOG")]
        [Conditional("ENABLE_INFO_AND_ABOVE_LOG")]
        [StackTraceIgnore]
        static public void InfoChannel(string channel, string message, params object[] par)
        {
            Logger.Log(channel, null, LogSeverity.Message, message, par);
        }

        [Conditional("ENABLE_LOG")]
        [Conditional("ENABLE_WARNING_LOG")]
        [Conditional("ENABLE_DEBUG_AND_ABOVE_LOG")]
        [Conditional("ENABLE_INFO_AND_ABOVE_LOG")]
        [Conditional("ENABLE_WARNING_AND_ABOVE_LOG")]
        [StackTraceIgnore]
        static public void Warning(UnityEngine.Object context, object message, params object[] par)
        {
            Logger.Log("", context, LogSeverity.Warning, message, par);
        }

        [Conditional("ENABLE_LOG")]
        [Conditional("ENABLE_WARNING_LOG")]
        [Conditional("ENABLE_DEBUG_AND_ABOVE_LOG")]
        [Conditional("ENABLE_INFO_AND_ABOVE_LOG")]
        [Conditional("ENABLE_WARNING_AND_ABOVE_LOG")]
        [StackTraceIgnore]
        static public void Warning(object message, params object[] par)
        {
            Logger.Log("", null, LogSeverity.Warning, message, par);
        }

        [Conditional("ENABLE_LOG")]
        [Conditional("ENABLE_WARNING_LOG")]
        [Conditional("ENABLE_DEBUG_AND_ABOVE_LOG")]
        [Conditional("ENABLE_INFO_AND_ABOVE_LOG")]
        [Conditional("ENABLE_WARNING_AND_ABOVE_LOG")]
        [StackTraceIgnore]
        static public void WarningChannel(UnityEngine.Object context, string channel, string message, params object[] par)
        {
            Logger.Log(channel, context, LogSeverity.Warning, message, par);
        }

        [Conditional("ENABLE_LOG")]
        [Conditional("ENABLE_WARNING_LOG")]
        [Conditional("ENABLE_DEBUG_AND_ABOVE_LOG")]
        [Conditional("ENABLE_INFO_AND_ABOVE_LOG")]
        [Conditional("ENABLE_WARNING_AND_ABOVE_LOG")]
        [StackTraceIgnore]
        static public void WarningChannel(string channel, string message, params object[] par)
        {
            Logger.Log(channel, null, LogSeverity.Warning, message, par);
        }

        [StackTraceIgnore]
        static public void Error(UnityEngine.Object context, object message, params object[] par)
        {
            Logger.Log("", context, LogSeverity.Error, message, par);
        }

        [StackTraceIgnore]
        static public void Error(object message, params object[] par)
        {
            Logger.Log("", null, LogSeverity.Error, message, par);
        }

        [StackTraceIgnore]
        static public void ErrorChannel(UnityEngine.Object context, string channel, string message, params object[] par)
        {
            Logger.Log(channel, context, LogSeverity.Error, message, par);
        }

        [StackTraceIgnore]
        static public void ErrorChannel(string channel, string message, params object[] par)
        {
            Logger.Log(channel, null, LogSeverity.Error, message, par);
        }
        [StackTraceIgnore]
        static public void Fatal(Exception e)
        {
#if UNITY_EDITOR
            UnityEngine.Debug.LogException(e);
#else
            Logger.Log("", null, LogSeverity.Error, $"Fatal:{e.Message} {e.StackTrace} {e.Source}");
#endif
        }
        [StackTraceIgnore]
        static public void Fatal(string message, Exception e)
        {
#if UNITY_EDITOR
            UnityEngine.Debug.LogException(e);
#else
            Logger.Log("", null, LogSeverity.Error, $"Fatal:{message} {e.Message} {e.StackTrace} {e.Source}");
#endif
        }
        [StackTraceIgnore]
        static public void FatalChannel(string channel, Exception e)
        {
#if UNITY_EDITOR
            UnityEngine.Debug.LogException(e);
#else
            Logger.Log(channel, null, LogSeverity.Error, $"Fatal:{e.Message} {e.StackTrace} {e.Source}");
#endif
        }

        [StackTraceIgnore]
        static public void FatalChannel(string channel, string message, Exception e)
        {
#if UNITY_EDITOR
            UnityEngine.Debug.LogException(e);
#else
            Logger.Log(channel, null, LogSeverity.Error, $"Fatal:{message} {e.Message} {e.StackTrace} {e.Source}");
#endif
        }

        static public string ConvertBytes(byte[] bytes)
        {
            string msg = string.Empty;
            for (int i = 0; i < bytes.Length; i++)
            {
                msg += bytes[i].ToString("X2") + " ";
            }
            return msg;
        }


        //Logs that will not be caught by UberLogger
        //Useful for debugging UberLogger
        [LogUnityOnly]
        static public void UnityLog(object message)
        {
#if ENABLE_UBERLOGGING
        UnityEngine.Debug.Log(message);
#endif
        }

        [LogUnityOnly]
        static public void UnityLogWarning(object message)
        {
#if (ENABLE_UBERLOGGING || ENABLE_UBERLOGGING_WARNINGS)
        UnityEngine.Debug.LogWarning(message);
#endif
        }

        [LogUnityOnly]
        static public void UnityLogError(object message)
        {
#if (ENABLE_UBERLOGGING || ENABLE_UBERLOGGING_ERRORS)
        UnityEngine.Debug.LogError(message);
#endif
        }
    }
}
