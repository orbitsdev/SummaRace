using System;

namespace SummaRace.Data
{
    /// <summary>
    /// Represents saved player progress
    /// </summary>
    [Serializable]
    public class PlayerProgress
    {
        public string playerName;
        public int avatarIndex;             // Selected avatar (0-3)
        public int currentLevel;            // Last played level (1-3)
        public int[] starsPerLevel;         // Stars earned per level (0-3 each)
        public bool[] levelsUnlocked;       // Which levels are unlocked
        
        // Settings
        public float musicVolume;
        public float sfxVolume;
        public bool narrationEnabled;
        
        public PlayerProgress()
        {
            playerName = "";
            avatarIndex = 0;
            currentLevel = 1;
            starsPerLevel = new int[3] { 0, 0, 0 };
            levelsUnlocked = new bool[3] { true, false, false }; // Level 1 unlocked by default
            musicVolume = 1f;
            sfxVolume = 1f;
            narrationEnabled = true;
        }
        
        /// <summary>
        /// Calculate stars based on performance
        /// </summary>
        public static int CalculateStars(int correctAnswers, int totalQuestions, float timeRemaining, float totalTime)
        {
            float accuracy = (float)correctAnswers / totalQuestions;
            float timeBonus = timeRemaining / totalTime;
            
            // 3 stars: 100% correct + time bonus
            // 2 stars: 80%+ correct
            // 1 star: Completed level
            
            if (accuracy >= 1f && timeBonus > 0.2f) return 3;
            if (accuracy >= 0.8f) return 2;
            return 1;
        }
    }
}
