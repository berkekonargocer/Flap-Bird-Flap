using Nojumpo.Managers;
using Nojumpo.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Nojumpo
{
    public class GameOverPanel : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        Animator gameOverPanelAnimator;
        readonly int GameOver = Animator.StringToHash("GameOver");

        [SerializeField] Image medalImage;
        [SerializeField] TextMeshProUGUI scoreText;
        [SerializeField] TextMeshProUGUI bestScoreText;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnEnable() {
            GameManager.Instance.OnDie += PlayAnimation;
            GameManager.Instance.OnDie += UpdateScoreTexts;
            GameManager.Instance.OnDie += SelectMedalSprite;
        }

        void OnDisable() {
            GameManager.Instance.OnDie -= PlayAnimation;
            GameManager.Instance.OnDie -= UpdateScoreTexts;
            GameManager.Instance.OnDie -= SelectMedalSprite;
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
            if (ScoreManager.Instance.CurrentScore.Value < 30)
            {
                medalImage.gameObject.SetActive(false);
                return;
            }

            if (ScoreManager.Instance.CurrentScore.Value >= 30 && ScoreManager.Instance.CurrentScore.Value < 60)
            {
                medalImage.sprite = AssetReferences.Instance.SilverMedalSprite;
            }
            else
            {
                medalImage.sprite = AssetReferences.Instance.GoldenMedalSprite;
            }
        }
        
        void UpdateScoreTexts() {
            scoreText.text = $"{ScoreManager.Instance.CurrentScore.Value}";
            bestScoreText.text = $"{ScoreManager.Instance.BestScore.Value}";
        }
    }
}