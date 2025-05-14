using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScenario : MonoBehaviour
{
    [SerializeField] private GameObject archerPrefab;
    [SerializeField] private GameObject skeletonPrefab;
    [SerializeField] private BasicArrow fireArrowAbility;

    private BaseUnit _archer;
    private BaseUnit _oilSkeleton;

    void Start()
    {
        Vector2Int archerTile = new Vector2Int(2, 2);
        Vector2Int skeletonTile = new Vector2Int(3, 2);

        _archer = Instantiate(archerPrefab).GetComponent<BaseUnit>();
        _oilSkeleton = Instantiate(skeletonPrefab).GetComponent<BaseUnit>();

        UnitPlacement.instance.PlaceUnit(_archer, archerTile);
        UnitPlacement.instance.PlaceUnit(_oilSkeleton, skeletonTile);

        _archer.BasicAttack = fireArrowAbility;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Archer shoots fire arrow!");
            _archer.PerformBasicAttack(_oilSkeleton); //testing shooting
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("Moving Oil Barrel Skeleton to (5, 5)");
            UnitPlacement.instance.MoveUnit(_oilSkeleton, new Vector2Int(5, 5)); //tsting move
        }
    }
}
