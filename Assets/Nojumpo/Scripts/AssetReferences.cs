using UnityEngine;

namespace Nojumpo.Scripts
{
    public class AssetReferences : MonoBehaviour
    {
        // -------------------------------- FIELDS --------------------------------
        [Header("SINGLETON")]
        static AssetReferences _instance;
        public static AssetReferences Instance { get { return _instance; } }

        [Header("ASSETS")]
        public Pipe PipePrefab;


        // ------------------------ UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            InitializeSingleton();
        }


        // ------------------------ CUSTOM PRIVATE METHODS ------------------------
        void InitializeSingleton() {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}