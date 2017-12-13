using System;
using System.IO;

namespace OpenPop.Common.Logging
{
	/// <summary>
	/// This logging object writes application error and debug output to a text file.
	/// </summary>
	public class FileLogger : ILog
	{
		#region File Logging

        public static bool Enabled { get; set; }        // Turns the logging on and off.    
        public static bool Verbose { get; set; }
        public static FileInfo LogFile { get; set; }    // LogfileName including Path
        private static readonly object LogLock;         // Lock object to prevent thread interactions

        // Static constructor
        static FileLogger()
        {
            Enabled = true;
            Verbose = false;
            LogLock = new object();
        }

        //--FileLogger Class를 생성하고 난 다음 FileName을 별도로 Setting한다.
        public static void LogFileName(string filename)
        {
            LogFile = new FileInfo(filename);
        }

        private static void LogToFile(string text)
		{
			if (text == null)
				throw new ArgumentNullException("text");

			// We want to open the file and append some text to it
			lock (LogLock)
			{
				using (StreamWriter sw = LogFile.AppendText())
				{
					sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - " + text);
					sw.Flush();
				}
			}
		}
		#endregion

		#region ILog Implementation
		/// <summary>
		/// Logs an error message to the logs
		/// </summary>
		/// <param name="message">This is the error message to log</param>
		public void LogError(string message)
		{
			if (Enabled)
                LogToFile("ERROR: " + message);
		}

		/// <summary>
		/// Logs a debug message to the logs
		/// </summary>
		/// <param name="message">This is the debug message to log</param>
		public void LogDebug(string message)
		{
			if (Enabled && Verbose)
				LogToFile("DEBUG: " + message);
		}

        public void LogText(string message)
        {
            if (Enabled)
                LogToFile(message);
        }
        #endregion
	}
}