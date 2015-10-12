using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailScannerProject
{
    class Program
    {
        static void Main(string[] args)
        {
            LogFileWriterFactory.WriteLogFile(FileType.txt);
            LogFileWriterFactory.WriteLogFile(FileType.csv);
            LogFileWriterFactory.WriteLogFile(FileType.xml);
        }
    }
}
