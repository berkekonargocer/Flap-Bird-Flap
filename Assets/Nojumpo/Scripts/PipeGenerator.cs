using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

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
        const float PIPE_SPAWN_RATE = 2.0f;
        const float GAP_Y_POSITION_SCALE_AMOUNT = 2.0f;
        const float GAP_SIZE_SCALE_AMOUNT = 2.0f;

        float _minGapYPosition = 40.0f;
        float _maxGapYPosition = 60.0f;
        float _gapSize = 26f;

        IObjectPool<Pipe> _pipePool;
        [SerializeField] bool checkCollection;
        [SerializeField] int defaultAmount;
        [SerializeField] int maxAmount;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            _pipePool = new ObjectPool<Pipe>(CreatePipe, OnGetPipe, OnReleasePipe, OnDestroyPipe, checkCollection, defaultAmount, maxAmount);
        }

        void Start() {
            StartCoroutine(nameof(CreatePipesWithGapPeriodically));
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------

        Pipe CreatePipe() {
            Pipe pipe = Instantiate(AssetReferences.Instance.PipePrefab, transform.position, Quaternion.identity);
            pipe.SetPool(_pipePool);
            return pipe;
        }

        void OnGetPipe(Pipe pipe) {
            pipe.gameObject.SetActive(true);
            float gapYPosition = Random.Range(_minGapYPosition, _maxGapYPosition + 1);
            SetPipeGap(pipe, gapYPosition, _gapSize, PIPE_SPAWN_X_POSITION);
        }

        void OnReleasePipe(Pipe pipe) {
            Debug.Log("RELEASED");
            pipe.gameObject.transform.position = new Vector3(0, 0, 0);
            pipe.gameObject.SetActive(false);
        }

        void OnDestroyPipe(Pipe pipe) {
            Destroy(pipe.gameObject);
        }

        void SetPipeGap(Pipe pipe, float gapYPosition, float gapSize, float xPosition) {
            Transform pipeObject = pipe.transform;

            // Pipe on bottom
            float bottomPipeBodyWidth = (gapYPosition - gapSize * 0.5f) / 5;

            Transform bottomPipeBody = pipeObject.transform.GetChild(0).GetChild(0);
            Transform bottomPipeHead = pipeObject.transform.GetChild(0).GetChild(1);
            SpriteRenderer bottomPipeBodySpriteRenderer = bottomPipeBody.GetComponent<SpriteRenderer>();
            BoxCollider2D bottomPipeBodyBoxCollider2D = bottomPipeBody.GetComponent<BoxCollider2D>();

            float bottomPipeHeadYPosition = -CAMERA_ORTHO_SIZE + bottomPipeBodyWidth * 5;
            float bottomPipeBodyYPosition = -CAMERA_ORTHO_SIZE;

            bottomPipeHead.position = new Vector3(xPosition, bottomPipeHeadYPosition);
            bottomPipeBody.position = new Vector3(xPosition, bottomPipeBodyYPosition);
            bottomPipeBodySpriteRenderer.size = new Vector2(bottomPipeBodyWidth, PIPE_BODY_HEIGHT);
            bottomPipeBodyBoxCollider2D.size = new Vector2(bottomPipeBodyWidth, PIPE_BODY_HEIGHT);
            bottomPipeBodyBoxCollider2D.offset = new Vector2(bottomPipeBodyWidth * 0.5f, 0f);

            // Pipe on top
            float topPipeBodyWidth = (CAMERA_ORTHO_SIZE * 2 - gapYPosition - gapSize * 0.5f) / 5;

            Transform topPipeBody = pipeObject.transform.GetChild(1).GetChild(0);
            Transform topPipeHead = pipeObject.transform.GetChild(1).GetChild(1);
            SpriteRenderer topPipeBodySpriteRenderer = topPipeBody.GetComponent<SpriteRenderer>();
            BoxCollider2D topPipeBodyBoxCollider2D = topPipeBody.GetComponent<BoxCollider2D>();

            float topPipeHeadYPosition = CAMERA_ORTHO_SIZE + topPipeBodyWidth * -5;
            float topPipeBodyYPosition = CAMERA_ORTHO_SIZE;
            topPipeHead.localScale = new Vector3(-PIPE_HEAD_SCALE, PIPE_HEAD_SCALE, PIPE_HEAD_SCALE);
            topPipeBody.localScale = new Vector3(-PIPE_BODY_SCALE, PIPE_BODY_SCALE, PIPE_BODY_SCALE);

            topPipeHead.position = new Vector3(xPosition, topPipeHeadYPosition);
            topPipeBody.position = new Vector3(xPosition, topPipeBodyYPosition);
            topPipeBodySpriteRenderer.size = new Vector2(topPipeBodyWidth, PIPE_BODY_HEIGHT);
            topPipeBodyBoxCollider2D.size = new Vector2(topPipeBodyWidth, PIPE_BODY_HEIGHT);
            topPipeBodyBoxCollider2D.offset = new Vector2(topPipeBodyWidth * 0.5f, 0f);
        }

        IEnumerator CreatePipesWithGapPeriodically() {

            for (int i = 0; i < PIPE_SPAWN_AMOUNT_TO_INCREASE_DIFFICULTY; i++)
            {
                _pipePool.Get();
                yield return new WaitForSeconds(PIPE_SPAWN_RATE);
            }

            Debug.Log("End Of For Loop");
            _minGapYPosition -= GAP_Y_POSITION_SCALE_AMOUNT;
            _maxGapYPosition += GAP_Y_POSITION_SCALE_AMOUNT;
            _gapSize -= GAP_SIZE_SCALE_AMOUNT;

            StartCoroutine(nameof(CreatePipesWithGapPeriodically));
        }
    }
}
