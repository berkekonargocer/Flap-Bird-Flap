using DG.Tweening;
using UnityEngine;

namespace Nojumpo.Scripts
{
    public class BirdCollision : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        SpriteRenderer _birdSpriteRenderer;
        
        [SerializeField] Color flashOnHitColor;
        
        
        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            SetComponents();
        }
        
        void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.CompareTag("Pipe"))
            {
                Die();
            }
        }

        void OnCollisionEnter2D(Collision2D other) {
            if (other.gameObject.CompareTag("Ground"))
            {
                Die();
            }
        }

        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void Die() {
            if (GameManager.Instance.CurrentGameState != GameState.DEAD)
            {
                BirdCollisionFlash();
                GameManager.Instance.RaiseOnDieEvent();
            }
        }
        
        void SetComponents() {
            _birdSpriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        void BirdCollisionFlash() {
            _birdSpriteRenderer.color = flashOnHitColor;
            _birdSpriteRenderer.DOColor(Color.white, 0.75f);
        }
    }
}