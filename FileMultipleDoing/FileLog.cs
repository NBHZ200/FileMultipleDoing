

namespace FileMultipleDoing
{
    /// <summary>
    /// 
    /// </summary>
    public static class FileLog
    {

        public static FileStream fsLog;

        public static string logPath;

        public static void Start()
        {
            logPath = Directory.GetCurrentDirectory() + "/日志.log";

            fsLog = new FileStream(logPath,
                FileMode.Append‌, FileAccess.Write);
        }

        public static void WriteLog(string strLog)
        {
            DateTime dt = DateTime.Now;
            string str = dt.ToString("yyyy-MM-dd HH:mm:ss.ffffff") + "　　" + strLog + "\n\n";
            byte[] bStream = System.Text.Encoding.Default.GetBytes(str);

            fsLog.Write(bStream, 0, bStream.Length);
            fsLog.Flush();
        }

        public static void End()
        {
            fsLog.Close();
        }

    }
}
