using System;
using System.Collections.Generic;
using System.IO;

using FileDetective.Library;
using FileDetective.Library.FileProcessorFabric;

namespace FileDetective.Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = DirectoryHelper.PrepareDirectory();
            Console.WriteLine($"Default folder to detective files is: \"{path}\"");
            Console.WriteLine($"Logs if placed in: \"{DirectoryHelper.logsFileFullPath}\"");


            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = path;
            watcher.Created += Watcher_Created;

            watcher.EnableRaisingEvents = true;

            Console.ReadKey();
        }

        private static void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            string fileName = e.Name;
            string extension = Path.GetExtension(e.FullPath);

            string content = DirectoryHelper.ReadFromFile(e.FullPath);

            FileProcessor processor = FileProcessorHelper.GetProcessor(extension);

            List<OperationResultModel> resultList = processor.Process(fileName, content);
            
            foreach (OperationResultModel result in resultList)
            {
                File.AppendAllText(DirectoryHelper.logsFileFullPath, result.ToString());
                Console.WriteLine(result.ToString());
            }
        }
    }
}
