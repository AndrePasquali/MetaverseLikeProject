using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Genies.Menu
{
    public class MenuCommandController : MonoBehaviour
    {
        private Queue<IMenuCommand> _menuCommands;
        private IMenuCommand _currentCommand;

        [SerializeField] private Material _characterMaterial;

        private void Start() => MenuButton.OnAnyButtonClick += OnButtonAction;

        private void OnButtonAction(MenuButton.ActionType actionType)
        {
            switch (actionType)
            {
                case MenuButton.ActionType.BackgroundColor:
                {
                    var pickedColor  = new Color(
                        Random.Range(0f, 1f), 
                        Random.Range(0f, 1f), 
                        Random.Range(0f, 1f)
                    );

                    var backgroundColorCommand = new ChangeBackgroundColor(pickedColor);
            
                    backgroundColorCommand.Execute();
                    break;
                }

                case MenuButton.ActionType.CharacterColor:
                {
                    var pickedColor  = new Color(
                        Random.Range(0f, 1f), 
                        Random.Range(0f, 1f), 
                        Random.Range(0f, 1f)
                    );

                    var characterColorChangeCommand = new ChangeCharacterColor(_characterMaterial, pickedColor);
                    characterColorChangeCommand.Execute();
                    break;
                }
            }
           
        }
    }
}
