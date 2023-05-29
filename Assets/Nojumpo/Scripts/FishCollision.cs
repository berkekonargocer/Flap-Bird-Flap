using Nojumpo.Scripts;
using UnityEngine;

namespace Nojumpo
{
    public class FishCollision : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------

        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.CompareTag("Pipe"))
            {
                Debug.Log("PIPED");
                GameManager.Instance.RaiseOnDieEvent();
            }
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------



        // ------------------------- CUSTOM PUBLIC METHODS -------------------------

    }
}