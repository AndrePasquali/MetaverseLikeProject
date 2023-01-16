using System.Collections.Generic;
using System.Linq;
using Avatar;
using Avatar.Equipment;

namespace Genies.Menu
{
    public class CharacterGlassesCommand
    {
        private Glasses _glasses;
        private List<AvatarItemGlasses> _itemsHat;
        public CharacterGlassesCommand(Glasses avatarHat, List<AvatarItemGlasses> itemsHat)
        {
            _glasses = avatarHat;
            _itemsHat = itemsHat;
        }
        public void Execute()
        {
            var itemToEquip = _itemsHat.FirstOrDefault(e => e.AvatarGlasses == _glasses);
            itemToEquip.SetEquipped(true);
            
            _itemsHat.ForEach(e =>
            {
                if(e.AvatarGlasses != _glasses)
                    e.SetEquipped(false);
            });
        }
        
    }
}