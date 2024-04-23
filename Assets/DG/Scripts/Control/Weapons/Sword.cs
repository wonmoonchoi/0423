using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Sword : Search2
{
    public float _attackSpeed;

    private Transform player;
    private Animator anim;
    private float timer = 0.0f;
    private float returnSpeed = 5.0f;
    private readonly int hashAttack = Animator.StringToHash("IsAttack");

    void Start()
    {
        Search_Init();
        player = GameObject.Find("Player").transform;
        anim = GetComponentInChildren<Animator>();

        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        while (true)
        {
            timer += Time.deltaTime;

            SearchSomething();
            yield return null;

            if (target && Vector3.Distance(player.position, target.position) < 5.0f)
            {
                StartCoroutine(Swing());
            }
            else
            {
                if(Vector3.Distance(transform.position, player.position) > 1.0f)
                {
                    transform.LookAt(player);
                    transform.Translate(Vector3.forward * returnSpeed * Time.deltaTime);
                    target = null;
                }
            }
        }
    }

    IEnumerator Swing()
    {
            transform.position = target.position + (target.forward * 1.0f);
            transform.LookAt(target.position);
            yield return null;

        if (timer >= (60 / _attackSpeed))
        {
            GetComponentInChildren<BoxCollider>().enabled = true;
            anim.SetTrigger(hashAttack);
            timer = 0.0f;
        }
    }
}
