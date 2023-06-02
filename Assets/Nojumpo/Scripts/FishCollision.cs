using DG.Tweening;
using Nojumpo.Enums;
using Nojumpo.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace Nojumpo
{
    public class FishCollision : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        SpriteRenderer _fishSpriteRenderer;
        
        [SerializeField] Color flashOnHitColor;
        
        
        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            SetComponents();
        }
        
        void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.CompareTag("Pipe"))
            {
                if (GameManager.Instance.CurrentGameState != GameState.DEAD)
                {
                    FishCollisionFlash();
                    GameManager.Instance.RaiseOnDieEvent();
                }
            }
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
            _fishSpriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        void FishCollisionFlash() {
            _fishSpriteRenderer.color = flashOnHitColor;
            _fishSpriteRenderer.DOColor(Color.white, 0.75f);
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------

    }
}