using UnityEngine;
using UnityEngine.UI;

namespace Assets.Menu
{
    public class SettingsController : MonoBehaviour
    {
        [SerializeField]
        private ValueSetup _gameFieldWidth;

        [SerializeField]
        private ValueSetup _gameFieldHeight;

        [SerializeField]
        private ValueSetup _figuresSize;

        [SerializeField]
        private Button _startGameButton;

        private void Start()
        {
            SetStartGameButtonOnClickEvent();
        }

        private void SetStartGameButtonOnClickEvent()
        {
            _startGameButton.onClick.AddListener(PreStartingSettingsSaving);
        }

        private void PreStartingSettingsSaving()
        {
            PlayerPrefs.SetInt(_gameFieldWidth.ValueName, _gameFieldWidth.Value);
            PlayerPrefs.SetInt(_gameFieldHeight.ValueName, _gameFieldHeight.Value);
            PlayerPrefs.SetInt(_figuresSize.ValueName, _figuresSize.Value);
        }
    }
}
