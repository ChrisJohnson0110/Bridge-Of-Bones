using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//base class for ability stats
public abstract class AbilityBase : ScriptableObject
{
    public string AbilityName;
    public float Range;
    public float Damage;
    public float Speed;

    public abstract void Execute(BaseUnit source, BaseUnit target);
}
