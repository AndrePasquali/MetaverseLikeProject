using UnityEngine;

namespace Genies.Menu
{
    public class ChangeCharacterHead: IMenuCommand
    {
        private readonly Color _colorToChange;
        private Material _characterHeadMaterial;

        public ChangeCharacterHead(Material characterHeadMaterial, Color colorToChange)
        {
            _characterHeadMaterial = characterHeadMaterial;
            _colorToChange = colorToChange;
        }
        public void Execute()
        {
            _characterHeadMaterial.color = _colorToChange;
        }
    }
}