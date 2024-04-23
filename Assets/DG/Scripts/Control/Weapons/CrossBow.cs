using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBow : Search
{
    public float attackSpeed;

    public GameObject arrow;
    Transform player;
    float timer = 0f;

    void Start()
    {
        Search_Init();
        player = GameObject.Find("Player").transform;
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 60f) timer = 0f;
    }

    void Update()
    {
        SearchSomething();

        if (target)
        {
            AttackToEnemy();
        }
    }

    void AttackToEnemy()
    {
        transform.LookAt(target.position);

        if (timer >= (60 / attackSpeed))
        {
            GameObject bullet = Instantiate(arrow, transform.position, transform.rotation);
            timer = 0f;
        }
    }
}
