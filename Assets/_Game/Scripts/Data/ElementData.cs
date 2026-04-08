using System;

namespace SummaRace.Data
{
    /// <summary>
    /// Represents a story element (Somebody, Wanted, But, So, Then)
    /// </summary>
    [Serializable]
    public class ElementData
    {
        public string type;         // "Somebody", "Wanted", "But", "So", "Then"
        public string correctText;  // The correct answer text
        public string iconPath;     // Path to the icon sprite
        
        // For the 3-lane answer cards in mission
        public string[] options;    // 3 options (1 correct, 2 wrong)
        public int correctIndex;    // Which option is correct (0, 1, or 2)
    }
}
