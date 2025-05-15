using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUnit : MonoBehaviour
{
    //TODO need to check within ability if unit should be only attacking within its lane // need to add that to the baseunit SO

    [Header("Unit")]
    public string unitName;
    public float maxHP;
    public float currentHP;
    public float damage;
    public float moveSpeed;
    public int range;
    public bool isFlying;
    public bool isStationary; //should probably remove
    [Space(5)]
    public Vector2Int occupiedTilesSize; //1x1 is a normal uinit it takes up one tile, bosses/elietes would take 2x2 or more
    public float spaceOccupied; //amount of tile space the unit takes
    public Vector2Int occupiedTilePosition; //units positon  /TODO ensure getting used
    [Space(5)]
    public AbilityBase basicAttack; // normal attack

    private  GameObject unitPrefab; // unit prefab

    protected Animator animator;

    //initialize unit data
    public void Initialize(UnitData a_unitData)
    {
        UnitData unitData = a_unitData;

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

    //place this unit on the grid
    public void PlaceUnit(Vector2Int a_targetTile)
    {
        if (occupiedTilePosition != null) //return if already has a tile pos
        {
            return;
        }

        GridTile cell = GridManager.instance.GetCell(a_targetTile);

        if (cell == null)
        {
            Debug.LogWarning("Invalid tile position.");
            return;
        }

        if (cell.IsPassableFor(this))
        {
            cell.AddUnit(this);
            this.transform.position = cell.worldPos;
            this.occupiedTilePosition = a_targetTile;
        }
        else
        {
            Debug.LogWarning("Tile is not passable for " + this.unitName);
        }
    }

    //move unit
    public void Move(Vector2Int targetTile)
    {
        // Example move logic
        Debug.Log($"{gameObject.name} is moving to {targetTile}");
        animator.SetBool("isRunning", true);

        OnMove(targetTile);

        // Simulate a move (you would implement actual movement logic here)
        StartCoroutine(MoveToPosition(targetTile));
    }

    //check when moving 
    protected virtual void OnMove(Vector2Int newTile)
    {
    }

    private System.Collections.IEnumerator MoveToPosition(Vector2Int targetTile)
    {
        Vector3 targetPosition = new Vector3(targetTile.x, 0, targetTile.y);

        float speed = 2f;
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }

        animator.SetBool("isRunning", false);
        occupiedTilePosition = targetTile;
    }

    //attack target/s //multiple targets
    public virtual void PerformBasicAttack(List<BaseUnit> target)
    {
        if (basicAttack != null)
        {
            basicAttack.Execute(this, target);
            animator.SetBool("isAttacking", true);
            Invoke(nameof(ResetAttack), 1f); //attack animation cooldown
        }
    }

    //attack target //single target
    public virtual void PerformBasicAttack(BaseUnit target)
    {
        if (basicAttack != null)
        {
            basicAttack.Execute(this, target);
            animator.SetBool("isAttacking", true);
            Invoke(nameof(ResetAttack), 1f); //attack animation cooldown
        }
    }

    //check when attacking
    protected virtual void OnAttack()
    {
    }

    private void ResetAttack()
    {
        animator.SetBool("isAttacking", false);
    }
}