/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DAMAGEEXAMPLE : Spell
{
    [SerializeField] private GameObject _start;

    private void Start()
    {
        _spellDamage = 5;
    }

    private void Spellshoot()
    {
        RaycastHit hit;
        bool isHit = Physics.Raycast(_start.transform.position, _start.transform.forward, out hit);
        Debug.DrawLine(transform.position, _start.transform.forward, Color.white, 50f);
  
            if (isHit)
        {

            ITakeDamage testInterface = Collision.gameObject.GetComponent<ITakeDamage>();

            if (testInterface != null)
            {
                testInterface.TakeDamage(1, _spellDamage);
            }
        }

    }


}