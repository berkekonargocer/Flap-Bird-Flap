using System;
using Nojumpo.Enums;
using Nojumpo.ScriptableObjects.Datas.Variable;
using Nojumpo.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Nojumpo.Managers
{
    public class ScoreManager : MonoBehaviour
    {
        // -------------------------------- FIELDS --------------------------------
        [Header("SINGLETON")]
        static ScoreManager _instance;
        public static ScoreManager Instance { get { return _instance; } }

        [SerializeField] FloatVariableSO currentScore;
        public FloatVariableSO CurrentScore { get { return currentScore; } }

        [SerializeField] FloatVariableSO bestScore;
        public FloatVariableSO BestScore { get { return bestScore; } }

        AudioSource _scoreAudio;
        
        
        public event Action<float> OnAddScore;

        // ------------------------ UNITY BUILT-IN METHODS ------------------------
        void OnEnable() {
            SceneManager.sceneLoaded += SetComponents;
            OnAddScore += currentScore.AddValue;
            GameManager.Instance.OnDie += UpdateBestScore;
            GameManager.Instance.OnGameStart += ResetCurrentScore;
        }

        void OnDisable() {
            SceneManager.sceneLoaded -= SetComponents;
            OnAddScore -= currentScore.AddValue;
            GameManager.Instance.OnDie -= UpdateBestScore;
            GameManager.Instance.OnGameStart -= ResetCurrentScore;
        }

        void Awake() {
            InitializeSingleton();
        }


        // ------------------------ CUSTOM PRIVATE METHODS ------------------------
        void InitializeSingleton() {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void SetComponents(Scene scene, LoadSceneMode loadSceneMode) {
            _scoreAudio = GameObject.FindWithTag("Audios/POINT").GetComponent<AudioSource>();
        }
        bool IsCurrentScoreMoreThanHighScore() {
            return currentScore.Value > bestScore.Value;
        }

        void UpdateBestScore() {
            if (IsCurrentScoreMoreThanHighScore())
            {
                bestScore.Value = currentScore.Value;
            }
        }
        
        void ResetCurrentScore(GameState gameState) {
            currentScore.ResetValue();
        }


        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public void RaiseOnAddScoreEvent(float scoreToAdd) {
            OnAddScore?.Invoke(scoreToAdd);
            _scoreAudio.Play();
        }

    }
}
