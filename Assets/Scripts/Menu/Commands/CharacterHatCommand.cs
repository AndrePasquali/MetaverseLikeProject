using Genies.Menu.Enums;
using UnityEngine;

namespace Genies.Menu
{
    public class CharacterHatCommand: IMenuCommand
    {
        private MenuOptionButton _menuOption;

        public CharacterHatCommand(MenuOptionButton optionButton)
        {
            _menuOption = optionButton;
        }
        public void Execute()
        {
            _menuOption.SetEnabled(true);
        }
    }
}