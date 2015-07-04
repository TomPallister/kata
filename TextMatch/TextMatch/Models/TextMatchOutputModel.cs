namespace TextMatch.Models
{
    public class TextMatchOutputModel
    {
        public TextMatchOutputModel(string output)
        {
            Output = output;
        }

        public string Output { get; private set; }
    }
}