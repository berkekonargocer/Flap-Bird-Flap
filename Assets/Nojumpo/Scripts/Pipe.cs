using System;
using UnityEngine;
using UnityEngine.Pool;

namespace Nojumpo
{
    public class Pipe : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        IObjectPool<Pipe> _pipePool;

        const float FISH_X_POSITION = 0.0f;
        const float CAMERA_X_BOUND = -80.0f;

        bool _isOutOfCameraXBound = false;
        [SerializeField] float pipeMoveSpeed = 10.0f;
        

        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Update() {
            CheckIsOutOfCameraXBound();
            if (_isOutOfCameraXBound)
            {
                _pipePool?.Release(this);
                _isOutOfCameraXBound = false;
            }
            
            MoveLeft();
            
            if (IsPassedTheFish())
            {
                
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
            return transform.position.x < FISH_X_POSITION;
        }

        
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void SetPool(IObjectPool<Pipe> pipePool) {
            _pipePool = pipePool;
        }
    }
}
