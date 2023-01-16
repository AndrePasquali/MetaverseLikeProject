using Genies.Menu.Enums;

namespace Genies.Menu
{
    public class ChangeOptionCommand: IMenuCommand
    {
        private readonly MenuOption _option;

        public ChangeOptionCommand(MenuOption option)
        {
            _option = option;
        }
        
        public void Execute()
        {
            
        }
    }
}