using FileDetective.Library.FileProcessorFabric;

namespace FileDetective.Library
{
    public static class FileProcessorHelper
    {
        public static FileProcessor GetProcessor(string fileExtension)
        {
            switch (fileExtension)
            {
                case ".css":
                    return new CssFileProcessor();
                case ".html":
                    return new HtmlFileProcessor();
                default:
                    return new DefaultFileProcessor();
            }
        }
    }
}
