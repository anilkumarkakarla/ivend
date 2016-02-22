using System;
using System.Diagnostics;
using System.Globalization;

namespace CXS.Core.Common.Logging
{
    /// <summary>
    /// This class wraps the functionality of TimeElapsed in a function. You are not
    /// required to create instance of this class directly. This class is created 
    /// through TimeCaptureService. IDisposable method is used for capturing the 
    /// time elapsed for the code written within this.
    /// </summary>
    public class TimeElapsed : IDisposable
    {
        private Stopwatch _stopWatch;

        public String Msg { get; set; }
        private bool LogStart { get; }
        private bool LogEnd { get; }
        public bool NeedTimeStamp { get; set; }

        public TimeElapsed(string msg, bool logStart, bool logEnd, bool needTimeStamp)
        {
            Msg = msg;
            LogStart = logStart;
            LogEnd = logEnd;
            NeedTimeStamp = needTimeStamp;
            StartTimer();
        }

        private void StartTimer()
        {
            _stopWatch = new Stopwatch();
            _stopWatch.Start();

            //if (LogStart)
            //    Trace.TraceInformation("{0} - Started", Msg);
        }

        private void StopAndLog()
        {
            _stopWatch.Stop();
            //if (LogEnd)
            //    Trace.TraceInformation("{0} - End - Time Taken {1}, Thread {2} {3}", Msg,
            //                           _stopWatch.ElapsedMilliseconds.ToString(CultureInfo.InvariantCulture),
            //                           Environment.CurrentManagedThreadId,
            //                           NeedTimeStamp ? DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss.fff") : null);
        }

        public void Dispose()
        {
            StopAndLog();
        }

        public static TimeElapsed Start(string message, bool logStart = false, bool logEnd = true, bool needTimeStamp = true)
        {
            return new TimeElapsed(message, logStart, logEnd, needTimeStamp);
        }
    }
}
