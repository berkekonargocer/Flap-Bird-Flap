using UnityEngine;

namespace Nojumpo.Scripts
{
    public class PipeGenerator : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        const float PIPE_BODY_HEIGHT = 1.0f;
        const float PIPE_BODY_SCALE = 5.0f;
        const float PIPE_HEAD_SCALE = 3.5f;
        const float CAMERA_ORTHO_SIZE = 50;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Start() {
            CreatePipesWithGap(15f, 15f, 10f);
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void CreatePipe(float pipeBodyWidth, float xPosition, bool createOnBottom) {
            Transform pipeHead = Instantiate(AssetReferences.Instance.PipeHeadPrefab);

            Transform pipeBody = Instantiate(AssetReferences.Instance.PipeBodyPrefab);
            SpriteRenderer pipeBodySpriteRenderer = pipeBody.GetComponent<SpriteRenderer>();
            BoxCollider2D pipeBodyBoxCollider2D = pipeBody.GetComponent<BoxCollider2D>();

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
                pipeBody.localScale = new Vector3(-PIPE_BODY_SCALE, PIPE_BODY_SCALE, PIPE_BODY_SCALE);
            }

            pipeHead.position = new Vector3(xPosition, pipeHeadYPosition);
            pipeBody.position = new Vector3(xPosition, pipeBodyYPosition);
            pipeBodySpriteRenderer.size = new Vector2(pipeBodyWidth, PIPE_BODY_HEIGHT);
            pipeBodyBoxCollider2D.size = new Vector2(pipeBodyWidth, PIPE_BODY_HEIGHT);
            pipeBodyBoxCollider2D.offset = new Vector2(pipeBodyWidth * 0.5f, 0f);

        }

        void CreatePipesWithGap(float yGap, float gapSize, float xPosition) {
            CreatePipe((yGap - gapSize * 0.5f) / 5, xPosition, true);
            CreatePipe((CAMERA_ORTHO_SIZE * 2 - yGap - gapSize * 0.5f) / 5, xPosition, false);
        }
    }
}
