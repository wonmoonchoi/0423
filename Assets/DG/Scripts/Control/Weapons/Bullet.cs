using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 20f;

    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ENEMY"))
        {
            other.SendMessage("OnHit", SendMessageOptions.DontRequireReceiver);
        }
    }
}
