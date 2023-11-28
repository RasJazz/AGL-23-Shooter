using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpellCaster : MonoBehaviour
{

    public SpellKeybind[] spells;

    public Transform spellOrigin;
    public Transform aimOrientation;
    public Rigidbody casterRigidbody;

    private void Update()
    {
        foreach (SpellKeybind spellKeybind in spells)
        {
            KeyCode keyCode = spellKeybind.keyCode;
            Spell spell = spellKeybind.spell;
            spell.UpdateCooldown();
            if (Input.GetKey(keyCode) && spell.IsReady())
            {
                try
                {
                    spell.Cast(this);
                }
                catch (SpellOnCooldownException e)
                {
                    Debug.Log(e.Message);
                }

            }
        }
    }
}