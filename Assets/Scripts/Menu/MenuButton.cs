using System;
using UnityEngine;
using UnityEngine.UI;

namespace Genies.Menu
{
    [RequireComponent(typeof(Button))]
    public class MenuButton: MonoBehaviour
    {
        public enum ActionType
        {
            BackgroundColor,
            CharacterColor,
            CharacterHeadColor,
            AnimationA,
            AnimationB,
            AnimationC,
            AnimationD
        }

        public ActionType ButtonActionType;
        
        private Button _button;
        public Button M_Button => _button ?? (_button = GetComponent<Button>());

        public static event Action<ActionType> OnAnyButtonClick;

        private void Start()
        {
            M_Button.onClick.AddListener(() =>
            {
                OnAnyButtonClick.Invoke(ButtonActionType);
            });
        }

        private void OnDestroy() => M_Button.onClick.RemoveAllListeners();
    }
}