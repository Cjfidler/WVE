using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Projectile
{
    private void Start()
    {
        Destroy(gameObject, _spellLifeSpan);
    }

    public override void DoYourThing(ITakeDamage testInterface)
    {
        testInterface.TakeDamage((int)_spellDamageType.Fire, _spellDamage);
        Destroy(gameObject);

    }




}
