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
        
        const int JUMP_AMOUNT = 40;
        
        
        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            SetComponents();
        }
        
        void Update() {
            transform.eulerAngles = new Vector3(0, 0, _fishRigidbody2D.velocity.y * 0.4f);
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