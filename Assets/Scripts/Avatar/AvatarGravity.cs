using System;
using UnityEngine;

namespace Avatar
{
    [RequireComponent(typeof(Rigidbody))]
    public class AvatarGravity: MonoBehaviour
    {
        public AvatarOrbit Orbit;
        public Rigidbody Rigidbody => _rigidbody ?? (_rigidbody = GetComponent<Rigidbody>());
        
        private Rigidbody _rigidbody;

        [SerializeField] private float _rotationSpeed = 20F;


        private void FixedUpdate()
        {
            if (Orbit)
            {
                var gravityUp = Vector3.zero;

                gravityUp = (transform.position - Orbit.transform.position).normalized;

                var localUp = transform.up;

                var targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * transform.rotation;

                transform.up = Vector3.Lerp(transform.up, gravityUp, _rotationSpeed * Time.fixedDeltaTime);
                
                Rigidbody.AddForce(-gravityUp * (Orbit.Gravity * Rigidbody.mass));
            }
        }
    }
}