using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Search2 : MonoBehaviour
{
    public float scanRange;
    public LayerMask targetLayer;
    public RaycastHit[] targets;
    public Transform target;

    void Start()
    {
        targetLayer = LayerMask.GetMask("ENEMY");

        scanRange = 10.0f;
    }

    void FixedUpdate()
    {
        targets = Physics.SphereCastAll(transform.position, scanRange, Vector3.forward, 0, targetLayer);

        target = GetNearest();
    }

    public void Search_Init()
    {
        targetLayer = LayerMask.GetMask("ENEMY");

        scanRange = 10.0f;
    }

    public void SearchSomething()
    {
        targets = Physics.SphereCastAll(transform.position, scanRange, Vector3.forward, 0, targetLayer);

        target = GetNearest();
    }

    Transform GetNearest()
    {
        Transform result = null;
        float diff = 100;

        foreach (RaycastHit target in targets)
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = target.transform.position;
            float curDiff = Vector3.Distance(myPos, targetPos);

            if(curDiff < diff)
            {
                diff = curDiff;
                result = target.transform;
            }
        }
        return result;
    }
}
