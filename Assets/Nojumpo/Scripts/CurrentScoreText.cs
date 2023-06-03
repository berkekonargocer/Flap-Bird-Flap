using DG.Tweening;
using Nojumpo.Enums;
using Nojumpo.Scripts;
using TMPro;
using UnityEngine;

namespace Nojumpo.Managers
{
    public class CurrentScoreText : MonoBehaviour
    {
        // -------------------------------- FIELDS --------------------------------
        [SerializeField] TextMeshProUGUI currentScoreText;
        

        // ------------------------ UNITY BUILT-IN METHODS ------------------------
        void OnEnable() {
            ScoreManager.Instance.OnAddScore += UpdateCurrentScoreText;
            GameManager.Instance.OnGameStart += FadeIn;
        }

        void OnDisable() {
            ScoreManager.Instance.OnAddScore -= UpdateCurrentScoreText;
            GameManager.Instance.OnGameStart -= FadeIn;
        }


        // ------------------------ CUSTOM PRIVATE METHODS ------------------------
        void FadeIn(GameState gameState) {
            UpdateCurrentScoreText(0);
            currentScoreText.DOFade(1, 1.0f);
        }
        
        void UpdateCurrentScoreText(float scoreToAdd) {
            currentScoreText.text = $"{ScoreManager.Instance.CurrentScore.Value}";
        }
    }
}