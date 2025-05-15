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
        _archer = archerObj.AddComponent<Archer>();  
        _archer.Initialize(archerData);

        // Instantiate the Skeleton unit
        GameObject skeletonObj = Instantiate(skeletonData.unitPrefab);
        _oilSkeleton = skeletonObj.AddComponent<OilBarrelSkeleton>(); 
        _oilSkeleton.Initialize(skeletonData);

        //place
        _archer.PlaceUnit(new Vector2Int(1, 1));
        _oilSkeleton.PlaceUnit(new Vector2Int(3, 3));
        archerObj.transform.position = new Vector3(_archer.occupiedTilePosition.x, 0, _archer.occupiedTilePosition.y);
        //GridManager.instance.PlaceUnit(_archer, new Vector2Int(1, 1));
        //GridManager.instance.PlaceUnit(_oilSkeleton, new Vector2Int(1, 1));

        //TODO
        //script that derives from baseunit should be attached to unitprefab
        //script should have a ref to its unit data
        //on awake initializes
        //creates its own prefab
        //places itself? this should be first , check if tile is empty, if it is placement can go ahead if not return card to hand // this part can be within card scripts?


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
            GridManager.instance.MoveUnit(_oilSkeleton, new Vector2Int(5, 5)); // Testing move
        }
    }
}
