using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Test : Search
{
    public float attackSpeed;

    Transform player;
    Animator anim;
    float timer = 0.0f;
    private readonly int hashAttack = Animator.StringToHash("IsAttack");

    void Start()
    {
        Search_Init();
        player = GameObject.Find("Player").transform;
        anim = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 60f) timer = 0.0f;
    }
    
    void Update()
    {
        SearchSomething();
    
        if (target)
        {
            AttackToEnemy();
        }
    
        if(Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger(hashAttack);
        }
    }
    
    void AttackToEnemy()
    {
        transform.LookAt(target.position);
        transform.position = target.position + (target.forward * 1.0f);
    
        if (timer >= (60 / attackSpeed))
        {
            GetComponent<BoxCollider>().enabled = true;
            anim.SetTrigger(hashAttack);
            timer = 0.0f;
        }
    }
}
