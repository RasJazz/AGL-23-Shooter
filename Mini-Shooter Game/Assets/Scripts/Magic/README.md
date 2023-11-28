# Spells
### Creating Spells
Spells are stored in their individual directories in `SpellTypes`

i.e. `Fireball/` or `Dash/`

In that folder is the main spell class, which must extend `Spell`, 
and registers itself as a ScriptableObject in the asset menu for easier creation.

i.e.
```csharp
[CreateAssetMenu(fileName = "New Dash", menuName = "Dash")]
public class DashSpell : Spell {
    // Spell Code
}
```

Then, it defines any extra properties it needs,
```csharp
[Header("Dash")] 
public float power;
public float moveThreshold;
```

and overrides the `cast` method with whatever the spell does
```csharp
public override void Cast(SpellCaster spellCaster)
{
    Vector3 velocity = spellCaster.casterRigidbody.velocity;
    if (velocity.magnitude >= moveThreshold)
    {
        base.Cast(spellCaster);
        Vector3 moveDirection = velocity.normalized;
        spellCaster.casterRigidbody.transform.Translate(moveDirection * power);
    }

}
```

If the spell has a projectile, create a new game object with a component for the projectile.

see `FireballSpell.cs` and `FireballProjectile.cs`

---
### Spell Levels / Presets
Different presets for spells are stored in the `Levels/` directory in the spell's base directory

i.e. `SpellTypes/Dash/Levels/`

To create a preset for a spell:
1. Right click inside the `Levels/` directory in the Unity Asset Browser.
2. Go to `Create`, and pick the spell type you want a new preset for.
3. Rename the new preset, i.e. `Fireball 3`
4. Configure the properties how you want them
