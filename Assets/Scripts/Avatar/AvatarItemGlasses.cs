using Avatar.Equipment;
using UnityEngine;

namespace Avatar
{
    public class AvatarItemGlasses: MonoBehaviour
    {
        public Glasses AvatarGlasses;
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