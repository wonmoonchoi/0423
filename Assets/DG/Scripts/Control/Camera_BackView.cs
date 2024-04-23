using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_BackView : MonoBehaviour
{
    public Transform target;
    public float distance = 5.0f;
    public float height = 2.0f;

    void OnEnable()
    {
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        transform.position = target.position + (-target.forward * distance) + (Vector3.up * height);
        transform.LookAt(target.position);
    }
}
