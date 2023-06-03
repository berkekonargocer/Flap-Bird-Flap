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
            GameManager.Instance.OnGameStart += ShowCurrentScoreText;
        }

        void OnDisable() {
            ScoreManager.Instance.OnAddScore -= UpdateCurrentScoreText;
            GameManager.Instance.OnGameStart -= ShowCurrentScoreText;
        }


        // ------------------------ CUSTOM PRIVATE METHODS ------------------------
        void ShowCurrentScoreText(GameState gameState) {
            UpdateCurrentScoreText(0);
            currentScoreText.enabled = true;
        }
        
        void UpdateCurrentScoreText(float scoreToAdd) {
            currentScoreText.text = $"{ScoreManager.Instance.CurrentScore.Value}";
        }
    }
}