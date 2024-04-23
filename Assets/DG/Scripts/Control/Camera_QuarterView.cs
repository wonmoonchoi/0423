using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Camera_QuarterView : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    void LateUpdate()
    {
        offset = new Vector3(0, 6, -6);

        if (target == null)
        {
            GameObject playerObject = GameObject.Find("Player");
            if (playerObject != null)
            {
                target = playerObject.transform;
            }
            else
            {
                Debug.Log("Player 가 없습니다. Camera");
                
            }
        }

        if (target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position + offset, 1.5f);
            transform.position = target.position + offset;
        }
    }
}
