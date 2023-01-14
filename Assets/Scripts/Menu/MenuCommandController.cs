using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Genies.Menu
{
    public class MenuCommandController : MonoBehaviour
    {
        private Queue<IMenuCommand> _menuCommands;

        private void Start() => MenuButton.OnAnyButtonClick += OnBackgroundColorAction;

        private void OnBackgroundColorAction()
        {
            var pickedColor  = new Color(
                Random.Range(0f, 1f), 
                Random.Range(0f, 1f), 
                Random.Range(0f, 1f)
            );

            var backgroundColorCommand = new ChangeBackgroundColor(pickedColor);
            
            backgroundColorCommand.Execute();
        }
    }
}
