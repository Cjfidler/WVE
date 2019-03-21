using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITakeDamage
{

    void TakeDamage(int DamageType, int DamageTaken);

    void WhenDead();

}
