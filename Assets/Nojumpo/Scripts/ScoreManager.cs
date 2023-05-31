using System;
using Nojumpo.ScriptableObjects.Datas.Variable;
using Nojumpo.Scripts;
using UnityEngine;

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

        [SerializeField] FloatVariableSO highScore;
        public FloatVariableSO HighScore { get { return highScore; } }

        [SerializeField] AudioSource scoreAudio;
        
        
        public event Action<float> OnAddScore;

        // ------------------------ UNITY BUILT-IN METHODS ------------------------
        void OnEnable() {
            OnAddScore += currentScore.AddValue;
            GameManager.Instance.OnDie += UpdateHighScore;
        }

        void OnDisable() {
            OnAddScore -= currentScore.AddValue;
            GameManager.Instance.OnDie -= UpdateHighScore;
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

        bool IsCurrentScoreMoreThanHighScore() {
            return currentScore.Value > highScore.Value;
        }

        void UpdateHighScore() {
            if (IsCurrentScoreMoreThanHighScore())
            {
                highScore.Value = currentScore.Value;
            }
        }

        
        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public void RaiseOnAddScoreEvent(float scoreToAdd) {
            OnAddScore?.Invoke(scoreToAdd);
            scoreAudio.Play();
        }

        public void ResetCurrentScore() {
            currentScore.ResetValue();
        }
    }
}
