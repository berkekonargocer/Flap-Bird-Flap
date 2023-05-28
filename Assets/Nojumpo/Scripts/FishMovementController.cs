using UnityEngine;
using UnityEngine.InputSystem;

namespace Nojumpo.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class FishMovementController : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        Rigidbody2D _fishRigidbody2D;

        bool _jumpInput;
        
        const int JUMP_AMOUNT = 85;
        
        
        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            SetComponents();
        }
        
        void Update() {
            if (_jumpInput)
            {
                Jump();
            }
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
            _fishRigidbody2D = GetComponent<Rigidbody2D>();
        }

        void OnJump(InputValue inputValue) {
            _jumpInput = inputValue.isPressed;
        }
        
        void Jump() {
            _fishRigidbody2D.velocity = Vector2.up * JUMP_AMOUNT;
        }

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------

    }
}