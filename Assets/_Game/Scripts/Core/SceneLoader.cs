using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace SummaRace.Core
{
    /// <summary>
    /// Handles scene transitions with optional fade effects and async loading
    /// </summary>
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader Instance { get; private set; }

        [Header("Scene Names")]
        public const string SCENE_MAIN_MENU = "00_MainMenu";
        public const string SCENE_SPLASH = "00_Splash";
        public const string SCENE_NAME_ENTRY = "01_NameEntry";
        public const string SCENE_TEACHER_WELCOME = "02_TeacherWelcome";
        public const string SCENE_LEVEL_SELECT = "03_LevelSelect";
        public const string SCENE_STORY_READER = "04_StoryReader";
        public const string SCENE_MISSION_INTRO = "05_MissionIntro";
        public const string SCENE_MISSION_3D_RUN = "06_Mission3DRun";
        public const string SCENE_FINAL_SUMMARY = "07_FinalSummary";
        public const string SCENE_VICTORY = "08_Victory";
        public const string SCENE_GAME_COMPLETE = "99_GameComplete";

        [Header("Transition Settings")]
        [SerializeField] private float _fadeDuration = 0.5f;
        [SerializeField] private CanvasGroup _fadeCanvasGroup;

        [Header("Loading Indicator")]
        [SerializeField] private CanvasGroup _loadingIndicator;
        [SerializeField] private RectTransform _loadingSpinner;
        [SerializeField] private float _spinnerSpeed = 360f;

        private bool _isTransitioning;
        private bool _showSpinner;
        
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);

                // Hide loading indicator initially
                if (_loadingIndicator != null)
                {
                    _loadingIndicator.alpha = 0f;
                    _loadingIndicator.blocksRaycasts = false;
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void Update()
        {
            // Spin the loading indicator
            if (_showSpinner && _loadingSpinner != null)
            {
                _loadingSpinner.Rotate(0f, 0f, -_spinnerSpeed * Time.unscaledDeltaTime);
            }
        }
        
        // Quick load methods for each scene
        public void LoadMainMenu() => LoadScene(SCENE_MAIN_MENU);
        public void LoadSplash() => LoadScene(SCENE_SPLASH);
        public void LoadNameEntry() => LoadScene(SCENE_NAME_ENTRY);
        public void LoadTeacherWelcome() => LoadScene(SCENE_TEACHER_WELCOME);
        public void LoadLevelSelect() => LoadScene(SCENE_LEVEL_SELECT);
        public void LoadStoryReader() => LoadScene(SCENE_STORY_READER);
        public void LoadMissionIntro() => LoadScene(SCENE_MISSION_INTRO);
        public void LoadMission3DRun() => LoadScene(SCENE_MISSION_3D_RUN);
        public void LoadFinalSummary() => LoadScene(SCENE_FINAL_SUMMARY);
        public void LoadVictory() => LoadScene(SCENE_VICTORY);
        public void LoadGameComplete() => LoadScene(SCENE_GAME_COMPLETE);
        
        /// <summary>
        /// Load a scene by name with fade transition
        /// </summary>
        public void LoadScene(string sceneName, bool useFade = true)
        {
            if (_isTransitioning) return;
            
            if (useFade && _fadeCanvasGroup != null)
            {
                StartCoroutine(LoadSceneWithFade(sceneName));
            }
            else
            {
                SceneManager.LoadScene(sceneName);
            }
        }
        
        /// <summary>
        /// Load a scene by build index
        /// </summary>
        public void LoadScene(int sceneIndex, bool useFade = true)
        {
            if (_isTransitioning) return;
            
            string sceneName = SceneManager.GetSceneByBuildIndex(sceneIndex).name;
            LoadScene(sceneName, useFade);
        }
        
        private IEnumerator LoadSceneWithFade(string sceneName)
        {
            _isTransitioning = true;

            // Fade out
            yield return StartCoroutine(Fade(1f));

            // Show loading indicator
            ShowLoadingIndicator();

            // Load scene asynchronously
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
            asyncLoad.allowSceneActivation = false;

            // Wait until scene is loaded (progress reaches 0.9)
            while (asyncLoad.progress < 0.9f)
            {
                yield return null;
            }

            // Hide loading indicator
            HideLoadingIndicator();

            // Activate the scene
            asyncLoad.allowSceneActivation = true;

            // Wait a frame for scene to initialize
            yield return null;

            // Fade in
            yield return StartCoroutine(Fade(0f));

            _isTransitioning = false;
        }

        private void ShowLoadingIndicator()
        {
            _showSpinner = true;
            if (_loadingIndicator != null)
            {
                _loadingIndicator.alpha = 1f;
                _loadingIndicator.blocksRaycasts = true;
            }
        }

        private void HideLoadingIndicator()
        {
            _showSpinner = false;
            if (_loadingIndicator != null)
            {
                _loadingIndicator.alpha = 0f;
                _loadingIndicator.blocksRaycasts = false;
            }
        }
        
        private IEnumerator Fade(float targetAlpha)
        {
            if (_fadeCanvasGroup == null) yield break;
            
            float startAlpha = _fadeCanvasGroup.alpha;
            float elapsed = 0f;
            
            while (elapsed < _fadeDuration)
            {
                elapsed += Time.deltaTime;
                _fadeCanvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsed / _fadeDuration);
                yield return null;
            }
            
            _fadeCanvasGroup.alpha = targetAlpha;
        }
        
        /// <summary>
        /// Reload the current scene
        /// </summary>
        public void ReloadCurrentScene()
        {
            LoadScene(SceneManager.GetActiveScene().name);
        }
        
        /// <summary>
        /// Get current scene name
        /// </summary>
        public string GetCurrentSceneName()
        {
            return SceneManager.GetActiveScene().name;
        }
        
        /// <summary>
        /// Quit the application
        /// </summary>
        public void QuitGame()
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
    }
}
