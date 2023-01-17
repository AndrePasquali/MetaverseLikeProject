using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Genies.Menu
{
    public class MenuButtonToggle: MonoBehaviour
    {
        [SerializeField] private GameObject _optionsPanel;
        [SerializeField] private Button _toggleMenuButton;

        [SerializeField] private CanvasGroup _optionsPanelCanvas;
        [SerializeField] private TMP_Text _optionButtonLabel;
        
        [SerializeField] private BoxCollider _avatarCollider;
        [SerializeField] private GameObject _fade;

        private void Start()
        {
            _fade.gameObject.SetActive(true);
            _toggleMenuButton.onClick.AddListener(MenuToggle);
        }

        private void MenuToggle()
        {
            _optionsPanel.SetActive(!_optionsPanel.activeSelf);

            if (_optionsPanel.activeSelf)
            {
                _optionsPanel.transform.DOPunchScale(new Vector3(0.2F, 0.1F, 0.1F), 0.35F, 1, 0.1F)
                    .OnStart(() => { _optionsPanelCanvas.DOFade(1, 0.5F); });
            }

            var buttonEnabled = _optionsPanel.activeSelf;

            _avatarCollider.enabled = !buttonEnabled;

            _optionButtonLabel.text = buttonEnabled ? "SAVE" : "EDIT";
        }

    }
}