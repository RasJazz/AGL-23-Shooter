using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Magic
{
    [RequireComponent(typeof(SpellCaster))]
    public class PlayerSpellController : MonoBehaviour
    {
        public SpellKeybind[] spells;
        private SpellCaster _spellCaster;

        private void Start()
        {
            _spellCaster = gameObject.GetComponent<SpellCaster>();
        }

        private void Update()
        {
            foreach (SpellKeybind spellKeybind in spells)
            {
                KeyCode keyCode = spellKeybind.keyCode;
                Spell spell = spellKeybind.spell;
                spell.UpdateCooldown(_spellCaster);
                if (Input.GetKey(keyCode))
                {
                    try
                    {
                        spell.Cast(_spellCaster);
                    }
                    catch (SpellOnCooldownException e)
                    {
                        // handle if on cooldown
                    }

                }
            }
        }
    }
}