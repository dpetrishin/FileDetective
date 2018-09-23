using System;
using System.Text;
using System.Text.RegularExpressions;

namespace FileDetective.Library.FileProcessorFabric
{
    /// <summary> Processor for files with .html extension. </summary>
    public class HtmlFileProcessor : FileProcessor
    {
        /// <inheritdoc />
        public override void SetFunctionsToExecute()
        {
            this.Functions.Add(this.CalculateDivTags);
        }

        /// <summary>
        /// Calculates number of div open tags in string.
        /// </summary>
        /// <param name="input"> String to calculate. </param>
        /// <returns> Result message. </returns>
        private OperationResultModel CalculateDivTags(string input)
        {
            string template = "<div";
            string operationName = "calculate-div-tags";
            string clearedInput = input.Replace("< ", "<");
            int result = Regex.Matches(clearedInput, template).Count;
            return new OperationResultModel
                   {
                       OperationName = operationName, 
                       Result = result.ToString()
                   };
        }
    }
}
