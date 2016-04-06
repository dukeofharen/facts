using Ducode.Facts.Business;
using Ducode.Facts.Business.Enums;
using log4net;
using System;

namespace Ducode.Facts.Implementations
{
	public class Log4NetService : ILoggingService
	{
		public void Log(object sender, LogLevel level, Exception exception)
		{
			Log(level, FormatMessage(sender, exception.ToString()));
		}

		public void Log(object sender, LogLevel level, string message)
		{
			Log(level, FormatMessage(sender, message));
		}

		public void Log(object sender, LogLevel level, string format, params object[] values)
		{
			Log(level, FormatMessage(sender, string.Format(format, values)));
		}

		private void Log(LogLevel level, string message)
		{
			var logger = GetLogger(GetType());
			switch (level)
			{
				case LogLevel.Debug:
					logger.Debug(message);
					break;
				case LogLevel.Info:
					logger.Info(message);
					break;
				case LogLevel.Warn:
					logger.Warn(message);
					break;
				case LogLevel.Error:
					logger.Error(message);
					break;
				case LogLevel.Fatal:
					logger.Fatal(message);
					break;
			}
		}

		private string FormatMessage(object sender, string message)
		{
			return string.Format("{0}: {1}", sender.GetType(), message);
		}

		private ILog GetLogger(Type type)
		{
			return LogManager.GetLogger(type);
		}
	}
}
