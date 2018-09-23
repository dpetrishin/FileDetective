using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileDetective.Terminal
{
    public static class DirectoryHelper
    {
        public static string logsFileName = "logs.txt";

        public static string logsFileFullPath = Path.Combine(Directory.GetCurrentDirectory(), logsFileName);
        public static string PrepareDirectory()
        {
            string current = Directory.GetCurrentDirectory();
            string detective = Path.Combine(current, "detective");

            Directory.CreateDirectory(detective);

            return detective;
        }

        public static string ReadFromFile(string fullPath)
        {
            string content = string.Empty;
            using (FileStream fs = File.OpenRead(fullPath))
            using (TextReader tr = new StreamReader(fs))
            {
                content = tr.ReadToEnd();
            }

            return content;
        }
    }
}
