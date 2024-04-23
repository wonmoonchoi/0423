using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 100.0f;
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float v = Input.GetAxis("Vertical");

        Vector3 moveVec = new Vector3(0, 0, v).normalized;

        transform.Translate(moveVec * moveSpeed * Time.deltaTime);
        anim.SetBool("IsMove", true);

        float h = Input.GetAxis("Horizontal");

        float rotationAmount = h * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationAmount);

        if (moveVec.magnitude <= 0.0f)
            anim.SetBool("IsMove", false);
    }
}
