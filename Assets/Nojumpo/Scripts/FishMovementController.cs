using Nojumpo.Enums;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Nojumpo.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class FishMovementController : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        Rigidbody2D _fishRigidbody2D;
        Animator _fishAnimatorController;
        
        const int SWIM_AMOUNT = 40;
        const float MAX_Y_POSITION = 45.0f;
        bool _swimInput;

        [SerializeField] AudioSource swimAudio;


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
            transform.eulerAngles = new Vector3(0, 0, _fishRigidbody2D.velocity.y * 0.4f);

            if (GameManager.Instance.CurrentGameState == GameState.DEAD)
                return;

            if (_swimInput && transform.position.y < MAX_Y_POSITION)
            {
                if (GameManager.Instance.CurrentGameState == GameState.READYTOPLAY)
                {
                    GameManager.Instance.RaiseOnGameStartEvent(GameState.PLAYING);
                }
                
                Swim();
            }
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
            _fishRigidbody2D = GetComponent<Rigidbody2D>();
            _fishAnimatorController = GetComponent<Animator>();
        }

        void OnJump(InputValue inputValue) {
            _swimInput = inputValue.isPressed;
        }

        void Swim() {
            _fishRigidbody2D.velocity = Vector2.up * SWIM_AMOUNT;
            swimAudio.Play();
        }

        void SetRigidbodyToDynamic(GameState gameState) {
            _fishRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        }

        void StopAnimation() {
            _fishAnimatorController.enabled = false;
        }
    }
}
