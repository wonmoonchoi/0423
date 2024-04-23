using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    public int damage = 8;

    void OnEnable()
    {
        Destroy(gameObject, 3.0f);
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.up * 4.0f);
    }
}
