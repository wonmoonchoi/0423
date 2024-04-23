using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UI;

public class RengeWeapon : MonoBehaviour
{
    enum State
    {
        Idle,
        Attack,
        Follow
    }

    State state = new State();

    public LayerMask mask;
    public Transform target;
    public Transform player;
    float time = 0.0f;
    bool isMove = false;
    float speed = 0.01f;

    void Start()
    {
        state = State.Idle;

        mask = LayerMask.GetMask("Enemy");
        player = GameObject.Find("Player").transform;
        player = player.transform.Find("WeaponSlot").transform;
    }

    void Update()
    {
        time += Time.deltaTime;

        ChangeState();

        switch (state)
        {
            case State.Idle:
                Hober();
                break;

            case State.Attack:
                AttackToEnemy();
                break;

            case State.Follow:
                FollowToPlayer();
                break;

            default:
                break;
        }
    }

    void FollowToPlayer()
    {
        isMove = true;
        transform.LookAt(player);
        transform.Translate(Vector3.forward * 2.5f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isMove)
        {
            isMove = false;
        }
    }

    void AttackToEnemy()
    {
        if (time > 1.5f)
        {
            GameObject bullet = GameManager.instance.pool.Get(4);
            bullet.transform.rotation = transform.rotation;
            bullet.transform.position = transform.position;

            time = 0.0f;
        }
    }

    void SearchEnemy()
    {
        float range = 15.0f;

        Collider[] targetArry = Physics.OverlapSphere(transform.position, range, mask);

        if (targetArry.Length > 0)
        {
            foreach (Collider collider in targetArry)
            {
                target = collider.transform;
                Vector3 targetVector = target.transform.position;
            }
        }
        else
        {
            target = null;
        }

        if (target != null)
            transform.LookAt(target);
    }

    void ChangeState()
    {
        SearchEnemy();

        float dist = Vector3.Distance(transform.position, player.position);

        if (target != null && isMove == false)
        {
            state = State.Attack;
        }
        else if (dist > 5.5f && isMove == false)
        {
            state = State.Follow;
        }
        else if (isMove == false)
        {
            state = State.Idle;
        }
    }

    void Hober()
    {
        //애니메이션 클립 or 코루틴
    }
}
