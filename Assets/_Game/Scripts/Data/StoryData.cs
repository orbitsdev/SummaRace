using System;

namespace SummaRace.Data
{
    /// <summary>
    /// Represents a complete story with all pages and mission elements
    /// </summary>
    [Serializable]
    public class StoryData
    {
        public int levelNumber;         // 1, 2, or 3
        public string title;            // "Max the Puppy"
        public string difficulty;       // "Easy", "Medium", "Hard"

        // Story content
        public PageData[] pages;        // 5 pages

        // Mission elements (Somebody-Wanted-But-So-Then)
        public ElementData[] elements;  // 5 elements

        // Level balance settings
        public float missionDuration;   // Timer in seconds (90, 75, 60)
        public float playerSpeed;       // Base speed (8, 10, 12)
        public int startingDanger;      // Starting danger level (20, 30, 40)
        public int dangerOnCorrect;     // Danger decrease on correct (-20)
        public int dangerOnWrong;       // Danger increase on wrong (+15)
    }
}
