using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BasicArrow", menuName = "Abilities/Basic Arrow")]
public class BasicArrow : AbilityBase
{
    [SerializeField] private TileCondition conditonToApplyWithArrow;

    private void Awake()
    {
        AbilityName = "Baisc Arrow";
        Range = 5f;
        Damage = 10;
    }

    public override void Execute(BaseUnit source, BaseUnit target)
    {
        //deal damage

        Debug.Log($"{source.UnitName} shoots an arrow at {target.UnitName}");
        target.TakeDamage(Damage);

        // set the tiles status effect

        GridTile targetCell = GridManager.instance.GetCell(new Vector2Int((int)target.transform.position.x, (int)target.transform.position.z));

        if (targetCell != null)
        {
            targetCell.AddCondition(conditonToApplyWithArrow); //arrow effect
            Debug.Log($"Tile at {targetCell.tileCoordinates} is now on fire!");
        }
    }
}