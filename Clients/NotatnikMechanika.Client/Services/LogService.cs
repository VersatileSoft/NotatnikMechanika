using MvvmCross.Logging;
using System;

namespace NotatnikMechanika.Client.Services
{
    public class LogService : IMvxLog
    {
        public bool IsLogLevelEnabled(MvxLogLevel logLevel)
        {
            return true;
        }

        public bool Log(MvxLogLevel logLevel, Func<string> messageFunc, Exception exception = null, params object[] formatParameters)
        {
            return true;
        }
    }
}
