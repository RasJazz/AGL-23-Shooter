using System;
using System.Collections.Generic;
using UnityEngine;

namespace Magic
{
    public abstract class Spell : ScriptableObject
    {
    
        [Header("Spell Info")]
        public string spellName;
        public Sprite icon;
        [Header("Cooldown")]
        public float cooldownSecs;

        private readonly Dictionary<SpellCaster, float> _allCooldownSecsRemaining = new();

        public virtual void Cast(SpellCaster spellCaster)
        {
            if (!IsReady(spellCaster))
            {
                throw new SpellOnCooldownException(spellCaster, this);
            }
            TriggerCooldown(spellCaster);
        }

        public void TriggerCooldown(SpellCaster spellCaster)
        {
            _allCooldownSecsRemaining[spellCaster] = cooldownSecs;
        }

        public bool IsReady(SpellCaster spellCaster)
        {
            return _allCooldownSecsRemaining.GetValueOrDefault(spellCaster, 0) == 0;
        }

        public float CooldownSecsRemaining(SpellCaster spellCaster)
        {
            return _allCooldownSecsRemaining.GetValueOrDefault(spellCaster, 0);
        }
        
        public float CooldownPercentRemaining(SpellCaster spellCaster)
        {
            return _allCooldownSecsRemaining.GetValueOrDefault(spellCaster, 0) / cooldownSecs;
        }

        public void UpdateCooldown(SpellCaster spellCaster)
        {
            if (IsReady(spellCaster)) 
                return;

            float time = Time.deltaTime;
            _allCooldownSecsRemaining[spellCaster] = Math.Max(0, _allCooldownSecsRemaining.GetValueOrDefault(spellCaster, 0) - time);
        }

    }
}