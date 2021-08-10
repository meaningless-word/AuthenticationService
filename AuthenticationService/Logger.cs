using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AuthenticationService
{
	public class Logger : ILogger
	{
        private ReaderWriterLockSlim lock_ = new ReaderWriterLockSlim();
        private string logDirectory { get; set; }
        private string errDirectory { get; set; }

        public Logger()
        {
            logDirectory = AppDomain.CurrentDomain.BaseDirectory + @"/_logs/" + DateTime.Now.ToString("dd-MM-yy HH-mm-ss") + @"/";

            if (!Directory.Exists(logDirectory))
                Directory.CreateDirectory(logDirectory);

            errDirectory = AppDomain.CurrentDomain.BaseDirectory + @"/_errs/";
            if (!Directory.Exists(errDirectory))
                Directory.CreateDirectory(errDirectory);
        }

        public void WriteEvent(string eventMessage)
        {
            lock_.EnterWriteLock();
            try
            {
                using (StreamWriter writer = new StreamWriter(logDirectory + "events.txt", append: true))
                {
                    writer.WriteLine(eventMessage);
                }
            }
            finally
            {
                lock_.ExitWriteLock();
            }
        }

        public void WriteError(string errorMessage)
        {
            lock_.EnterWriteLock();
            try
            {
                using (StreamWriter writer = new StreamWriter(errDirectory + "errors.txt", append: true))
                {
                    writer.WriteLine(errorMessage);
                }
            }
            finally
            {
                lock_.ExitWriteLock();
            }
        }
    }
}
