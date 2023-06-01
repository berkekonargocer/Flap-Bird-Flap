using Nojumpo.Enums;
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
                if (GameManager.Instance.CurrentGameState != GameState.DEAD)
                {
                    GameManager.Instance.RaiseOnDieEvent();
                }
            }
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------



        // ------------------------- CUSTOM PUBLIC METHODS -------------------------

    }
}