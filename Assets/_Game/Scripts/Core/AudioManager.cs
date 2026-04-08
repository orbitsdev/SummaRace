using UnityEngine;
using System.Collections.Generic;

namespace SummaRace.Core
{
    /// <summary>
    /// Handles all audio playback (music and SFX)
    /// </summary>
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }
        
        [Header("Audio Sources")]
        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private AudioSource _sfxSource;
        [SerializeField] private AudioSource _narrationSource;
        
        [Header("Music Clips")]
        public AudioClip menuMusic;
        public AudioClip readingMusic;
        public AudioClip missionMusic;
        public AudioClip victoryMusic;
        
        [Header("SFX Clips")]
        public AudioClip buttonClick;
        public AudioClip correctAnswer;
        public AudioClip wrongAnswer;
        public AudioClip elementCollected;
        public AudioClip pageFlip;
        public AudioClip levelComplete;
        
        [Header("Settings")]
        [Range(0f, 1f)] public float musicVolume = 1f;
        [Range(0f, 1f)] public float sfxVolume = 1f;
        
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                SetupAudioSources();
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        void Start()
        {
            LoadVolumeSettings();
        }
        
        void SetupAudioSources()
        {
            // Create audio sources if not assigned
            if (_musicSource == null)
            {
                _musicSource = gameObject.AddComponent<AudioSource>();
                _musicSource.loop = true;
                _musicSource.playOnAwake = false;
            }
            
            if (_sfxSource == null)
            {
                _sfxSource = gameObject.AddComponent<AudioSource>();
                _sfxSource.loop = false;
                _sfxSource.playOnAwake = false;
            }
            
            if (_narrationSource == null)
            {
                _narrationSource = gameObject.AddComponent<AudioSource>();
                _narrationSource.loop = false;
                _narrationSource.playOnAwake = false;
            }
        }
        
        void LoadVolumeSettings()
        {
            musicVolume = PlayerPrefs.GetFloat("musicVolume", 1f);
            sfxVolume = PlayerPrefs.GetFloat("sfxVolume", 1f);
            ApplyVolume();
        }
        
        void ApplyVolume()
        {
            _musicSource.volume = musicVolume;
            _sfxSource.volume = sfxVolume;
            _narrationSource.volume = sfxVolume;
        }
        
        // Music methods
        public void PlayMusic(AudioClip clip, float fadeTime = 0.5f)
        {
            if (clip == null) return;
            
            if (_musicSource.clip == clip && _musicSource.isPlaying) return;
            
            _musicSource.clip = clip;
            _musicSource.Play();
        }
        
        public void StopMusic()
        {
            _musicSource.Stop();
        }
        
        public void PlayMenuMusic() => PlayMusic(menuMusic);
        public void PlayReadingMusic() => PlayMusic(readingMusic);
        public void PlayMissionMusic() => PlayMusic(missionMusic);
        public void PlayVictoryMusic() => PlayMusic(victoryMusic);
        
        // SFX methods
        public void PlaySFX(AudioClip clip)
        {
            if (clip == null) return;
            _sfxSource.PlayOneShot(clip, sfxVolume);
        }
        
        public void PlayButtonClick() => PlaySFX(buttonClick);
        public void PlayCorrect() => PlaySFX(correctAnswer);
        public void PlayWrong() => PlaySFX(wrongAnswer);
        public void PlayCollected() => PlaySFX(elementCollected);
        public void PlayPageFlip() => PlaySFX(pageFlip);
        public void PlayLevelComplete() => PlaySFX(levelComplete);
        
        // Narration methods
        public void PlayNarration(AudioClip clip)
        {
            if (clip == null) return;
            _narrationSource.Stop();
            _narrationSource.clip = clip;
            _narrationSource.Play();
        }
        
        public void StopNarration()
        {
            _narrationSource.Stop();
        }
        
        public bool IsNarrationPlaying => _narrationSource.isPlaying;
        
        // Volume control
        public void SetMusicVolume(float volume)
        {
            musicVolume = Mathf.Clamp01(volume);
            _musicSource.volume = musicVolume;
            PlayerPrefs.SetFloat("musicVolume", musicVolume);
            PlayerPrefs.Save();
        }
        
        public void SetSFXVolume(float volume)
        {
            sfxVolume = Mathf.Clamp01(volume);
            _sfxSource.volume = sfxVolume;
            _narrationSource.volume = sfxVolume;
            PlayerPrefs.SetFloat("sfxVolume", sfxVolume);
            PlayerPrefs.Save();
        }
    }
}
