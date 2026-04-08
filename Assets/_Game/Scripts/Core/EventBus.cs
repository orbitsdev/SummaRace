using UnityEngine;
using System;

namespace SummaRace.Core
{
    /// <summary>
    /// Simple event system for decoupled communication between scripts
    /// </summary>
    public class EventBus : MonoBehaviour
    {
        public static EventBus Instance { get; private set; }
        
        // Game flow events
        public event Action OnGameStart;
        public event Action OnGamePause;
        public event Action OnGameResume;
        
        // Story events
        public event Action<int> OnPageChanged;           // pageNumber
        public event Action<bool> OnQuestionAnswered;     // isCorrect
        public event Action OnStoryCompleted;
        
        // Mission events
        public event Action OnMissionStart;
        public event Action OnMissionEnd;
        public event Action<int> OnDangerLevelChanged;    // newDangerLevel
        public event Action<string> OnElementCollected;   // elementType
        public event Action<bool> OnAnswerCardCollected;  // isCorrect
        public event Action OnPlayerCaught;
        
        // UI events
        public event Action<string> OnShowMessage;        // message
        public event Action OnHideMessage;
        
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
        
        // Game flow triggers
        public void TriggerGameStart() => OnGameStart?.Invoke();
        public void TriggerGamePause() => OnGamePause?.Invoke();
        public void TriggerGameResume() => OnGameResume?.Invoke();
        
        // Story triggers
        public void TriggerPageChanged(int pageNumber) => OnPageChanged?.Invoke(pageNumber);
        public void TriggerQuestionAnswered(bool isCorrect) => OnQuestionAnswered?.Invoke(isCorrect);
        public void TriggerStoryCompleted() => OnStoryCompleted?.Invoke();
        
        // Mission triggers
        public void TriggerMissionStart() => OnMissionStart?.Invoke();
        public void TriggerMissionEnd() => OnMissionEnd?.Invoke();
        public void TriggerDangerLevelChanged(int level) => OnDangerLevelChanged?.Invoke(level);
        public void TriggerElementCollected(string type) => OnElementCollected?.Invoke(type);
        public void TriggerAnswerCardCollected(bool isCorrect) => OnAnswerCardCollected?.Invoke(isCorrect);
        public void TriggerPlayerCaught() => OnPlayerCaught?.Invoke();
        
        // UI triggers
        public void TriggerShowMessage(string message) => OnShowMessage?.Invoke(message);
        public void TriggerHideMessage() => OnHideMessage?.Invoke();
        
        // Clean up when destroyed
        void OnDestroy()
        {
            // Clear all event subscriptions
            OnGameStart = null;
            OnGamePause = null;
            OnGameResume = null;
            OnPageChanged = null;
            OnQuestionAnswered = null;
            OnStoryCompleted = null;
            OnMissionStart = null;
            OnMissionEnd = null;
            OnDangerLevelChanged = null;
            OnElementCollected = null;
            OnAnswerCardCollected = null;
            OnPlayerCaught = null;
            OnShowMessage = null;
            OnHideMessage = null;
        }
    }
}
