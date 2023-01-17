using System;
using Avatar.Equipment;
using UnityEngine;

namespace Genies.Inventory
{
    [Serializable]
    public class Inventory
    {
        public int PlayerId { get; set; }
        public Hat AvatarHat { get; set; }
        public Glasses AvatarGlasses { get; set; }
        public string HeadColor { get; set; }
        public string BodyColor { get; set; }
        public string BackgroundColor { get; set; }
    }
}