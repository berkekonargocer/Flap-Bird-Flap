using System;
using Nojumpo.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Nojumpo.Scripts
{
    public class GameManager : MonoBehaviour
    {
        // -------------------------------- FIELDS --------------------------------
        [Header("SINGLETON")]
        static GameManager _instance;
        public static GameManager Instance { get { return _instance; } }

        public event Action<GameState> OnGameStart; 
        public event Action OnDie;
        public GameState CurrentGameState { get; private set; } = GameState.READYTOPLAY;

        AudioSource _dieAudio;
        
        
        // ------------------------ UNITY BUILT-IN METHODS ------------------------
        void OnEnable() {
            SceneManager.sceneLoaded += SetComponents;
            OnDie += Die;
            OnGameStart += SetCurrentGameState;
        }

        void OnDisable() {
            SceneManager.sceneLoaded -= SetComponents;
            OnDie -= Die;
            OnGameStart -= SetCurrentGameState;
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
            _dieAudio = GameObject.FindWithTag("Audios/DIE").GetComponent<AudioSource>();
        }
        
        void Die() {
            _dieAudio.Play();
            CurrentGameState = GameState.DEAD;
        }
        
        
        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public void SetCurrentGameState(GameState gameState) {
            CurrentGameState = gameState;
        }
        
        public void RaiseOnDieEvent() {
            OnDie?.Invoke();
        }

        public void RaiseOnGameStartEvent(GameState gameState) {
            OnGameStart?.Invoke(gameState);
        }
    }
}