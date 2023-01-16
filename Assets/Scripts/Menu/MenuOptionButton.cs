using System;
using Genies.Menu.Enums;
using UnityEngine;
using UnityEngine.UI;

namespace Genies.Menu
{
    public class MenuOptionButton: MonoBehaviour
    {
        private Button _button;
        public Button M_Button => _button ?? (_button = GetComponent<Button>());
        public static event Action<MenuOption, GameObject> OnOptionButtonClick;

        [SerializeField] private MenuOption _menuOption;
        [SerializeField] private GameObject _optionPanel;

        protected bool Enabled
        {
            get => _enabled;
            private set
            {
                _enabled = value;
                _optionPanel.gameObject.SetActive(value);
            }
        }
        private bool _enabled;

        private void Start()
        {
            M_Button.onClick.AddListener(() =>
            {
                OnOptionButtonClick.Invoke(_menuOption, _optionPanel);
            });
        }

        public void SetEnabled(bool value) => Enabled = value;

        public MenuOption GetOption() => _menuOption;

        private void OnDestroy() => M_Button.onClick.RemoveAllListeners();
    }
}