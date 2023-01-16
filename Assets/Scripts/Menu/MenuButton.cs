using System;
using Genies.Menu.Enums;
using UnityEngine;
using UnityEngine.UI;

namespace Genies.Menu
{
    [RequireComponent(typeof(Button))]
    public class MenuButton: MonoBehaviour
    {
        private Button _button;
        public Button M_Button => _button ?? (_button = GetComponent<Button>());

        public static event Action<MenuOption, int> OnAnyButtonClick;

        [SerializeField] private MenuOption _menuOption;

        private void Start()
        {
            M_Button.onClick.AddListener(() =>
            {
                OnAnyButtonClick.Invoke(_menuOption, 0);
            });
        }

        private void OnDestroy() => M_Button.onClick.RemoveAllListeners();
    }
}