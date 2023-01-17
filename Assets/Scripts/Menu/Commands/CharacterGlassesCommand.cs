using System.Collections.Generic;
using System.Linq;
using Avatar;
using Avatar.Equipment;

namespace Genies.Menu
{
    public class CharacterGlassesCommand
    {
        private Glasses _glasses;
        private List<AvatarItemGlasses> _itemsGlasses;
        public CharacterGlassesCommand(Glasses avatarGlasses, List<AvatarItemGlasses> itemsGlasses)
        {
            _glasses = avatarGlasses;
            _itemsGlasses = itemsGlasses;
        }
        public void Execute()
        {
            if (_glasses == Glasses.DEFAULT)
            {
                _itemsGlasses.ForEach(e => e.SetEquipped(false));
                return;
            }
            
            var itemToEquip = _itemsGlasses.FirstOrDefault(e => e.AvatarGlasses == _glasses);
            itemToEquip.SetEquipped(true);
            
            _itemsGlasses.ForEach(e =>
            {
                if(e.AvatarGlasses != _glasses)
                    e.SetEquipped(false);
            });
        }
    }
}