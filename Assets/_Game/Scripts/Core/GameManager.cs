using UnityEngine;
using SummaRace.Data;

namespace SummaRace.Core
{
    /// <summary>
    /// Singleton that tracks game state across all scenes
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        
        [Header("Current Session")]
        public string playerName;
        public int avatarIndex;
        public int currentLevel = 1;
        
        [Header("Progress")]
        public int[] starsPerLevel = new int[3];
        public bool[] levelsUnlocked = new bool[3] { true, false, false };
        
        [Header("Current Story Data")]
        public StoryData currentStory;
        
        [Header("Mission State")]
        public int collectedCorrect;
        public int collectedWrong;
        public ElementData[] collectedElements = new ElementData[5];
        
        void Awake()
        {
            // Singleton pattern
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                Initialize();
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        void Initialize()
        {
            // Load saved progress
            if (SaveManager.Instance != null)
            {
                LoadProgress();
            }
        }
        
        public void LoadProgress()
        {
            PlayerProgress progress = SaveManager.Instance.LoadProgress();
            playerName = progress.playerName;
            avatarIndex = progress.avatarIndex;
            currentLevel = progress.currentLevel;
            starsPerLevel = progress.starsPerLevel;
            levelsUnlocked = progress.levelsUnlocked;
        }
        
        public void SaveProgress()
        {
            PlayerProgress progress = new PlayerProgress
            {
                playerName = playerName,
                avatarIndex = avatarIndex,
                currentLevel = currentLevel,
                starsPerLevel = starsPerLevel,
                levelsUnlocked = levelsUnlocked
            };
            SaveManager.Instance.SaveProgress(progress);
        }
        
        public void SetPlayerInfo(string name, int avatar)
        {
            playerName = name;
            avatarIndex = avatar;
            SaveProgress();
        }
        
        public void SelectLevel(int level)
        {
            if (level >= 1 && level <= 3 && levelsUnlocked[level - 1])
            {
                currentLevel = level;
            }
        }
        
        public void CompleteLevel(int stars)
        {
            int levelIndex = currentLevel - 1;
            
            // Update stars (keep highest)
            if (stars > starsPerLevel[levelIndex])
            {
                starsPerLevel[levelIndex] = stars;
            }
            
            // Unlock next level
            if (currentLevel < 3)
            {
                levelsUnlocked[currentLevel] = true;
            }
            
            SaveProgress();
        }
        
        public void ResetMissionState()
        {
            collectedCorrect = 0;
            collectedWrong = 0;
            collectedElements = new ElementData[5];
        }
        
        public bool IsGameComplete()
        {
            // All 3 levels completed with at least 1 star
            for (int i = 0; i < 3; i++)
            {
                if (starsPerLevel[i] == 0) return false;
            }
            return true;
        }
    }
}
