using Nojumpo.Enums;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Nojumpo.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BirdMovementController : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        Rigidbody2D _birdRigidbody2D;
        Animator _birdAnimatorController;
        
        const int SWIM_AMOUNT = 40;
        const float MAX_Y_POSITION = 45.0f;
        bool _swimInput;

        [SerializeField] AudioSource flapAudio;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnEnable() {
            GameManager.Instance.OnGameStart += SetRigidbodyToDynamic;
            GameManager.Instance.OnDie += StopAnimation;
        }

        void OnDisable() {
            GameManager.Instance.OnGameStart -= SetRigidbodyToDynamic;
            GameManager.Instance.OnDie -= StopAnimation;
        }
        
        void Awake() {
            SetComponents();
        }

        void Update() {
            transform.eulerAngles = new Vector3(0, 0, _birdRigidbody2D.velocity.y * 0.4f);

            if (GameManager.Instance.CurrentGameState == GameState.DEAD)
                return;

            if (_swimInput && transform.position.y < MAX_Y_POSITION)
            {
                if (GameManager.Instance.CurrentGameState == GameState.READYTOPLAY)
                {
                    GameManager.Instance.RaiseOnGameStartEvent(GameState.PLAYING);
                }
                
                Flap();
            }
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
            _birdRigidbody2D = GetComponent<Rigidbody2D>();
            _birdAnimatorController = GetComponent<Animator>();
        }

        void OnJump(InputValue inputValue) {
            _swimInput = inputValue.isPressed;
        }

        void Flap() {
            _birdRigidbody2D.velocity = Vector2.up * SWIM_AMOUNT;
            flapAudio.Play();
        }

        void SetRigidbodyToDynamic(GameState gameState) {
            _birdRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        }

        void StopAnimation() {
            _birdAnimatorController.enabled = false;
        }
    }
}