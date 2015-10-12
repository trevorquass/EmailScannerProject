using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailScannerProject
{
    public class LogFileWriterFactory
    {
        public static ILogFileWriter WriteLogFile(FileType type)
        {
            ILogFileWriter logFileWriter = null;
            switch (type)
            {
                case FileType.txt:
                    logFileWriter = new txtLogFileWriter();
                    logFileWriter.WriteLogFile();
                    break;
                case FileType.csv:
                    logFileWriter = new csvLogFileWriter();
                    logFileWriter.WriteLogFile();
                    break;
                case FileType.xml:
                    logFileWriter = new xmlLogFileWriter();
                    logFileWriter.WriteLogFile();
                    break;
            }
            return logFileWriter;
        }
    }
}