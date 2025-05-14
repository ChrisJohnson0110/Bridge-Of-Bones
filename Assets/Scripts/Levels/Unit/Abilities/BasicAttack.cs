using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Basic Attack", menuName = "Abilities/Basic Attack")]
public class BasicAttack : AbilityBase
{
    public override void Execute(BaseUnit source, BaseUnit target)
    {
        Debug.Log($"{source.UnitName} attacks {target.UnitName} for {Damage} damage.");
        target.TakeDamage(Damage);
    }
}
