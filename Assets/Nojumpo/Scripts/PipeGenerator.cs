using System.Collections;
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
        
        const int PIPE_SPAWN_AMOUNT_TO_INCREASE_DIFFICULTY = 20;
        const float PIPE_SPAWN_X_POSITION = 35;
        const float PIPE_CREATION_WAIT_TIME = 2.0f;
        const float GAP_Y_POSITION_SCALE_AMOUNT = 2.0f;
        const float GAP_SIZE_SCALE_AMOUNT = 2.0f;
        
        float _minGapYPosition = 40.0f;
        float _maxGapYPosition = 60.0f;
        float _gapSize = 26f;

        
        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Start() {
            StartCoroutine(nameof(CreatePipesWithGapPeriodically));
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

        void CreatePipesWithGap(float gapYPosition, float gapSize, float xPosition) {
            CreatePipe((gapYPosition - gapSize * 0.5f) / 5, xPosition, true);
            CreatePipe((CAMERA_ORTHO_SIZE * 2 - gapYPosition - gapSize * 0.5f) / 5, xPosition, false);
        }

        IEnumerator CreatePipesWithGapPeriodically() {
            
            for (int i = 0; i < PIPE_SPAWN_AMOUNT_TO_INCREASE_DIFFICULTY; i++)
            {
                float gapYPosition = Random.Range(_minGapYPosition, _maxGapYPosition + 1);
                CreatePipesWithGap(gapYPosition, _gapSize, PIPE_SPAWN_X_POSITION);
                yield return new WaitForSeconds(PIPE_CREATION_WAIT_TIME);
            }

            _minGapYPosition -= GAP_Y_POSITION_SCALE_AMOUNT;
            _maxGapYPosition += GAP_Y_POSITION_SCALE_AMOUNT;
            _gapSize -= GAP_SIZE_SCALE_AMOUNT;

            StartCoroutine(nameof(CreatePipesWithGapPeriodically));
        }
    }
}
