using UnityEngine;

namespace Nojumpo.ScriptableObjects.Datas.Variable
{
    [CreateAssetMenu(fileName = "NewFloatVariable", menuName = "Nojumpo/Scriptable Objects/Datas/Variables/New Float Variable")]
    public class FloatVariableSO : ScriptableObject
    {
#if UNITY_EDITOR

        [Multiline]
        [SerializeField] string _developerDescription = string.Empty;

#endif

        [Tooltip("Float value to use")]
        [SerializeField] float _value;
        public float Value { get { return _value; } set { this._value = value; } }


        public void SetValue(float value) {
            Value = value;
        }

        public void SetValue(FloatVariableSO value) {
            Value = value.Value;
        }

        public void AddValue(float valueToAdd) {
            Value += valueToAdd;
        }

        public void AddValue(FloatVariableSO valueToAdd) {
            Value += valueToAdd.Value;
        }

        public void ResetValue() {
            _value = 0;
        }
    }
}
