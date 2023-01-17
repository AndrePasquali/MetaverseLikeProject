using System.IO;
using UnityEngine;

namespace Settings
{
    public sealed class GameConstants
    {
        public static string DATA_PATH = Application.persistentDataPath;
        
        public const string INVENTORY_FILENAME = "Inventory.json";
        
        public static string INVENTORY_FULLPATH = Path.Combine(DATA_PATH, INVENTORY_FILENAME);
    }
}