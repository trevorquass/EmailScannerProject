using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EmailScannerProject
{
    class xmlLogFileWriter : ILogFileWriter
    {
        public string logFileName;
        public string path = @"C:\Users\tquass_be\EmailScanner\xmlLogFiles\";
        public string message = "log file created";
        public string WriteLogFile()
        {
            EmailFileScanner xmlEmailFileScanner = new EmailFileScanner();
            xmlEmailFileScanner.ScanEmailForSearchWords("Food.xml");
            xmlEmailFileScanner.ScanEmailForToFromSubjectContent("Food.xml");

            logFileName = "Food.xml";
            var newPath = path + logFileName;
            if (!File.Exists(newPath))
            {
                using (StreamWriter fileWriter = File.CreateText(newPath))
                {
                    fileWriter.WriteLine(xmlEmailFileScanner.logFileHeader[0]);
                    fileWriter.WriteLine(xmlEmailFileScanner.logFileHeader[1]);
                    fileWriter.WriteLine(xmlEmailFileScanner.logFileHeader[3]);
                    fileWriter.WriteLine("Context: ");
                    foreach (string sentence in xmlEmailFileScanner.linesContainingxmlSearchWords)
                    {
                        fileWriter.WriteLine(sentence);
                    }
                }
                return message;
            }
            else
                return message;
        }
    }
}
