using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block1 : Block
{
    public float MoveDistance = 9;
    void Awake()
    {
        originPos = this.transform.position;
        toPos = originPos + transform.right * -MoveDistance;
    }

    private void FixedUpdate()
    {
        Move();
    }
}