using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveBehavior
{
    void Move(BaseUnit unit, Vector2Int targetTile);
}
