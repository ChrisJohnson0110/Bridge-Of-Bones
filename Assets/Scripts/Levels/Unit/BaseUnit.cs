using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUnit : MonoBehaviour
{
    [Header("Unit")]
    public string UnitName;
    public float MaxHP;
    public float CurrentHP;
    public float Damage;
    public float MoveSpeed;
    public float Range;
    public bool IsFlying;
    public bool IsStationary;
    [Space(5)]
    public Vector2Int OccupiedTilesSize;
    public float SpaceOccupied; //amount of tile space the unit takes
    [Space(5)]
    public AbilityBase BasicAttack; // normal attack
    public AbilityBase SpecialAbility; // TODO might remove unsure


    private UnitData unitData; // unit data
    private  GameObject unitPrefab; // unit prefab

    protected Animator animator;

    //initialize unit data
    public void Initialize(UnitData a_unitData)
    {
        unitData = a_unitData;

        if (unitData != null)
        {
            // Initialize the unit's attributes from UnitData
            UnitName = unitData.UnitName;
            MaxHP = unitData.MaxHP;
            CurrentHP = MaxHP;
            Damage = unitData.Damage;
            MoveSpeed = unitData.MoveSpeed;
            Range = unitData.Range;
            IsFlying = unitData.IsFlying;
            IsStationary = unitData.IsStationary;
            OccupiedTilesSize = unitData.OccupiedTilesSize;
            SpaceOccupied = unitData.SpaceOccupied;
            BasicAttack = unitData.BasicAttack;
            SpecialAbility = unitData.SpecialAbility;
            unitPrefab = unitData.unitPrefab;

            // Check for an Animator component in the unitPrefab
            if (unitPrefab != null && unitPrefab.TryGetComponent<Animator>(out Animator _animator))
            {
                animator = _animator;
            }
            else
            {
                Debug.LogWarning($"{unitData.UnitName} does not have an Animator component.");
            }
        }
        else
        {
            Debug.LogError("UnitData is not assigned in BaseUnit!");
        }
    }

    //when unit takes damage
    public virtual void TakeDamage(float amount)
    {
        CurrentHP -= amount;
        if (CurrentHP <= 0)
        {
            Die();
        }
    }

    //what happens when a unit dies
    protected virtual void Die()
    {
        Debug.Log($"{UnitName} has been destroyed.");
        Destroy(gameObject);
    }

    //move unit
    public void Move(Vector2Int targetTile)
    {
        // Example move logic
        Debug.Log($"{gameObject.name} is moving to {targetTile}");
        animator.SetBool("isRunning", true);

        // Simulate a move (you would implement actual movement logic here)
        StartCoroutine(MoveToPosition(new Vector3(targetTile.x, 0, targetTile.y)));
    }

    private System.Collections.IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        float speed = 2f;
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }

        animator.SetBool("isRunning", false);
    }

    public virtual void PerformBasicAttack(BaseUnit target)
    {
        if (BasicAttack != null)
        {
            BasicAttack.Execute(this, target);
            animator.SetBool("isAttacking", true);
            Invoke(nameof(ResetAttack), 1f); //attack cooldown
        }
    }

    private void ResetAttack()
    {
        animator.SetBool("isAttacking", false);
    }

    public virtual void PerformSpecialAbility(BaseUnit target)
    {
        if (SpecialAbility != null)
        {
            SpecialAbility.Execute(this, target);
        }
    }
}