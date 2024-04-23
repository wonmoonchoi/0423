using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Diagnostics;

/* INGAME 일반 몬스터에 사용되는 스크립트 */

public class Monster : MonoBehaviour
{
    public enum State
    {
        IDLE,
        TRACE,
        ATTACK,
        DIE
    }

    public float _hp;

    public State state = State.IDLE;
    public float traceDist = 9999.9f;
    public float attackDist = 1.0f;
    public bool isDie = false;

    private Transform monsterTr;
    public Transform playerTr;
    public NavMeshAgent agent;
    private Animator anim;

    private readonly int hashTrace = Animator.StringToHash("IsTrace");
    private readonly int hashAttack = Animator.StringToHash("IsAttack");
    private readonly int hashHit = Animator.StringToHash("Hit");
    private readonly int hashDie = Animator.StringToHash("Die");

    public float _takeExp;
    public Text damagedText;

    void OnEnable()
    {
        Player.OnPlayerDie += this.OnPlayerDie;

        Init();
    }
    void OnDisable()
    {
        Player.OnPlayerDie -= this.OnPlayerDie;
    }

    void Start()
    {
        _takeExp = GetComponent<Monster_Stat>().takeExp;

        monsterTr = GetComponent<Transform>();
        playerTr = GameObject.FindWithTag("PLAYER").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        attackDist = GetComponent<Monster_Stat>().attackRange;
        _hp = GetComponent<Monster_Stat>().hp;

        StartCoroutine(CheckMonsterState());
        StartCoroutine(MonsterAction());
    }

    void Init()
    {
        state = State.IDLE;
        isDie = false;

        monsterTr = GetComponent<Transform>();
        playerTr = GameObject.FindWithTag("PLAYER").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        attackDist = GetComponent<Monster_Stat>().attackRange;
        _hp = GetComponent<Monster_Stat>().hp;

        StartCoroutine(CheckMonsterState());
        StartCoroutine(MonsterAction());
    }

    IEnumerator CheckMonsterState()
    {
        while (!isDie)
        {
            yield return new WaitForSeconds(0.3f);

            if (playerTr == null) playerTr = GameObject.FindWithTag("PLAYER").GetComponent<Transform>();

            if (state == State.DIE) yield break;

            float distance = Vector3.Distance(playerTr.position, monsterTr.position);

            if (distance <= attackDist)
            {
                state = State.ATTACK;
            }
            else if (distance <= traceDist)
            {
                state = State.TRACE;
            }
            else if (_hp <= 0)
            {
                state = State.DIE;
            }
            else
            {
                state = State.IDLE;
            }
        }
    }

    IEnumerator MonsterAction()
    {
        while (!isDie)
        {
            switch (state)
            {
                case State.IDLE:
                    agent.isStopped = true;
                    anim.SetBool(hashTrace, false);
                    break;
                case State.TRACE:
                    agent.SetDestination(playerTr.position);
                    agent.isStopped = false;
                    anim.SetBool(hashTrace, true);
                    anim.SetBool(hashAttack, false);
                    break;
                case State.ATTACK:
                    anim.SetBool(hashAttack, true);
                    break;
                case State.DIE:
                    isDie = true;
                    agent.isStopped = true;
                    anim.SetTrigger(hashDie);
                    yield return new WaitForSeconds(2.0f);
                    GameManager.instance.player._currentExp += _takeExp;
                    DropCoin();
                    this.gameObject.SetActive(false);
                    break;
            }
            yield return new WaitForSeconds(0.3f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WEAPON") && _hp > 0)
        {
            //damagedText.text = other.GetComponent<WeaponStat>().damage.ToString();
            //데미지 텍스트 생성

            anim.SetTrigger(hashHit);
            _hp -= other.GetComponent<WeaponStat>().damage;

            other.GetComponent<BoxCollider>().enabled = false;
        }

        if (_hp <= 0)
        {
            state = State.DIE;
        }
    }

    void OnPlayerDie()
    {
        StopAllCoroutines();

        agent.isStopped = true;
    }

    void DropCoin()
    {

    }
}
