using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public struct SpellKeybind
{

    public KeyCode keyCode;
    public Spell spell;

}