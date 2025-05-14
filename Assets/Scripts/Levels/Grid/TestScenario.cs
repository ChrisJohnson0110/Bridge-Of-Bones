using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScenario : MonoBehaviour
{
    [SerializeField] private UnitData archerData;
    [SerializeField] private UnitData skeletonData;

    private BaseUnit _archer;
    private BaseUnit _oilSkeleton;

    void Start()
    {
        // Instantiate the Archer unit
        GameObject archerObj = Instantiate(archerData.unitPrefab);
        _archer = archerObj.AddComponent<Archer>();  // Replace with your specific unit class
        _archer.Initialize(archerData);

        // Instantiate the Skeleton unit
        GameObject skeletonObj = Instantiate(skeletonData.unitPrefab);
        _oilSkeleton = skeletonObj.AddComponent<OilBarrelSkeleton>();  // Replace with your specific unit class
        _oilSkeleton.Initialize(skeletonData);

        //place
        UnitPlacement.instance.PlaceUnit(_archer, new Vector2Int(1,1));
        UnitPlacement.instance.PlaceUnit(_oilSkeleton, new Vector2Int(1, 1));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Archer shoots fire arrow!");
            _archer.PerformBasicAttack(_oilSkeleton); // Testing shooting
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("Moving Oil Barrel Skeleton to (5, 5)");
            UnitPlacement.instance.MoveUnit(_oilSkeleton, new Vector2Int(5, 5)); // Testing move
            //_oilSkeleton.Move();
        }
    }
}
