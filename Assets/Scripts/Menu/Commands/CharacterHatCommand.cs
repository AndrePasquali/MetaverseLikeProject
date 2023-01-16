using System.Collections.Generic;
using System.Linq;
using Avatar;
using Avatar.Equipment;
using Genies.Menu.Enums;
using UnityEngine;

namespace Genies.Menu
{
    public class CharacterHatCommand: IMenuCommand
    {
        private Hat _hat;
        private List<AvatarItemHat> _itemsHat;
        public CharacterHatCommand(Hat avatarHat, List<AvatarItemHat> itemsHat)
        {
            _hat = avatarHat;
            _itemsHat = itemsHat;
        }
        public void Execute()
        {
            var itemToEquip = _itemsHat.FirstOrDefault(e => e.AvatarHat == _hat);
            itemToEquip.SetEquipped(true);
            
            _itemsHat.ForEach(e =>
            {
                if(e.AvatarHat != _hat)
                    e.SetEquipped(false);
            });
        }
    }
}