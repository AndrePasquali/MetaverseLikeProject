using System;
using System.Collections.Generic;
using Genies.Extensions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Genies.Menu
{
    public class MenuCommandController : MonoBehaviour
    {
        private Queue<IMenuCommand> _menuCommands;
        private IMenuCommand _currentCommand;

        [Header("Dependencies")]
        [SerializeField] private Material _characterMaterial;
        [SerializeField] private Material _backgroundMaterial;
        [SerializeField] private Animator _characterAnimator;

        private void Start() => MenuButton.OnAnyButtonClick += OnButtonAction;

        private void OnButtonAction(MenuButton.ActionType actionType)
        {
            switch (actionType)
            {
                case MenuButton.ActionType.BackgroundColor:
                {
                    var color = new Color();
                    var backgroundColorCommand = new ChangeBackgroundColor(_backgroundMaterial, color.PickRandom());
            
                    backgroundColorCommand.Execute();
                    break;
                }

                case MenuButton.ActionType.CharacterColor:
                {
                    var color = new Color();
                    
                    var characterColorChangeCommand = new ChangeCharacterColor(_characterMaterial, color.PickRandom());
                    characterColorChangeCommand.Execute();
                    break;
                }

                case MenuButton.ActionType.AnimationA:
                {
                    var characterAnimationCommand = new PlayCharacterAnimation(_characterAnimator, 0);
                    characterAnimationCommand.Execute();
                    break;
                }
                case MenuButton.ActionType.AnimationB:
                {
                    var characterAnimationCommand = new PlayCharacterAnimation(_characterAnimator, 1);
                    characterAnimationCommand.Execute();
                    break;
                }
                case MenuButton.ActionType.AnimationC:
                {
                    var characterAnimationCommand = new PlayCharacterAnimation(_characterAnimator, 2);
                    characterAnimationCommand.Execute();
                    break;
                }
            }
           
        }

        private void ResetColors()
        {
            _characterMaterial.color = Color.white;
            _backgroundMaterial.color = Color.black;
        }

        private void OnDestroy() => ResetColors();
    }
}
