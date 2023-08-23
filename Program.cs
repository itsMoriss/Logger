using System;
using System.IO;

namespace myLogger
{
    public abstract class LogBase
    {
        // Abstract Class
        public abstract void Log(string Message); 
    }

    public class Logger: LogBase
    {
        private string CurrentDirectory {get; set; }
        private string FileName {get; set; }
        private string FilePath {get; set; }

        public Logger()
        {
            this.CurrentDirectory = Directory.GetCurrentDirectory();
            this.FileName = "log.txt";
            this.FilePath = Path.Combine(this.CurrentDirectory, this.FileName);
        }

        public override void Log(string Message)
        {
            using (StreamWriter sw = File.AppendText(this.FilePath))
            {
                sw.Write("\r\nLog Entry: ");
                sw.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                sw.WriteLine("  :{0}", Message);
                sw.WriteLine("---------------------------------------");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();
            logger.Log("Hello World!");
            logger.Log("Goodbye World!");

            // Keep the console window open until Enter is pressed
            // Console.ReadLine();
        }
    }
}
