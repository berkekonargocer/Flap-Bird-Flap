using Nojumpo.Enums;
using Nojumpo.Scripts;
using UnityEngine;

namespace Nojumpo
{
    public class MoveLeftRepetitive : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] float moveSpeed;
        const float MAX_X_POSITION = -49.5f;
        const float INITIAL_X_POSITION = 80.65f;

        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Update() {
            if (GameManager.Instance.CurrentGameState != GameState.DEAD)
            {
                MoveToLeft();

                if (transform.position.x < MAX_X_POSITION)
                {
                    ResetPosition();
                }
            }
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void MoveToLeft() {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        void ResetPosition() {
            Transform objectTransform = transform;
            objectTransform.position = new Vector3(INITIAL_X_POSITION, objectTransform.position.y);
        }

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------

    }
}
