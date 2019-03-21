using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour {
    // <--comments out line
    /* <-- comments out everything between --> */

    /*
    In Case you didn't know Commented out text and code basically doesn't exist as far as unity and the game are concered
    */

    //Abstract class is what lets it be inherited. Abstract classes as I understand them are blueprints for the inheriting script to build off of. 
    [Tooltip("Place Spell Prefab Here")]// FYI to see tooltip in action hover over _projectile in unity inspector
    [SerializeField] protected /*Protected is like private but inheriting scripts can access it.*/ GameObject _projectile; 
    [SerializeField] protected int _spellSpeed;
    [SerializeField] protected int _spellDamage;







    // use _spellDamageType.{type} like _spellDamageType.Fire which really is just returning _spellDamageType[1] 
    //(this is because 0 is always first in array makin neutral [0])
    //
    // lets you use the actual name so you don't have to keep looking up which number equals which time
    protected enum _spellDamageType {
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

/* #TODO shit for future shit.
     private List<Projectile> _inFlightRounds = new List<Projectile>();

    public struct Projectile {
        public Vector3 StartPosition;
        public Vector3 Direction;
        public float DistanceRemaining;

    } */
}