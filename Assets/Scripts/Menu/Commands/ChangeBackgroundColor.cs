using UnityEngine;

namespace Genies.Menu
{
    public class ChangeBackgroundColor: IMenuCommand
    {
        private readonly Color _colorToChange;

        public ChangeBackgroundColor(Color colorToChange) => _colorToChange = colorToChange;
        
        public void Execute() => Camera.main.backgroundColor = _colorToChange;
        
    }
}