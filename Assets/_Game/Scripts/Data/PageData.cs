using System;

namespace SummaRace.Data
{
    /// <summary>
    /// Represents a single page in a story
    /// </summary>
    [Serializable]
    public class PageData
    {
        public int pageNumber;          // 1-5
        public string text;             // Story text for this page
        public string illustrationPath; // Path to illustration image
        public string narrationPath;    // Path to audio narration (optional)
        public QuestionData question;   // Comprehension question for this page
    }
}
