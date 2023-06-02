using Nojumpo.Scripts;
using UnityEngine;

namespace Nojumpo
{
    public class GameOverPanel : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        Animator gameOverPanelAnimator;
        readonly int GameOver = Animator.StringToHash("GameOver");


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnEnable() {
            GameManager.Instance.OnDie += PlayAnimation;
        }

        void OnDisable() {
            GameManager.Instance.OnDie -= PlayAnimation;
        }
        
        void Awake() {
            SetComponents();    
        }
        

        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
            gameOverPanelAnimator = GetComponent<Animator>();
        }

        void PlayAnimation() {
            gameOverPanelAnimator.SetBool(GameOver, true);
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------

    }
}