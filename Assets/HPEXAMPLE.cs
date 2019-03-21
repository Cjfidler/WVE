using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPEXAMPLE : MonoBehaviour, ITakeDamage
{
    [SerializeField]private int maxHP;
    private int currentHP;

    private void Start()
    {
        currentHP = maxHP;
    }

   public void TakeDamage(int DamageType, int DamageTaken)
    {
        if(DamageType == 2)
        {
            DamageTaken = DamageTaken * 2;
        }

        currentHP = currentHP - DamageTaken;
    }

   public void WhenDead()
    {
        Debug.Log("It Died");
    }


}
