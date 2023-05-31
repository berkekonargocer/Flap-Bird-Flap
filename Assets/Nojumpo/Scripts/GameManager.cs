using System;
using Nojumpo.Enums;
using UnityEngine;

namespace Nojumpo.Scripts
{
    public class GameManager : MonoBehaviour
    {
        // -------------------------------- FIELDS --------------------------------
        [Header("SINGLETON")]
        static GameManager _instance;
        public static GameManager Instance { get { return _instance; } }

        public event Action OnDie;
        public GameState CurrentGameState { get; private set; } = GameState.READYTOPLAY;

        [SerializeField] AudioSource dieAudio;
        
        
        // ------------------------ UNITY BUILT-IN METHODS ------------------------
        void OnEnable() {
            OnDie += Die;
        }

        void OnDisable() {
            OnDie -= Die;
        }

        void Awake() {
            InitializeSingleton();
            
            SetCurrentGameState(GameState.PLAYING);
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

        void Die() {
            CurrentGameState = GameState.DEAD;
        }
        
        
        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public void SetCurrentGameState(GameState gameState) {
            CurrentGameState = gameState;
        }
        
        public void RaiseOnDieEvent() {
            OnDie?.Invoke();
            dieAudio.Play();
        }
    }
}