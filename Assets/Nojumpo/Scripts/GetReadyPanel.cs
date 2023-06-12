using DG.Tweening;
using UnityEngine;

namespace Nojumpo.Scripts
{
    public class GetReadyPanel : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        CanvasGroup getReadyPanelCanvasGroup;

        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnEnable() {
            GameManager.Instance.OnGameStart += FadeOut;
        }

        void OnDisable() {
            GameManager.Instance.OnGameStart -= FadeOut;
        }

        void Awake() {
            SetComponents();
        }

        
        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
            getReadyPanelCanvasGroup = GetComponent<CanvasGroup>();
        }
        
        void FadeOut(GameState gameState) {
            getReadyPanelCanvasGroup.DOFade(0, 1.0f);
        }
    }
}