using System.Collections.Generic;
using System.Linq;
using Avatar.Equipment;
using GameServerFake;
using Unity.VisualScripting;
using UnityEngine;

namespace Genies.Inventory
{
    public sealed class InventoryManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemToEquip"></param>
        /// <param name="playerId"></param>
        public void EquipItem(object itemToEquip, int playerId)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemToUnEquip"></param>
        /// <param name="playerId"></param>
        public void UnEquipItem(object itemToUnEquip, int playerId)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newHat"></param>
        /// <param name="playerId"></param>
        public void UpdateHat(Hat newHat, int playerId)
        {
            var inventory = GetInventory();

            var targetUserInventory = inventory.FirstOrDefault(e => e.PlayerId == playerId);

            targetUserInventory.AvatarHat = newHat;
            
            GameServer.SendPacket(GameServer.HTTP_METHOD.POST, GameServer.REQUEST_TYPE.INVENTORY, targetUserInventory, playerId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newGlasses"></param>
        /// <param name="playerId"></param>
        public void UpdateGlasses(Glasses newGlasses, int playerId)
        {
            var inventory = GetInventory();

            var targetUserInventory = inventory.FirstOrDefault(e => e.PlayerId == playerId);

            targetUserInventory.AvatarGlasses = newGlasses;
            
            GameServer.SendPacket(GameServer.HTTP_METHOD.POST, GameServer.REQUEST_TYPE.INVENTORY, targetUserInventory, playerId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newColor"></param>
        /// <param name="playerId"></param>
        public void UpdateBackground(Color newColor, int playerId)
        {
            var inventory = GetInventory();

            var targetUserInventory = inventory.FirstOrDefault(e => e.PlayerId == playerId);

            targetUserInventory.BackgroundColor = newColor.ToHexString();
            
            GameServer.SendPacket(GameServer.HTTP_METHOD.POST, GameServer.REQUEST_TYPE.INVENTORY, targetUserInventory, playerId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newColor"></param>
        /// <param name="playerId"></param>
        public void UpdateBody(Color newColor, int playerId)
        {
            var inventory = GetInventory();

            var targetUserInventory = inventory.FirstOrDefault(e => e.PlayerId == playerId);

            targetUserInventory.BodyColor = newColor.ToHexString();
            
            GameServer.SendPacket(GameServer.HTTP_METHOD.POST, GameServer.REQUEST_TYPE.INVENTORY, targetUserInventory, playerId);
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newColor"></param>
        /// <param name="playerId"></param>
        public void UpdateHead(Color newColor, int playerId)
        {
            var inventory = GetInventory();

            var targetUserInventory = inventory.FirstOrDefault(e => e.PlayerId == playerId);

            targetUserInventory.HeadColor = newColor.ToHexString();
            
            GameServer.SendPacket(GameServer.HTTP_METHOD.POST, GameServer.REQUEST_TYPE.INVENTORY, targetUserInventory, playerId);
        }

        /// <summary>
        /// Return the inventory with lastest state of the player
        /// </summary>
        /// <returns></returns>
        public List<Inventory> GetInventory()
        {
            var inventory = GameServer.RequestInventory();

            return inventory;
        }
    }
}