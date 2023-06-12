using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Nojumpo.Scripts
{
    public class GameOverPanel : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        Animator gameOverPanelAnimator;
        readonly int GameOver = Animator.StringToHash("GameOver");

        [SerializeField] Image medalImage;
        [SerializeField] Image newBestImage;
        [SerializeField] TextMeshProUGUI scoreText;
        [SerializeField] TextMeshProUGUI bestScoreText;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnEnable() {
            GameManager.Instance.OnDie += ShowNewBestImage;
            GameManager.Instance.OnDie += UpdateScoreTexts;
            GameManager.Instance.OnDie += SelectMedalSprite;
            GameManager.Instance.OnDie += PlayAnimation;
        }

        void OnDisable() {
            GameManager.Instance.OnDie -= ShowNewBestImage;
            GameManager.Instance.OnDie -= UpdateScoreTexts;
            GameManager.Instance.OnDie -= SelectMedalSprite;
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

        void SelectMedalSprite() {
            if (ScoreManager.Instance.CurrentScore.Value < 60)
            {
                medalImage.gameObject.SetActive(false);
                return;
            }

            if (ScoreManager.Instance.CurrentScore.Value >= 60 && ScoreManager.Instance.CurrentScore.Value < 80)
            {
                medalImage.sprite = AssetReferences.Instance.SilverMedalSprite;
            }
            else if (ScoreManager.Instance.CurrentScore.Value >= 80 && ScoreManager.Instance.CurrentScore.Value < 100)
            {
                medalImage.sprite = AssetReferences.Instance.SilverMedalSprite;
            }
            else
            {
                medalImage.sprite = AssetReferences.Instance.GoldenMedalSprite;
            }
        }

        void ShowNewBestImage() {
            if (ScoreManager.Instance.IsNewBest())
            {
                newBestImage.gameObject.SetActive(true);
            }
        }

        void UpdateScoreTexts() {
            scoreText.text = $"{ScoreManager.Instance.CurrentScore.Value}";

            if (ScoreManager.Instance.IsNewBest())
            {
                bestScoreText.text = $"{ScoreManager.Instance.CurrentScore.Value}";
            }
            else
            {
                bestScoreText.text = $"{PlayerPrefs.GetInt("Best Score")}";
            }
        }
    }
}