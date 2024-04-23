using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Test_Action : MonoBehaviour
{
    Vector3 originPositon;
    Quaternion originRotation;
    public Transform target;
    public float temp = 0f;

    void Start()
    {
        originPositon = transform.position;
        originRotation = transform.rotation;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            transform.LookAt(target);
        }

        if(Input.GetMouseButtonDown(1))
        {
            //Quaternion startRotation = transform.rotation;
            //Quaternion targetRotation = originRotation;
            //transform.rotation = Quaternion.Slerp(startRotation, targetRotation, 10f);

            Quaternion startRotation = Quaternion.identity;
            Quaternion targetRotation = Quaternion.Euler(0, 90, 0);
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, temp);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = originPositon;
            transform.rotation = originRotation;
        }
    }
}
