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
        }

        void OnDisable() {
            ScoreManager.Instance.OnAddScore -= UpdateCurrentScoreText;
        }


        // ------------------------ CUSTOM PRIVATE METHODS ------------------------
        void UpdateCurrentScoreText(float scoreToAdd) {
            currentScoreText.text = $"{ScoreManager.Instance.CurrentScore.Value}";
        }
    }
}