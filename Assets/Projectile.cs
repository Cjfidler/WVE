using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected int _spellDamage;
    [SerializeField] protected float _spellLifeSpan;


    // use (int)_spellDamageType.{type} like (int)_spellDamageType.Fire which really is just returning [1] 
    //(this is because 0 is always first in array makin neutral [0])
    //
    // lets you use the actual name so you don't have to keep looking up which number equals which time
    protected enum _spellDamageType
    {
        Neutral,
        Fire,
        Ice,
        Wind,
        Electric,
        Earth,
        Water,
        Light,
        Dark
    }



    private void OnTriggerEnter(Collider collision)
    {
        ITakeDamage testInterface = collision.gameObject.GetComponent<ITakeDamage>();
        if (testInterface != null)
        {
            DoYourThing(testInterface);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public abstract void DoYourThing(ITakeDamage testInterface);
}
