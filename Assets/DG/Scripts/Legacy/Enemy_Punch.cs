using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Punch : MonoBehaviour
{
    public GameObject monster;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PLAYER"))
        {
            monster.SendMessage("OnPlayerHit", SendMessageOptions.DontRequireReceiver);
        }
    }
}
