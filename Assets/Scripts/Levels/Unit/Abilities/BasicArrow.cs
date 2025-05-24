using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BasicArrow", menuName = "Abilities/Basic Arrow")]
public class BasicArrow : AbilityBase
{
    [SerializeField] private TileCondition conditonToApplyWithArrow;
    //variable to look at

    public override void Execute(BaseUnit a_source, List<BaseUnit> a_targets)
    {
        //nearest unit within range

        BaseUnit target = null;
        float shortestDistance = float.MaxValue;

        foreach (BaseUnit bu in a_targets)
        {
            if (bu == a_source) continue;
            float distance = Vector2Int.Distance(a_source.occupiedTilePosition, bu.occupiedTilePosition);

            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                target = bu;
            }
        }

        //deal damage

        Debug.Log($"{a_source.unitName} shoots an arrow at {target.unitName}");
        target.TakeDamage(damage);

        // set the tiles status effect

        GridTile targetCell = GridManager.instance.GetCell(new Vector2Int((int)target.transform.position.x, (int)target.transform.position.z));

        if (targetCell != null)
        {
            targetCell.AddCondition(conditonToApplyWithArrow); //arrow effect
            Debug.Log($"Tile at {targetCell.tileCoordinates} is now on fire!");
        }
    }

    public override void Execute(BaseUnit a_source, BaseUnit a_targets)
    {
        //deal damage

        Debug.Log($"{a_source.unitName} shoots an arrow at {a_targets.unitName}");
        a_targets.TakeDamage(damage);

        // set the tiles status effect

        GridTile targetCell = GridManager.instance.GetCell(new Vector2Int((int)a_targets.transform.position.x, (int)a_targets.transform.position.z));

        if (targetCell != null)
        {
            targetCell.AddCondition(conditonToApplyWithArrow); //arrow effect
            Debug.Log($"Tile at {targetCell.tileCoordinates} is now on fire!");
        }
    }
}