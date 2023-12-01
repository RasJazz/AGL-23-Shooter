using System;

namespace Magic
{
    public class SpellOnCooldownException : Exception
    {
        public SpellOnCooldownException(SpellCaster spellCaster, Spell spell) :
            base(String.Format("Spell {0} is on cooldown! {1:F} seconds remaining.", spell.spellName, spell.CooldownSecsRemaining(spellCaster)))
        {
        }
    }
}