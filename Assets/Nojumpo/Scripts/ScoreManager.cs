using System;
using System.Collections;
using Nojumpo.Enums;
using Nojumpo.ScriptableObjects.Datas.Variable;
using Nojumpo.Scripts;
using Unity.VisualScripting;
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

        [SerializeField] IntVariableSO currentScore;
        public IntVariableSO CurrentScore { get { return currentScore; } }

        AudioSource _scoreAudio;

        public event Action<int> OnAddScore;


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


        void UpdateBestScore() {
            StartCoroutine(nameof(UpdateBestScoreCoroutine));
        }

        void ResetCurrentScore(GameState gameState) {
            currentScore.ResetValue();
        }

        IEnumerator UpdateBestScoreCoroutine() {
            yield return new WaitForSeconds(1.0f);

            if (IsNewBest())
            {
                PlayerPrefs.SetInt("Best Score", currentScore.Value);
            }
        }

        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public void RaiseOnAddScoreEvent(int scoreToAdd) {
            OnAddScore?.Invoke(scoreToAdd);
            _scoreAudio.Play();
        }

        public bool IsNewBest() {
            return currentScore.Value > PlayerPrefs.GetInt("Best Score");
        }
    }
}
