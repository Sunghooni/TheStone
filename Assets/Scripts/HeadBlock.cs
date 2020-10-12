using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBlock : Blocks
{
    int MovePos;
    void Awake()
    {
        MovePos = int.Parse(this.transform.name);
        this.originPos = this.transform.position;
        toPos = originPos;
        toPos += transform.right * -MovePos;
    }

    private void FixedUpdate()
    {
        Move();
    }
}