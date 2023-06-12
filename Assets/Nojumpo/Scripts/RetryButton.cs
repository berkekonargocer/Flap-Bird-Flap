using UnityEngine;
using UnityEngine.SceneManagement;

namespace Nojumpo.Scripts
{
    public class RetryButton : MonoBehaviour
    {
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void Retry() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            GameManager.Instance.SetCurrentGameState(GameState.READYTOPLAY);
        }
    }
}