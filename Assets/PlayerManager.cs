using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Rigidbody))]

public class PlayerManager : MonoBehaviour
{

    [SerializeField] private GameObject _spellBag;
    private GameObject[] _spells;


  /* 
   * ignore this for now something I am doing for something else
   * Transform[] children = new Transform[transform.childCount];
 for (int i=0; i<transform.childCount; i++) {
     children[i]=transform.GetChild(i);
 } */


// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
