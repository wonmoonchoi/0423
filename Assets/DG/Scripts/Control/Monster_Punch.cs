using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 몬스터가 타격하는 부위에 부착하는 스크립트 */

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
