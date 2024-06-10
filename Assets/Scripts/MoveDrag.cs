using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDrag : MovementControl
{
    [SerializeField] int dragAmount;
    protected override void Moving()
    {
        base.Moving();

        playerRB.drag = dragAmount;
    }
}
