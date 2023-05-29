using UnityEngine;

namespace Nojumpo
{
    public class Pipe : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] float moveSpeed = 5.0f;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Update() {
            MoveLeft();
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void MoveLeft() {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------

    }
}
