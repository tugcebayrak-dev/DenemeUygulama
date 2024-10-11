using System;
using System.IO;
using System.Threading;

namespace DenemeUygulama.Data.Araclar
{
    public interface ILog
    {
        void Yaz(string logMessage);
        void Yaz(Exception ex);
    }

    public class Log : ILog
    {
        private static readonly object _syncObject = new object();
        private static readonly Lazy<ILog> instance = new Lazy<ILog>(() => new Log(), LazyThreadSafetyMode.ExecutionAndPublication);

        private readonly TextWriter textWriter;

        public static ILog Instance => instance.Value;

        public Log()
        {
            const string FMT = "yyyy-MM-dd";
            DateTime now1 = DateTime.Now;
            string strDate = now1.ToString(FMT);

            string path = new FileOperation().GetExePath();
            textWriter = TextWriter.Synchronized(File.AppendText(path + "\\Log_" + strDate + ".log"));
        }

        public void Yaz(string logMessage)
        {
            try
            {
                LogaEkle(logMessage, textWriter);
            }
            catch (IOException e)
            {
                var hata = e.Message;
                textWriter.Close();
            }
        }

        public void Yaz(Exception ex)
        {
            try
            {
                LogaEkle(ex.GetExceptionDetailMessage(), textWriter);
            }
            catch (IOException e)
            {
                var hata = e.Message;
                textWriter.Close();
            }
        }

        private void LogaEkle(string logMessage, TextWriter w)
        {
            lock (_syncObject)
            {
                DateTime now = DateTime.Now;
                w.WriteLine("{0} - {1} :\n{2}", now.ToLongTimeString(), now.ToLongDateString(), logMessage);

                w.Flush();
            }
        }

    }
}
