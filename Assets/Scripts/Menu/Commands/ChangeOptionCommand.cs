using System.Collections.Generic;
using System.Linq;
using Genies.Menu.Enums;

namespace Genies.Menu
{
    public class ChangeOptionCommand: IMenuCommand
    {
        private readonly MenuOption _option;

        private List<MenuOptionButton> _menuOptions;

        public ChangeOptionCommand(MenuOption option, List<MenuOptionButton> menuOptionButtons)
        {
            _option = option;
            _menuOptions = menuOptionButtons;
        }
        
        public void Execute()
        {
            var optionItem = _menuOptions.FirstOrDefault(e => e.GetOption() == _option);
            optionItem.SetEnabled(true);

            _menuOptions.ForEach(e =>
            {
                if(e.GetOption() != _option)
                    e.SetEnabled(false);
            });
        }
    }
}