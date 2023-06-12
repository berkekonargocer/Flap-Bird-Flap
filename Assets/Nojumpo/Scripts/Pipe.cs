using UnityEngine;
using UnityEngine.Pool;

namespace Nojumpo.Scripts
{
    public class Pipe : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        IObjectPool<Pipe> _pipePool;

        const float FISH_X_POSITION = -40.0f;
        const float CAMERA_X_BOUND = -80.0f;

        bool _isOutOfCameraXBound = false;
        bool _isScored;
        
        [SerializeField] float pipeMoveSpeed = 10.0f;
        

        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Update() {
            if (GameManager.Instance.CurrentGameState == GameState.DEAD)
                return;
            
            CheckIsOutOfCameraXBound();
            if (_isOutOfCameraXBound)
            {
                _pipePool?.Release(this);
                _isOutOfCameraXBound = false;
                _isScored = false;
            }
            
            MoveLeft();
            
            if (IsPassedTheFish() && !_isScored)
            {
                ScoreManager.Instance.RaiseOnAddScoreEvent(1);
                _isScored = true;
            }
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void MoveLeft() {
            transform.Translate(Vector3.left * pipeMoveSpeed * Time.deltaTime);
        }

        void CheckIsOutOfCameraXBound() {
            if (transform.position.x < CAMERA_X_BOUND)
            {
                _isOutOfCameraXBound = true;
            }
        }
        bool IsPassedTheFish() {
            return transform.position.x <= FISH_X_POSITION;
        }

        
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void SetPool(IObjectPool<Pipe> pipePool) {
            _pipePool = pipePool;
        }
    }
}