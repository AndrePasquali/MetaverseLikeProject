using System.Collections.Generic;
using System.Linq;
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
        [SerializeField] private List<MenuOptionButton> _menuOptionButtons;


        private void Start() => Initialize();

        private void Initialize()
        {
            MenuOptionButton.OnOptionButtonClick += OnMenuButtonAction;
            MenuItemButton.OnItemButtonClick += OnItemButtonAction;
        }

        private void OnMenuButtonAction(MenuOption actionType, GameObject optionPanel)
        { 
            var optionCommand = new ChangeOptionCommand(actionType, _menuOptionButtons); 
            optionCommand.Execute();
        }

        private void OnItemButtonAction(MenuOption actionType, MenuItemButton item)
        {
            switch (actionType)
            {
                case MenuOption.BACKGROUND:
                {
                    var color = item.GetColor();
                    var backgroundColorCommand = new ChangeBackgroundCommand(_backgroundMaterial, color);

                    backgroundColorCommand.Execute();
                    
                    break;
                }

                case MenuOption.BODY:
                {
                    var color = item.GetColor();
                    
                    var characterColorChangeCommand = new CharacterBodyCommand(_characterMaterial, color);
                    characterColorChangeCommand.Execute();
                    break;
                }
                
                case MenuOption.HEAD:
                {
                    var color = item.GetColor();
                    
                    var characterColorChangeCommand = new CharacterHeadCommand(_characterHeadMaterial, color);
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
