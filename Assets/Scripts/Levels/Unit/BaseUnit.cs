using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUnit : MonoBehaviour
{
    [Header("Unit")]
    public string unitName;
    public float maxHP;
    public float currentHP;
    public float damage;
    public float moveSpeed;
    public float range;
    public bool isFlying;
    public bool isStationary;
    [Space(5)]
    public Vector2Int occupiedTilesSize; //1x1 is a normal uinit it takes up one tile, bosses/elietes would take 2x2 or more
    public float spaceOccupied; //amount of tile space the unit takes
    [Space(5)]
    public AbilityBase basicAttack; // normal attack
    public AbilityBase specialAbility; // TODO might remove unsure


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
            unitName = unitData.UnitName;
            maxHP = unitData.MaxHP;
            currentHP = maxHP;
            damage = unitData.Damage;
            moveSpeed = unitData.MoveSpeed;
            range = unitData.Range;
            isFlying = unitData.IsFlying;
            isStationary = unitData.IsStationary;
            occupiedTilesSize = unitData.OccupiedTilesSize;
            spaceOccupied = unitData.SpaceOccupied;
            basicAttack = unitData.BasicAttack;
            specialAbility = unitData.SpecialAbility;
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
        currentHP -= amount;
        if (currentHP <= 0)
        {
            Die();
        }
    }

    //what happens when a unit dies
    protected virtual void Die()
    {
        Debug.Log($"{unitName} has been destroyed.");
        Destroy(gameObject);
    }

    //TODO could move by taking a direction and amount
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

    //attack a target
    public virtual void PerformBasicAttack(BaseUnit target)
    {
        if (basicAttack != null)
        {
            basicAttack.Execute(this, target);
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
        if (specialAbility != null)
        {
            specialAbility.Execute(this, target);
        }
    }
}