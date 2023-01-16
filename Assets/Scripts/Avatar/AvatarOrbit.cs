using System;
using Avatar;
using UnityEngine;

public class AvatarOrbit : MonoBehaviour
{
   public float Gravity = -10F;

   [SerializeField] private bool _fixedDirection;

   private void OnTriggerEnter(Collider other)
   {
      if (other.GetComponent<AvatarGravity>())
      {
         other.GetComponent<AvatarGravity>().Orbit = this;
      }
   }
}
