using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Search : MonoBehaviour
{
    public Transform target;
    float range = 15.0f;
    LayerMask mask;

    public void Search_Init()
    {
        mask = LayerMask.GetMask("ENEMY");
    }

    public Transform SearchSomething()
    {
        Collider[] targetArry = Physics.OverlapSphere(transform.position, range, mask);

        if (targetArry.Length > 0)
        {
            foreach (Collider collider in targetArry)
            {
                target = collider.transform;
                Vector3 targetVector = target.transform.position;
            }
        }
        else
        {
            target = null;
        }

        return target;
    }
}
