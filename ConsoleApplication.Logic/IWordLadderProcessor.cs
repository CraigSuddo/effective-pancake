namespace ConsoleApplication.Logic
{
    /// <summary>
    /// The interface for the Processor so that the interface is properly segregated and can be properly reused in the future.
    /// </summary>
    public interface IWordLadderProcessor
    {
        public IWordLadderProcessorResult Process();
    }
}