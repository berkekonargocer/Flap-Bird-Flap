using System;
using DG.Tweening;
using Nojumpo.Enums;
using Nojumpo.Scripts;
using UnityEngine;

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
                FishCollisionFlash();
                GameManager.Instance.RaiseOnDieEvent();
            }
        }
        
        void SetComponents() {
            _fishSpriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        void FishCollisionFlash() {
            _fishSpriteRenderer.color = flashOnHitColor;
            _fishSpriteRenderer.DOColor(Color.white, 0.75f);
        }
    }
}