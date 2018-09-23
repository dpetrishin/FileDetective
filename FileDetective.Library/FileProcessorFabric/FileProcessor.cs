using System;
using System.Collections.Generic;
using System.Text;

namespace FileDetective.Library.FileProcessorFabric
{
    /// <summary> Abstract class for processing of files with different extensions. </summary>
    public abstract class FileProcessor
    {
        /// <summary> Gets list of functions to execute during process procedure. </summary>
        protected List<Func<string, OperationResultModel>> Functions { get; } = new List<Func<string, OperationResultModel>>();

        /// <summary>
        /// Executes processing for files by implemented functions in concrete implementation of <see cref="FileProcessor"/> class.
        /// </summary>
        /// <param name="fileName"> Name of file to process. </param>
        /// <param name="s"> Stingify file content. </param>
        /// <returns> Result message in "fileName-operationName-result" format. </returns>
        public List<OperationResultModel> Process(string fileName, string s)
        {
            this.SetFunctionsToExecute();

            List<OperationResultModel> result = new List<OperationResultModel>();
            foreach (Func<string, OperationResultModel> function in this.Functions)
            {
                OperationResultModel tempResult = function(s);
                tempResult.FileName = fileName;
                result.Add(tempResult);
            }

            return result;
        }


        /// <summary> Fills <see cref="Functions"/> list. Overriding and using is required. </summary>
        public abstract void SetFunctionsToExecute();
    }
}
