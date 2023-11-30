using System;
using UnityEngine;

namespace Magic.SpellTypes.Fireball
{
    [RequireComponent(typeof(Rigidbody))]
    public class FireballProjectile : MonoBehaviour
    {

        private float _timeAlive;
        public FireballSpell FireballSpell { private get; set; }

        private void Start()
        {
            GameObject projectile = gameObject;
            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
            projectileRb.useGravity = false;
            projectileRb.velocity = Vector3.zero;
            projectileRb.AddRelativeForce(Vector3.forward * FireballSpell.speed * 10, ForceMode.VelocityChange);
        }

        // Update is called once per frame
        void Update()
        {
            _timeAlive += Time.deltaTime;
            if (_timeAlive >= 5)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "PlayerObj") return; // TODO: change from using object name
            
            Destroy(gameObject);
        }
    }
}
