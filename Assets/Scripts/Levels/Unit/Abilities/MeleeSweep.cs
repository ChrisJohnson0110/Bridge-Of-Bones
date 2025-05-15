using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Basic Attack", menuName = "Abilities/Basic Attack")]
public class MeleeSweep : AbilityBase
{
    public override void Execute(BaseUnit a_source, List<BaseUnit> a_targets)
    {
        Debug.Log($"{a_source.unitName} attacks {a_targets.ToString()} for {damage} damage.");
        foreach (BaseUnit target in a_targets)
        {
            target.TakeDamage(damage);
        }
    }

    public override void Execute(BaseUnit source, BaseUnit target)
    {
        Debug.Log($"{source.unitName} attacks {target.unitName} for {damage} damage.");
        target.TakeDamage(damage);
    }
}
