using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalCollapse : MonoBehaviour
{
    public CollapseCheck[] checks;
    public Explode failExplode;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag.Equals("Player"))
        {
            int cnt = 0;

            for(int i = 0; i < 3; i++)
            {
                if (checks[i].blockedCount)
                    cnt++;
            }
            if(cnt != 3)
            {
                Debug.Log("Failed to Block");
                failExplode.trigger = true;
            }
        }
    }
}
