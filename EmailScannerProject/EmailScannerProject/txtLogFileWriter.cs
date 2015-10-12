using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EmailScannerProject
{
    class txtLogFileWriter : ILogFileWriter
    {
        public string logFileName;
        public string path = @"C:\Users\tquass_be\EmailScanner\txtLogFiles\";
        public string message = "log file created";
        public string WriteLogFile()
        {
            EmailFileScanner txtEmailFileScanner = new EmailFileScanner();
            txtEmailFileScanner.ScanEmailForSearchWords("Meetings.txt");
            txtEmailFileScanner.ScanEmailForToFromSubjectContent("Meetings.txt");

            logFileName = "Meetings.txt";
            var newPath = path + logFileName;
            if (!File.Exists(newPath))
            {
                using (StreamWriter fileWriter = File.CreateText(newPath))
                {
                    fileWriter.WriteLine(txtEmailFileScanner.logFileHeader[3]);
                    fileWriter.WriteLine(txtEmailFileScanner.logFileHeader[4]);
                    fileWriter.WriteLine(txtEmailFileScanner.logFileHeader[5]);
                    fileWriter.WriteLine("Context: ");
                    foreach (string sentence in txtEmailFileScanner.linesContainingtxtSearchWords)
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