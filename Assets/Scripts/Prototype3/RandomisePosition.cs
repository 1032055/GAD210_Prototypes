using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomisePosition : MonoBehaviour
{
    float xPos, yPos, zPos;

    public void MoveSpot()
    {
        xPos = Random.Range(-5f, 5f);
        yPos = Random.Range(-5f, 5f);
        zPos = Random.Range(-5f, 5f);

        this.transform.position = new Vector3(xPos, yPos, zPos);
    }
}
