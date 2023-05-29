using System;
using Nojumpo.ScriptableObjects.Datas.Variable;
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

        public event Action<float> OnAddScore;

        // ------------------------ UNITY BUILT-IN METHODS ------------------------
        void OnEnable() {
            OnAddScore += currentScore.AddValue;
        }

        void OnDisable() {
            OnAddScore -= currentScore.AddValue;
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


        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public void RaiseOnAddScoreEvent(float scoreToAdd) {
            OnAddScore?.Invoke(scoreToAdd);
        }

        public void ResetCurrentScore() {
            currentScore.ResetValue();
        }
    }
}
