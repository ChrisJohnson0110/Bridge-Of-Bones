using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//base class for ability stats
public abstract class AbilityBase : ScriptableObject
{
    public string abilityName;
    public float range;
    public float damage;
    public float speed;

    public abstract void Execute(BaseUnit source, List<BaseUnit> target);
    public abstract void Execute(BaseUnit source, BaseUnit target);
}
