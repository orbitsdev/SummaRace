using System;

namespace SummaRace.Data
{
    /// <summary>
    /// Represents a comprehension question for a story page
    /// </summary>
    [Serializable]
    public class QuestionData
    {
        public string questionText;     // The question to ask
        public string[] options;        // Answer options (usually 3)
        public int correctIndex;        // Index of correct answer
        public string feedbackCorrect;  // "Great job!" etc.
        public string feedbackWrong;    // "Not quite!" etc.
    }
}
