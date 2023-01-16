using System.Collections.Generic;
using Genies.Extensions;
using Genies.Menu.Enums;
using UnityEngine;

namespace Genies.Menu
{
    public class MenuCommandController : MonoBehaviour
    {
        private Queue<IMenuCommand> _menuCommands;
        private IMenuCommand _currentCommand;

        [Header("Dependencies")]
        [SerializeField] private Material _characterMaterial;
        [SerializeField] private Material _characterHeadMaterial;
        [SerializeField] private Material _backgroundMaterial;
        [SerializeField] private Animator _characterAnimator;
        

        private void Start() => MenuButton.OnAnyButtonClick += OnButtonAction;

        private void OnButtonAction(MenuOption actionType, int actionItemId)
        {
            switch (actionType)
            {
                case MenuOption.BACKGROUND:
                {
                    var color = new Color();
                    var backgroundColorCommand = new ChangeBackgroundCommand(_backgroundMaterial, color.PickRandom());

                    backgroundColorCommand.Execute();
                    
                    break;
                }

                case MenuOption.BODY:
                {
                    var color = new Color();
                    
                    var characterColorChangeCommand = new CharacterBodyCommand(_characterMaterial, color.PickRandom());
                    characterColorChangeCommand.Execute();
                    break;
                }
                
                case MenuOption.HEAD:
                {
                    var color = new Color();
                    
                    var characterColorChangeCommand = new CharacterHeadCommand(_characterHeadMaterial, color.PickRandom());
                    characterColorChangeCommand.Execute();
                    
                    break;
                }

                case MenuOption.ANIMATION:
                {
                    var characterAnimationCommand = new CharacterAnimationCommand(_characterAnimator, 0);
                    characterAnimationCommand.Execute();
                    
                    break;
                }
                case MenuOption.HAT:
                {
                    var characterAnimationCommand = new CharacterAnimationCommand(_characterAnimator, 0);
                    characterAnimationCommand.Execute();
                    
                    break;
                }
                case MenuOption.GLASSES:
                {
                    var characterAnimationCommand = new CharacterAnimationCommand(_characterAnimator, 0);
                    characterAnimationCommand.Execute();
                    
                    break;
                }
            }
           
        }

        private void ResetColors()
        {
            _characterMaterial.color = Color.white;
            _characterHeadMaterial.color = Color.white;
            _backgroundMaterial.color = Color.black;
        }

        private void OnDestroy() => ResetColors();
    }
}
