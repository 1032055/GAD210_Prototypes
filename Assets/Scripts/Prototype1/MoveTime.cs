using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTime : MovementControl
{
    [SerializeField] float delayTime;
    protected override void Moving()
    {
        float mathNumbers = speed * (Time.deltaTime / delayTime);

        Vector2 playerMoving = new Vector2(moveDir.x * mathNumbers, moveDir.y * mathNumbers);
        playerRB.velocity = transform.TransformDirection(playerMoving);
    }
}
