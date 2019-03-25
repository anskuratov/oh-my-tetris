using UnityEngine;
using UnityEngine.UI;

namespace Assets.Menu
{
    public class ValueSetup : MonoBehaviour
    {
        [SerializeField]
        private string _valueName;

        [SerializeField]
        private Button _decreaseButton;

        [SerializeField]
        private Button _increaseButton;

        [SerializeField]
        private Text _valueLabel;

        [SerializeField]
        private int _maxValue = 10;

        [SerializeField]
        private int _minValue = 3;

        private int _value;
        public int Value
        {
            get
            {
                return _value;
            }

            private set
            {
                if (value >= _minValue && value <= _maxValue)
                {
                    _value = value;
                    _valueLabel.text = _value.ToString();
                }
            }
        }

        public string ValueName
        {
            get
            {
                return _valueName;
            }
        }

        private void Start()
        {
            GetPreferencesValue();
            SetButtonsOnClickEvents();
        }

        private void GetPreferencesValue()
        {
            var preferencesValue = PlayerPrefs.GetInt(_valueName);

            if (preferencesValue == 0)
            {
                PlayerPrefs.SetInt(_valueName, _minValue);
                Value = _minValue;
            }
            else
                Value = preferencesValue;
        }

        private void SetButtonsOnClickEvents()
        {
            _decreaseButton.onClick.AddListener(delegate { --Value; });
            _increaseButton.onClick.AddListener(delegate { ++Value; });
        }
    }
}
