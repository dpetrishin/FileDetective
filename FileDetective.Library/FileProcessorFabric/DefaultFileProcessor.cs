namespace FileDetective.Library.FileProcessorFabric
{
    /// <summary> Processor for files. </summary>
    public class DefaultFileProcessor : FileProcessor
    {
        /// <inheritdoc />
        public override void SetFunctionsToExecute()
        {
            this.Functions.Add(this.CalculatePunctuationMarks);
        }

        /// <summary> Calculates number of punctuation marks. </summary>
        /// <param name="s"> String to calculate. </param>
        /// <returns> Result message. </returns>
        private OperationResultModel CalculatePunctuationMarks(string s)
        {
            string operationName = "calculate-punctuation-marks";
            int count = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsPunctuation(s[i]))
                {
                    count++;
                }
            }

            return new OperationResultModel
                   {
                       OperationName = operationName, 
                       Result = count.ToString()
                   };
        }
    }
}