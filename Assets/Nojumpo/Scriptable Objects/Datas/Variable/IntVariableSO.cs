using UnityEngine;

namespace Nojumpo.ScriptableObjects.Datas.Variable
{
    [CreateAssetMenu(fileName = "NewFloatVariable", menuName = "Nojumpo/Scriptable Objects/Datas/Variables/New Float Variable")]
    public class IntVariableSO : ScriptableObject
    {
#if UNITY_EDITOR

        [Multiline]
        [SerializeField] string _developerDescription = string.Empty;

#endif

        [Tooltip("Integer value to use")]
        [SerializeField] int _value;
        public int Value { get { return _value; } set { this._value = value; } }


        public void SetValue(int value) {
            Value = value;
        }

        public void SetValue(IntVariableSO value) {
            Value = value.Value;
        }

        public void AddValue(int valueToAdd) {
            Value += valueToAdd;
        }

        public void AddValue(IntVariableSO valueToAdd) {
            Value += valueToAdd.Value;
        }

        public void ResetValue() {
            _value = 0;
        }
    }
}
