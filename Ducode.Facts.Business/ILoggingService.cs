using Ducode.Facts.Business.Enums;
using System;

namespace Ducode.Facts.Business
{
	public interface ILoggingService
	{
		void Log(object sender, LogLevel level, string message);
		void Log(object sender, LogLevel level, string format, params object[] values);
		void Log(object sender, LogLevel level, Exception exception);
	}
}
