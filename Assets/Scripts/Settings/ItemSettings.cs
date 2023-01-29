using System;
using Avatar.Equipment;
using UnityEngine;

namespace Settings
{
    [Serializable]
    [CreateAssetMenu(menuName = "Settings/CreateItemSettings", fileName = "ItemSettings", order = 0)]
    public class ItemSettings: ScriptableObject
    {
        public Glasses[] Glasses;
        
        public Hat[] Hats;
        
        public Color[] BackgroundColors;
        
        public Color[] BodyColors;
        
        public Color[] HeadColors;
        
        public string[] Animations;
    }
}