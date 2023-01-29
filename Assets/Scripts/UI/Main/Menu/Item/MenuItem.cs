using UnityEngine;
using static Genies.Menu.Enums.MenuOption;
using MenuOption = Genies.Menu.Enums;

namespace Genies.UI.Main
{
    public sealed class MenuItem: MonoBehaviour
    {
        private void Setup(Menu.Enums.MenuOption option)
        {
            switch (option)
            {
                case HAT: break;
                case BODY: break;
                case BACKGROUND: break;
                case GLASSES: break;
                case ANIMATION: break;
                case HEAD: break;
            }
        }
    }
}