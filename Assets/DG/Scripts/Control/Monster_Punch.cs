using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ���Ͱ� Ÿ���ϴ� ������ �����ϴ� ��ũ��Ʈ */

public class Monster_Punch : MonoBehaviour
{
    public float _damage;
    public Monster_Stat stat;

    void Start()
    {
        stat = GetComponentInParent<Monster_Stat>();
        _damage = stat.damage;
    }
}
