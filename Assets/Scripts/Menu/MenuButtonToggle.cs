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

        private void Start()
        {
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

            _optionButtonLabel.text = _optionsPanel.activeSelf ? "SAVE" : "EDIT";
        }

    }
}