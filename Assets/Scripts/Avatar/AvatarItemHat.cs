using Avatar.Equipment;
using UnityEngine;

namespace Avatar
{
    public class AvatarItemHat: MonoBehaviour
    {
        public Hat AvatarHat;

        public bool Equipped
        {
            get => _equipped;
            private set
            {
                gameObject.SetActive(value);
                _equipped = value;
            }
        }
        private bool _equipped;

        public void SetEquipped(bool equipped) => Equipped = equipped;
    }
}