using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

[RequireComponent(typeof(Rigidbody))]

public class PlayerManager : MonoBehaviour
{

    [SerializeField] private Transform _spellBag;
    private GameObject[] _spells;

    void UpdateSpells()
    {
        int i = 0;
        foreach (Transform child in _spellBag)
        {
            _spells[i] = child.gameObject;
            Debug.Log(i);
            i++;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {


    }
}
