using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackBehavior
{
    void Attack(BaseUnit unit, List<BaseUnit> target, AbilityBase ability);
}
