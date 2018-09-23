namespace FileDetective.Library.FileProcessorFabric
{
    /// <summary> Processor for files with .css extension. </summary>
    public class CssFileProcessor : FileProcessor
    {
        /// <inheritdoc />
        public override void SetFunctionsToExecute()
        {
            this.Functions.Add(this.CheckBraketsClosedCorrectly);
        }

        /// <summary> Checks that string has equal quantity of open and close curly brackets. </summary>
        /// <param name="s"> String to check. </param>
        /// <returns> Result message. </returns>
        private OperationResultModel CheckBraketsClosedCorrectly(string s)
        {
            bool allBraketsClosed = false;
            string operationName = "brakets-closed-correctly";

            int balancer = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '{')
                {
                    balancer++;
                }
                else if (s[i] == '}')
                {
                    balancer--;
                }
            }

            if (balancer == 0)
            {
                allBraketsClosed = true;
            }

            return new OperationResultModel
                   {
                       OperationName = operationName, 
                       Result = allBraketsClosed.ToString().ToLowerInvariant()
                   };
        }
    }
}
