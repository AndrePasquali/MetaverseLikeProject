using System;
using UnityEngine;
using UnityEngine.UI;

namespace Genies.Menu
{
    public class MenuButtonToggle: MonoBehaviour
    {
        [SerializeField] private GameObject _optionsPanel;
        [SerializeField] private Button _toggleMenuButton;

        private void Start()
        {
            _toggleMenuButton.onClick.AddListener(MenuToggle);
        }

        private void MenuToggle()
        {
            _optionsPanel.SetActive(!_optionsPanel.activeSelf);
        }

    }
}