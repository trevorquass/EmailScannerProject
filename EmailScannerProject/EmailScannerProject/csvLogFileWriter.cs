using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EmailScannerProject
{
    class csvLogFileWriter : ILogFileWriter
    {
        public string logFileName;
        public string path = @"C:\Users\tquass_be\EmailScanner\csvLogFiles\";
        public string message = "log file created";
        public string WriteLogFile()
        {
            EmailFileScanner csvEmailFileScanner = new EmailFileScanner();
            csvEmailFileScanner.ScanEmailForSearchWords("PersonalReferences.csv");
            csvEmailFileScanner.ScanEmailForToFromSubjectContent("PersonalReferences.csv");

            logFileName = "PersonalReferences.csv";
            var newPath = path + logFileName;
            if (!File.Exists(newPath))
            {
                using (StreamWriter fileWriter = File.CreateText(newPath))
                {
                    fileWriter.WriteLine(csvEmailFileScanner.logFileHeader[6]);
                    fileWriter.WriteLine(csvEmailFileScanner.logFileHeader[7]);
                    fileWriter.WriteLine(csvEmailFileScanner.logFileHeader[8]);
                    fileWriter.WriteLine("Context: ");
                    foreach (string sentence in csvEmailFileScanner.linesContainingcsvSearchWords)
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