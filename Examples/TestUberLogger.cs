using UnityEngine;
using System.Collections.Generic;
using System.Threading;
using System;

namespace HsufAOT
{


    public class TestUberLogger : MonoBehaviour
    {
        Thread TestThread;
        // Use this for initialization
        void Start()
        {
            UberLogger.Logger.AddLogger(new UberLoggerFile("UberLogger.log"), false);
            DoTest();
            TestThread = new Thread(new ThreadStart(TestThreadEntry));
            TestThread.Start();

            //Test an internal .Net OOB error
            var t = new List<int>();
            t[0] = 5;
        }

        void OnDestroy()
        {
            if (TestThread != null && TestThread.IsAlive)
            {
                TestThread.Abort();
                TestThread.Join();
            }
        }
        void TestThreadEntry()
        {
            for (int id = 0; id < 10000; id++)
            {
                Debug.Log("Thread Log Message");
                Log.Info("Thread ULog Message");
                Thread.Sleep(0);
            }
            while (true)
            {
                Debug.Log("Thread Log Message");
                Log.Info("Thread ULog Message");
                Thread.Sleep(1000);
            }
        }

        public void DoTest()
        {
            // UnityEngine.Debug.Log("Starting");
            Debug.LogWarning("Log Warning with GameObject", gameObject);
            Debug.LogError("Log Error with GameObject", gameObject);
            Debug.Log("Log Message with GameObject", gameObject);
            Debug.LogFormat("Log Format param {0}", "Test");
            Debug.LogFormat(gameObject, "Log Format with GameObject and param {0}", "Test");

            Log.Info("ULog");
            Log.Info("ULog with param {0}", "Test");
            Log.Info(gameObject, "ULog with GameObject");
            Log.Info(gameObject, "ULog with GameObject and param {0}", "Test");

            Log.InfoChannel("Test", "ULogChannel");
            Log.InfoChannel("Test", "ULogChannel with param {0}", "Test");
            Log.InfoChannel(gameObject, "Test", "ULogChannel with GameObject");
            Log.InfoChannel(gameObject, "Test", "ULogChannel with GameObject and param {0}", "Test");

            Log.Warning("ULogWarning");
            Log.Warning("ULogWarning with param {0}", "Test");
            Log.Warning(gameObject, "ULogWarning with GameObject");
            Log.Warning(gameObject, "ULogWarning with GameObject and param {0}", "Test");

            Log.WarningChannel("Test", "ULogWarningChannel");
            Log.WarningChannel("Test", "ULogWarningChannel with param {0}", "Test");
            Log.WarningChannel(gameObject, "Test", "ULogWarningChannel with GameObject");
            Log.WarningChannel(gameObject, "Test", "ULogWarningChannel with GameObject and param {0}", "Test");

            Log.Error("ULogError");
            Log.Error("ULogError with param {0}", "Test");
            Log.Error(gameObject, "ULogError with GameObject");
            Log.Error(gameObject, "ULogError with GameObject and param {0}", "Test");

            Log.ErrorChannel("Test", "ULogErrorChannel");
            Log.ErrorChannel("Test", "ULogErrorChannel with param {0}", "Test");
            Log.ErrorChannel(gameObject, "Test", "ULogErrorChannel with GameObject");
            Log.ErrorChannel(gameObject, "Test", "ULogErrorChannel with GameObject and param {0}", "Test");

            // try
            // {
            //     Log.Fatal("ULogFatal", new System.Exception("Test Exception"));
            // }
            // catch (Exception e)
            // {
            //     Log.InfoChannel("Test", $"exception: {e.Message} stacktrace: {e.StackTrace}");
            //     Debug.LogException(e);
            //     Log.Info($"exception string:{e.ToString()}");
            //     Log.Info($"exception {e}");
            //     Log.Fatal("adfadfa ULogFatal", e);
            // }

            try{
                throw new System.Exception("adfadf Exception111");
            }
            catch(Exception e)
            {
                Log.Fatal("adaaaaaa ULogFatal", e);
            }

            // Log.Fatal("ULogFatal with GameObject", new System.Exception("Test Exception22"));
            // throw new System.Exception("Test Exception33");
        }

        // Update is called once per frame
        void Update()
        {
            // DoTest();
        }
    }

}
