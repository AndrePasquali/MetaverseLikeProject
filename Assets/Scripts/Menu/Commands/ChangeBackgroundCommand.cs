using UnityEngine;

namespace Genies.Menu
{
    public class ChangeBackgroundCommand: IMenuCommand
    {
        private readonly Color _colorToChange;
        private readonly Material _backgroundMaterial;

        public ChangeBackgroundCommand(Material backgroundMaterial, Color colorToChange)
        {
            _backgroundMaterial = backgroundMaterial;
            _colorToChange = colorToChange;
        }

        public void Execute()
        {
            _backgroundMaterial.SetColor("_EmissionColor", _colorToChange);
            _backgroundMaterial.color = _colorToChange;
        }
    }
}