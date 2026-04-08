using UnityEngine;
using SummaRace.Data;

namespace SummaRace.Core
{
    /// <summary>
    /// Handles saving and loading player progress using PlayerPrefs
    /// </summary>
    public class SaveManager : MonoBehaviour
    {
        public static SaveManager Instance { get; private set; }
        
        // PlayerPrefs keys
        private const string KEY_PLAYER_NAME = "playerName";
        private const string KEY_AVATAR_INDEX = "avatarIndex";
        private const string KEY_CURRENT_LEVEL = "currentLevel";
        private const string KEY_LEVEL_STARS = "level{0}Stars";
        private const string KEY_LEVEL_UNLOCKED = "level{0}Unlocked";
        private const string KEY_MUSIC_VOLUME = "musicVolume";
        private const string KEY_SFX_VOLUME = "sfxVolume";
        private const string KEY_NARRATION_ENABLED = "narrationEnabled";
        
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        public void SaveProgress(PlayerProgress progress)
        {
            PlayerPrefs.SetString(KEY_PLAYER_NAME, progress.playerName);
            PlayerPrefs.SetInt(KEY_AVATAR_INDEX, progress.avatarIndex);
            PlayerPrefs.SetInt(KEY_CURRENT_LEVEL, progress.currentLevel);
            
            // Save stars and unlocks for each level
            for (int i = 0; i < 3; i++)
            {
                PlayerPrefs.SetInt(string.Format(KEY_LEVEL_STARS, i + 1), progress.starsPerLevel[i]);
                PlayerPrefs.SetInt(string.Format(KEY_LEVEL_UNLOCKED, i + 1), progress.levelsUnlocked[i] ? 1 : 0);
            }
            
            // Save settings
            PlayerPrefs.SetFloat(KEY_MUSIC_VOLUME, progress.musicVolume);
            PlayerPrefs.SetFloat(KEY_SFX_VOLUME, progress.sfxVolume);
            PlayerPrefs.SetInt(KEY_NARRATION_ENABLED, progress.narrationEnabled ? 1 : 0);
            
            PlayerPrefs.Save();
            Debug.Log("[SaveManager] Progress saved");
        }
        
        public PlayerProgress LoadProgress()
        {
            PlayerProgress progress = new PlayerProgress();
            
            progress.playerName = PlayerPrefs.GetString(KEY_PLAYER_NAME, "");
            progress.avatarIndex = PlayerPrefs.GetInt(KEY_AVATAR_INDEX, 0);
            progress.currentLevel = PlayerPrefs.GetInt(KEY_CURRENT_LEVEL, 1);
            
            // Load stars and unlocks
            for (int i = 0; i < 3; i++)
            {
                progress.starsPerLevel[i] = PlayerPrefs.GetInt(string.Format(KEY_LEVEL_STARS, i + 1), 0);
                progress.levelsUnlocked[i] = PlayerPrefs.GetInt(string.Format(KEY_LEVEL_UNLOCKED, i + 1), i == 0 ? 1 : 0) == 1;
            }
            
            // Load settings
            progress.musicVolume = PlayerPrefs.GetFloat(KEY_MUSIC_VOLUME, 1f);
            progress.sfxVolume = PlayerPrefs.GetFloat(KEY_SFX_VOLUME, 1f);
            progress.narrationEnabled = PlayerPrefs.GetInt(KEY_NARRATION_ENABLED, 1) == 1;
            
            Debug.Log($"[SaveManager] Progress loaded - Player: {progress.playerName}, Level: {progress.currentLevel}");
            return progress;
        }
        
        public bool HasSaveData()
        {
            return PlayerPrefs.HasKey(KEY_PLAYER_NAME) && !string.IsNullOrEmpty(PlayerPrefs.GetString(KEY_PLAYER_NAME));
        }
        
        public void ClearAllData()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
            Debug.Log("[SaveManager] All data cleared");
        }
        
        // Settings helpers
        public void SetMusicVolume(float volume)
        {
            PlayerPrefs.SetFloat(KEY_MUSIC_VOLUME, volume);
            PlayerPrefs.Save();
        }
        
        public void SetSFXVolume(float volume)
        {
            PlayerPrefs.SetFloat(KEY_SFX_VOLUME, volume);
            PlayerPrefs.Save();
        }
        
        public void SetNarrationEnabled(bool enabled)
        {
            PlayerPrefs.SetInt(KEY_NARRATION_ENABLED, enabled ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
}
