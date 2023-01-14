using System;
using UnityEngine;
using UnityEngine.UI;

namespace Genies.Menu
{
    [RequireComponent(typeof(Button))]
    public class MenuButton: MonoBehaviour
    {
        private Button _button;
        public Button M_Button => _button ?? (_button = GetComponent<Button>());

        public static event Action OnAnyButtonClick;

        private void Start()
        {
            M_Button.onClick.AddListener(() =>
            {
                OnAnyButtonClick.Invoke();
            });
        }

        private void OnDestroy() => M_Button.onClick.RemoveAllListeners();
    }
}