using Nojumpo.Scripts;
using TMPro;
using UnityEngine;

namespace Nojumpo.Managers
{
    public class ScorePanel : MonoBehaviour
    {
        // -------------------------------- FIELDS --------------------------------
        [SerializeField] TextMeshProUGUI highScoreText;
        [SerializeField] TextMeshProUGUI currentScoreText;
        

        // ------------------------ UNITY BUILT-IN METHODS ------------------------
        void OnEnable() {
            ScoreManager.Instance.OnAddScore += UpdateCurrentScoreText;
            GameManager.Instance.OnDie += UpdateHighScoreText;
        }

        void OnDisable() {
            ScoreManager.Instance.OnAddScore -= UpdateCurrentScoreText;
            GameManager.Instance.OnDie -= UpdateHighScoreText;
        }


        // ------------------------ CUSTOM PRIVATE METHODS ------------------------
        void UpdateCurrentScoreText(float scoreToAdd) {
            currentScoreText.text = $"{ScoreManager.Instance.CurrentScore.Value}";
        }

        void UpdateHighScoreText() {
            highScoreText.text = $"High Score: {ScoreManager.Instance.HighScore.Value}";
        }
    }
}