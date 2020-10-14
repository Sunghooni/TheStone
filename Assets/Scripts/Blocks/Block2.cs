using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block2 : Block
{
    public float MoveDistance = 6;
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
