using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    enum State
    {
        Idle,
        Move,
        Attack
    }

    /* 몬스터 로직 관련 */
    State state = new State();
    public Transform target;
    public float stoppingDistance = 1f;
    public GameObject punch;
    bool isAttack = false;
    int layerMask;
    Animator anim;

    /* 몬스터 기본 스테이터스 */
    public float speed = 2.0f;
    public float health = 100.0f;
    public float damage = 1.0f;

    /* 플레이어에게 Take 할 아이템 설정 */
    public float takeExp = 2.0f;
    public int takeCoin = 1;

    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.Find("Player").transform;
        layerMask = LayerMask.NameToLayer("Weapon");
        state = State.Move;
    }

    void OnEnable()
    {
        target = GameObject.Find("Player").transform;
        layerMask = LayerMask.NameToLayer("Weapon");
        health = 100.0f;
    }

    void Update()
    {
        ChangeState();

        switch (state)
        {
            case State.Idle:
                break;
            case State.Move:
                Move();
                break;
            case State.Attack:
                StartCoroutine(Attack());
                break;
            default:
                break;
        }
    }

    void Move()
    {
        if (health > 0)
        {
            Vector3 direction = target.position - transform.position;
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);

            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.deltaTime * 5f);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            anim.SetBool("move", true);
        }
    }
    
    IEnumerator Attack()
    {
        isAttack = true;

        anim.SetBool("move", false);
        anim.SetTrigger("attack");

        float animTime = anim.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animTime);

        isAttack = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WEAPON"))
        {
            health -= other.GetComponent<WeaponStat>().damage;
        }   //데미지 웨폰에서 받기
    
        if(health <= 0)
        {
            GameManager.instance.player._currentExp += takeExp;
            StartCoroutine(Dead());
        }
    }

    IEnumerator Dead()
    {
        anim.SetTrigger("die");

        int temp = takeCoin;
        while (takeCoin > temp)
        {
            GameObject coin = GameManager.instance.pool.Get(0);
            coin.transform.position = transform.position + (transform.up * 1.0f);
            temp--;
        }
    
        yield return new WaitForSeconds(0.8f);
        gameObject.SetActive(false);
    }



    void ChangeState()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (!target)
        {
            state = State.Idle;
        }
        else if (distance > stoppingDistance && !isAttack && target)
        {
            state = State.Move;
        }
        else
        {
            state = State.Attack;
        }
    }

    void OnPlayerHit()
    {
        if (GameManager.instance.player._currentHp > 0)
        {
            GameManager.instance.player._currentHp -= damage;
        }
    }
}
