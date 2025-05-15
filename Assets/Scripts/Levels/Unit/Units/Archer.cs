using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : BaseUnit
{
    protected override void OnAttack()
    {
        ShootArrow();
    }

    public void ShootArrow()
    {
        Debug.Log($"{gameObject.name} is shooting a fire arrow");
        animator.SetTrigger("FireArrow");

        // Implement actual fire arrow logic
    }
    
}