using System;
using System.Linq;
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
        private void Update()
        {
            _timeAlive += Time.deltaTime;
            if (_timeAlive >= 5)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (FireballSpell.ignoreTags.Any(other.CompareTag))
            {
                return;
            }
            
            if (other.TryGetComponent(out Melee melee))
            {
                // Hit a melee enemy
                melee.health -= FireballSpell.damage;
            }
            else if (other.TryGetComponent(out Caster caster))
            {
                // Hit a caster enemy
                caster.health -= FireballSpell.damage;
            }
            else if (other.TryGetComponent(out PlayerMovement playerMovement)) // or whatever other component we use for player health
            {
                // Hit a player
                
            }
            

            Destroy(gameObject);
        }
    }
}
