namespace TextMatch.Service
{
    public interface ITextMatchService
    {        
        /// <summary>
        ///     This method takes a text to search and a subtext to match on then returns the positions in the text where the
        ///     subtext matched.
        /// </summary>
        /// <param name="text">The text that we are trying to find matches in.</param>
        /// <param name="subtext">The subtext that we are using to find matches in the text with.</param>
        /// <returns></returns>
        string ProcessInputs(string text, string subtext);
    }
}