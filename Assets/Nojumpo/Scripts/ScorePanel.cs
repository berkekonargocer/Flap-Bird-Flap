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
        }

        void OnDisable() {
            ScoreManager.Instance.OnAddScore -= UpdateCurrentScoreText;
        }


        // ------------------------ CUSTOM PRIVATE METHODS ------------------------
        void UpdateCurrentScoreText(float scoreToAdd) {
            currentScoreText.text = $"{ScoreManager.Instance.CurrentScore.Value}";
        }

        void UpdateHighScoreText() {
            highScoreText.text = $"{ScoreManager.Instance.HighScore.Value}";
        }
    }
}