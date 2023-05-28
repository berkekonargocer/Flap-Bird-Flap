using UnityEngine;

namespace Nojumpo.Scripts
{
    public class PipeGenerator : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        const float PIPE_BODY_HEIGHT = 1.0f;
        const float PIPE_HEAD_SCALE = 3.5f;
        const float CAMERA_ORTHO_SIZE = 50;

        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnEnable() {

        }

        void OnDisable() {

        }

        void Awake() {

        }

        void Start() {
            CreatePipe(6, 0, false);
            CreatePipe(4, -10, true);
            CreatePipe(2, -20, false);
        }

        void Update() {

        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void CreatePipe(float pipeBodyWidth, float xPosition, bool createOnBottom) {
            Transform pipeHead = Instantiate(AssetReferences.Instance.PipeHeadPrefab);

            Transform pipeBody = Instantiate(AssetReferences.Instance.PipeBodyPrefab);
            SpriteRenderer pipeBodySpriteRenderer = pipeBody.GetComponent<SpriteRenderer>();
            
            
            float pipeHeadYPosition;
            float pipeBodyYPosition;
            if (createOnBottom)
            {
                pipeHeadYPosition = -CAMERA_ORTHO_SIZE + pipeBodyWidth * 5;
                pipeBodyYPosition = -CAMERA_ORTHO_SIZE;
            }
            else
            {
                pipeHeadYPosition = CAMERA_ORTHO_SIZE + pipeBodyWidth * -5;
                pipeBodyYPosition = CAMERA_ORTHO_SIZE;
                pipeHead.localScale = new Vector3(-PIPE_HEAD_SCALE, PIPE_HEAD_SCALE, PIPE_HEAD_SCALE);
                pipeBodyWidth = -pipeBodyWidth;
            }
            
            pipeHead.position = new Vector3(xPosition, pipeHeadYPosition);
            pipeBody.position = new Vector3(xPosition, pipeBodyYPosition);
            pipeBodySpriteRenderer.size = new Vector2(pipeBodyWidth, PIPE_BODY_HEIGHT);

        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------

    }
}