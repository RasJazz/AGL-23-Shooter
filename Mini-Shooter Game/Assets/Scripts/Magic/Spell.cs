using System;
using UnityEngine;

namespace Magic
{
    public abstract class Spell : ScriptableObject
    {
    
        [Header("Spell Info")]
        public string spellName;
        public Texture2D icon;
        [Header("Cooldown")]
        public float cooldownSecs;
        public float CooldownSecsRemaining { get; private set; }

        public virtual void Cast(SpellCaster spellCaster)
        {
            if (!IsReady())
            {
                throw new SpellOnCooldownException(this);
            }
            TriggerCooldown();
        }

        public void TriggerCooldown()
        {
            CooldownSecsRemaining = cooldownSecs;
        }

        public bool IsReady()
        {
            return CooldownSecsRemaining == 0;
        }

        public float CooldownPercentRemaining()
        {
            return CooldownSecsRemaining / cooldownSecs;
        }
    
        public void UpdateCooldown()
        {
            float time = Time.deltaTime;
            CooldownSecsRemaining = Math.Max(0, CooldownSecsRemaining - time);
        }
    
    }
}