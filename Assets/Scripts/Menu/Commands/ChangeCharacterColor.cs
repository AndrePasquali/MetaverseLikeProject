using UnityEngine;

namespace Genies.Menu
{
    public class ChangeCharacterColor: IMenuCommand
    {
        private readonly Color _colorToChange;
        private Material _characterMaterial;

        public ChangeCharacterColor(Material characterMaterial, Color colorToChange)
        {
            _characterMaterial = characterMaterial;
            _colorToChange = colorToChange;
        }
        public void Execute()
        {
            _characterMaterial.color = _colorToChange;
        }
    }
}