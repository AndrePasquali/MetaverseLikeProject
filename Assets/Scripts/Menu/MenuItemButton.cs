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

        public Image Image => _image ?? (_image = GetComponent<Image>());
        private Image _image;

        [SerializeField] private MenuOption _menuOption;

        private void Start()
        {
            M_Button.onClick.AddListener(() =>
            {
                OnItemButtonClick.Invoke(_menuOption, this);
            });
        }

        public void SetupOption(MenuOption option) => _menuOption = option;

        private void OnDestroy() => M_Button.onClick.RemoveAllListeners();
        public Color GetColor()
        {
            var image = GetComponent<Image>();
            return image.color;
        }
        
    }
}