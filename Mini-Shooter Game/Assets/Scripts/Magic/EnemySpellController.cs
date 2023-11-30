using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Magic
{
    [RequireComponent(typeof(SpellCaster))]
    public class EnemySpellController : MonoBehaviour
    {
        public SpellChance[] spells;
        private SpellCaster _spellCaster;

        private void Start()
        {
            _spellCaster = gameObject.GetComponent<SpellCaster>();
        }

        private void Update()
        {
            float totalWeights = spells.Aggregate(0.0f, (acc, current) => acc + current.weight);
            float randomWeight = Random.Range(0.0f, totalWeights);
            foreach (SpellChance spellChance in spells)
            {
                float weight = spellChance.weight;
                Spell spell = spellChance.spell;
                spell.UpdateCooldown();
                if (randomWeight > weight) continue;
                
                try
                {
                    spell.Cast(_spellCaster);
                }
                catch (SpellOnCooldownException e)
                {
                    // handle if on cooldown
                }
                return;
            }
        }
    }
}