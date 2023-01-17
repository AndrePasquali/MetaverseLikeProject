using System;
using System.Collections.Generic;
using System.IO;
using Avatar.Equipment;
using Genies.Inventory;
using IO;
using Settings;
using Unity.VisualScripting;
using UnityEngine;

namespace GameServerFake
{
    public static class GameServer
    {
        public enum HTTP_METHOD
        {
            POST,
            GET,
            DELETE
        }

        public enum REQUEST_TYPE
        {
            INVENTORY,
        }
        
        public static List<Inventory> AvatarInventory;

        static GameServer() => Initialize();

        public static void Initialize()
        {
            AvatarInventory = new List<Inventory>();
            
            if (File.Exists(GameConstants.INVENTORY_FULLPATH))
            {
                try
                {
                    var json = Json<List<Inventory>>.Load(GameConstants.INVENTORY_FULLPATH);
                    
                    AvatarInventory.AddRange(json);
                }
                catch (Exception e)
                {
                    
                }
            }
            else
            {
                var mockInventory = new Inventory
                {
                    PlayerId = 0,
                    AvatarHat = Hat.DEFAULT,
                    AvatarGlasses = Glasses.DEFAULT,
                    BodyColor = Color.white.ToHexString(),
                    HeadColor = Color.white.ToHexString(),
                    BackgroundColor = Color.cyan.ToHexString()
                };
                
                AvatarInventory.Add(mockInventory);

                Json<List<Inventory>>.Save(AvatarInventory, GameConstants.INVENTORY_FULLPATH);
            }
        }

        public static void SendPacket(HTTP_METHOD method, REQUEST_TYPE requestType, object data, int userId)
        {
            switch (method)
            {
                case HTTP_METHOD.POST:
                {
                    if (requestType == REQUEST_TYPE.INVENTORY)
                    {
                        var newData = data as Inventory;

                        UpdateInventoryRequest(newData, userId);
                    }
                    break;
                }
                case HTTP_METHOD.DELETE:
                {
                    if (requestType == REQUEST_TYPE.INVENTORY)
                    {
                        
                    }
                    break;
                }
            }
        }

        private static void HandleRequest(HTTP_METHOD httpMethod, REQUEST_TYPE requestType, object data)
        {
           
        }

        private static void UpdateInventoryRequest(Inventory inventory, int userId)
        {
            if (AvatarInventory.Exists(e => e.PlayerId == userId))
            {
                AvatarInventory.RemoveAll(e => e.PlayerId == userId);
                AvatarInventory.Add(inventory);
                
                Json<List<Inventory>>.Save(AvatarInventory, GameConstants.INVENTORY_FULLPATH);
            }
        }
        public static List<Inventory> RequestInventory()
        {
            if (AvatarInventory != null && AvatarInventory.Count > 0)
            {
                return AvatarInventory;
            }
            return new List<Inventory>();
        }
    }
}