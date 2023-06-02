using Nojumpo.Enums;
using Nojumpo.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Nojumpo
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