using UnityEngine;

namespace Nojumpo
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class FishMovementController : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        Rigidbody2D _fishRigidbody2D;

        const int JUMP_AMOUNT = 85;
        
        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            SetComponents();
        }
        
        void Update() {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Jump();
            }
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
            _fishRigidbody2D = GetComponent<Rigidbody2D>();
        }

        void Jump() {
            _fishRigidbody2D.velocity = Vector2.up * JUMP_AMOUNT;
        }

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------

    }
}