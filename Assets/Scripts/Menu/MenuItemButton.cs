using System;
using Genies.Menu.Enums;
using UnityEngine;
using UnityEngine.UI;

namespace Genies.Menu
{
    [RequireComponent(typeof(Button))]
    public class MenuItemButton: MonoBehaviour, IColor
    {
        private Button _button;
        public Button M_Button => _button ?? (_button = GetComponent<Button>());
        public static event Action<MenuOption, MenuItemButton> OnItemButtonClick;

        [SerializeField] private MenuOption _menuOption;

        private void Start()
        {
            M_Button.onClick.AddListener(() =>
            {
                OnItemButtonClick.Invoke(_menuOption, this);
            });
        }

        private void OnDestroy() => M_Button.onClick.RemoveAllListeners();
        public Color GetColor()
        {
            var image = GetComponent<Image>();
            return image.color;
        }
    }
}