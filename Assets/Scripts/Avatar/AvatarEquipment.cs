using System;
using System.Collections.Generic;
using System.Linq;
using Avatar.Equipment;
using Genies.Inventory;
using UnityEngine;

namespace Avatar
{
    public class AvatarEquipment: MonoBehaviour
    {
        public InventoryManager _InventoryManager = new InventoryManager();
        public List<AvatarItemHat> AvatarHats;
        public List<AvatarItemGlasses> AvatarGlasses;
        public Material HeadColor;
        public Material BodyColor;

        public bool AI;

        private void Start()
        {
            if (!AI) RestoreEquipment();
        }

        private void RestoreEquipment()
        {
            var currentInventory = _InventoryManager.GetInventory().First(e => e.PlayerId == 0);
            
            EquipHat(currentInventory);
            EquipGlasses(currentInventory);
            EquipBody(currentInventory);
            EquipHead(currentInventory);
        }

        public void Setup(Inventory inventory)
        {
            EquipHat(inventory);
            EquipGlasses(inventory);
            EquipBody(inventory);
            EquipHead(inventory);
        }

        private void EquipHat(Inventory inventory)
        {
            try
            {
                var targetHat = inventory.AvatarHat;

                if (targetHat == Hat.DEFAULT)
                {
                    AvatarHats.ForEach(e => e.SetEquipped(false));
                    return;
                }
            
                AvatarHats.FirstOrDefault(e => e.AvatarHat == inventory.AvatarHat).SetEquipped(true);
            
                AvatarHats.ForEach(e =>
                {
                    if(e.AvatarHat != targetHat)
                        e.SetEquipped(false);
                });
            }
            catch (Exception e)
            {
               
            }
           
        }

        private void EquipGlasses(Inventory inventory)
        {
            try
            {
                var targetGlasses = inventory.AvatarGlasses;
                
                if (targetGlasses == Glasses.DEFAULT)
                {
                    AvatarGlasses.ForEach(e => e.SetEquipped(false));
                    return;
                }

                AvatarGlasses.FirstOrDefault(e => e.AvatarGlasses == inventory.AvatarGlasses).SetEquipped(true);
            
                AvatarGlasses.ForEach(e =>
                {
                    if(e.AvatarGlasses != targetGlasses)
                        e.SetEquipped(false);
                });
            }
            catch (Exception e)
            {
               
            }
           
        }

        private void EquipBody(Inventory inventory)
        {
            var targetColor = string.Format($"#{inventory.BodyColor}");

            if (ColorUtility.TryParseHtmlString(targetColor, out Color color))
                BodyColor.color = color;
        }
        
        private void EquipHead(Inventory inventory)
        {
            var targetColor = string.Format($"#{inventory.HeadColor}");

            if (ColorUtility.TryParseHtmlString(targetColor, out Color color))
                HeadColor.color = color;
        }

        private void ResetColors()
        {
            HeadColor.color = Color.white;
            BodyColor.color = Color.white;
        }

        private void OnDestroy() => ResetColors();
    }
}