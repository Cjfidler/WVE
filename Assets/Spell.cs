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
    

  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(_projectile, transform.position, transform.rotation) as GameObject;
            bullet.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0, _spellSpeed));
        }
    }





/* #TODO shit for future shit.
     private List<Projectile> _inFlightRounds = new List<Projectile>();

    public struct Projectile {
        public Vector3 StartPosition;
        public Vector3 Direction;
        public float DistanceRemaining;

    } */
}