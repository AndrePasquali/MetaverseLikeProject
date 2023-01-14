using UnityEngine;

namespace Genies.Menu
{
    public class ChangeBackgroundColor: IMenuCommand
    {
        private readonly Color _colorToChange;
        private readonly Material _backgroundMaterial;

        public ChangeBackgroundColor(Material backgroundMaterial, Color colorToChange)
        {
            _backgroundMaterial = backgroundMaterial;
            _colorToChange = colorToChange;
        }

        public void Execute() => _backgroundMaterial.color = _colorToChange;
    }
}