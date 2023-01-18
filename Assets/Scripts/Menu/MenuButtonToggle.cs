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

        [SerializeField] private CanvasGroup _panelCanvas;

        [SerializeField]
        private CanvasGroup PanelCanvas => _panelCanvas ?? (_panelCanvas = _optionsPanel.GetComponent<CanvasGroup>());

        private bool _toggleEnabled;
        

        private void Start()
        {
            _fade.gameObject.SetActive(true);
            _toggleMenuButton.onClick.AddListener(HandleToggle);
        }

        private void HandleToggle()
        {
            _toggleEnabled = !_toggleEnabled;
            
            HandleMenu();
        }

        private void HandleMenu()
        {
            if (_toggleEnabled) PanelCanvas.DOFade(1, 0.5F).OnComplete(() =>
                {
                    _optionsPanel.transform.DOPunchScale(new Vector3(0.2F, 0.1F, 0.1F), 0.125F, 0, 0F);
                });

            var buttonEnabled = _toggleEnabled;

            _avatarCollider.enabled = !buttonEnabled;

            _optionButtonLabel.text = buttonEnabled ? "SAVE" : "EDIT";

            if (!buttonEnabled) PanelCanvas.DOFade(0, 0.25F);
            
        }
    }
}