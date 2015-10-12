using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace EmailScannerProject
{
    public class EmailFileScanner
    {
        public List<string> emailFilePaths = new List<string>();
        public string lineOfEmail;
        public List<string> txtSearchWords = new List<string>();
        public List<string> csvSearchWords = new List<string>();
        public List<string> xmlSearchWords = new List<string>();
        public List<string> linesContainingtxtSearchWords = new List<string>();
        public List<string> linesContainingcsvSearchWords = new List<string>();
        public List<string> linesContainingxmlSearchWords = new List<string>();
        public string sentenceContainingSearchWord;

        public string toContent;
        public string fromContent;
        public string subjectContent;
        public List<string> logFileHeader = new List<string>();

        public List<string> ScanEmailForSearchWords(string logFileName)
        {
            emailFilePaths.Add(@"C:\Users\tquass_be\EmailScanner\Lunch.email");
            emailFilePaths.Add(@"C:\Users\tquass_be\EmailScanner\NewProject.email");
            emailFilePaths.Add(@"C:\Users\tquass_be\EmailScanner\Promotion.email");

            txtSearchWords.Add("meet ");
            txtSearchWords.Add("meeting ");
            txtSearchWords.Add("meetings ");
            txtSearchWords.Add("schedule ");

            csvSearchWords.Add("you ");
            csvSearchWords.Add("Randy,");
            csvSearchWords.Add("Savage ");
            csvSearchWords.Add("Randy.Savage@SoftTech.com");

            xmlSearchWords.Add("free ");
            xmlSearchWords.Add("food ");
            xmlSearchWords.Add("meal ");
            xmlSearchWords.Add("breakfast ");
            xmlSearchWords.Add("lunch ");
            xmlSearchWords.Add("dinner ");

            switch (logFileName)
            {
                case "Meetings.txt":
                    foreach (string emailFilePath in emailFilePaths)
                    {
                        using (StreamReader emailFile = new StreamReader(emailFilePath))
                        {
                            while ((lineOfEmail = emailFile.ReadLine()) != null)
                            {
                                foreach (string emailSearchWord in txtSearchWords)
                                {
                                    if (lineOfEmail.Contains(emailSearchWord))
                                    {
                                        string sentenceContainingSearchWord = Regex.Replace(lineOfEmail, "(?:.*?\\.\\s)?((?:[^.]*?)" + emailSearchWord + "[^.]*?\\.)(?:.*)", "$1");
                                        linesContainingtxtSearchWords.Add(sentenceContainingSearchWord);
                                    }
                                }
                            }
                        }
                    }
                    return linesContainingtxtSearchWords;
                case "PersonalReferences.csv":
                    foreach (string emailFilePath in emailFilePaths)
                    {
                        using (StreamReader emailFile = new StreamReader(emailFilePath))
                        {
                            while ((lineOfEmail = emailFile.ReadLine()) != null)
                            {
                                foreach (string emailSearchWord in csvSearchWords)
                                {
                                    if (lineOfEmail.Contains(emailSearchWord))
                                    {
                                        string sentenceContainingSearchWord = Regex.Replace(lineOfEmail, "(?:.*?\\.\\s)?((?:[^.]*?)" + emailSearchWord + "[^.]*?\\.)(?:.*)", "$1");
                                        linesContainingcsvSearchWords.Add(sentenceContainingSearchWord);
                                    }
                                }
                            }
                        }
                    }
                    return linesContainingcsvSearchWords;
                case "Food.xml":
                    foreach (string emailFilePath in emailFilePaths)
                    {
                        using (StreamReader emailFile = new StreamReader(emailFilePath))
                        {
                            while ((lineOfEmail = emailFile.ReadLine()) != null)
                            {
                                foreach (string emailSearchWord in xmlSearchWords)
                                {
                                    if (lineOfEmail.Contains(emailSearchWord))
                                    {
                                        string sentenceContainingSearchWord = Regex.Replace(lineOfEmail, "(?:.*?\\.\\s)?((?:[^.]*?)" + emailSearchWord + "[^.]*?\\.)(?:.*)", "$1");
                                        linesContainingxmlSearchWords.Add(sentenceContainingSearchWord);
                                    }
                                }
                            }
                        }
                    }
                    return linesContainingxmlSearchWords;
                default:
                    return null;
            }
        }
        public List<string> ScanEmailForToFromSubjectContent(string logFileName)
        {
            emailFilePaths.Add(@"C:\Users\tquass_be\EmailScanner\Lunch.email");
            emailFilePaths.Add(@"C:\Users\tquass_be\EmailScanner\NewProject.email");
            emailFilePaths.Add(@"C:\Users\tquass_be\EmailScanner\Promotion.email");

            switch (logFileName)
            {
                case "Meetings.txt":
                    foreach (string emailFilePath in emailFilePaths)
                    {
                        using (StreamReader emailFile = new StreamReader(emailFilePath))
                        {
                            while ((lineOfEmail = emailFile.ReadLine()) != null)
                            {
                                if (lineOfEmail.Contains("to:"))
                                {
                                    toContent = lineOfEmail;
                                    logFileHeader.Add(toContent);
                                }
                                else if (lineOfEmail.Contains("from:"))
                                {
                                    fromContent = lineOfEmail;
                                    logFileHeader.Add(fromContent);
                                }
                                else if (lineOfEmail.Contains("subject:"))
                                {
                                    subjectContent = lineOfEmail;
                                    logFileHeader.Add(subjectContent);
                                }
                            }
                        }
                    }
                    return logFileHeader;
                case "PersonalReferences.csv":
                    foreach (string emailFilePath in emailFilePaths)
                    {
                        using (StreamReader emailFile = new StreamReader(emailFilePath))
                        {
                            while ((lineOfEmail = emailFile.ReadLine()) != null)
                            {
                                if (lineOfEmail.Contains("to:"))
                                {
                                    toContent = lineOfEmail;
                                    logFileHeader.Add(toContent);
                                }
                                else if (lineOfEmail.Contains("from:"))
                                {
                                    fromContent = lineOfEmail;
                                    logFileHeader.Add(fromContent);
                                }
                                else if (lineOfEmail.Contains("subject:"))
                                {
                                    subjectContent = lineOfEmail;
                                    logFileHeader.Add(subjectContent);
                                }
                            }
                        }
                    }
                    return logFileHeader;
                case "Food.xml":
                    foreach (string emailFilePath in emailFilePaths)
                    {
                        using (StreamReader emailFile = new StreamReader(emailFilePath))
                        {
                            while ((lineOfEmail = emailFile.ReadLine()) != null)
                            {
                                if (lineOfEmail.Contains("to:"))
                                {
                                    toContent = lineOfEmail;
                                    logFileHeader.Add(toContent);
                                }
                                else if (lineOfEmail.Contains("from:"))
                                {
                                    fromContent = lineOfEmail;
                                    logFileHeader.Add(fromContent);
                                }
                                else if (lineOfEmail.Contains("subject:"))
                                {
                                    subjectContent = lineOfEmail;
                                    logFileHeader.Add(subjectContent);
                                }
                            }
                        }
                    }
                    return logFileHeader;
                default:
                    return null;
            }
        }
    }
}
