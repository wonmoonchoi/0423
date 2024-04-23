using System.Collections;
using UnityEngine;

//public class MeleeWeapon : Search
//{
//    public Transform player;
//    public float distance = 1.0f;
//    public float attackSpeed = 2.0f;
//    float timer = 0f;
//    Vector3 offSet_y = new Vector3(0, 1, 0);
//
//    Vector3 originalPosition;
//    Quaternion originalRotation;
//
//    bool isAttack = false;
//    bool isReturn = false;
//
//    void Start()
//    {
//        player = GameObject.Find("Player").transform;
//
//        init();
//    }
//
//    void init()
//    {
//        transform.position = player.position - (player.forward * distance) + offSet_y;
//        originalPosition = transform.position;
//        originalRotation = transform.rotation;
//    }
//
//    void Update()
//    {
//        timer += Time.deltaTime;
//
//        if (!isAttack)
//        {
//            SearchEnemy();
//            SearchSomething();
//            FollowToPlayer();
//        }
//
//        if (target)
//        {
//            transform.LookAt(target);
//
//            StartCoroutine(AttackToEnemy());
//
//            if(Vector3.Distance(target.position, transform.position) < 1.0f)
//            {
//                Debug.Log("dd");
//            }
//        }
//    }
//
//    void SearchEnemy()
//    {
//        //Collider[] colliders = Physics.OverlapSphere(transform.position, range, mask);
//        //
//        //target = null;
//        //float diff = 100;
//        //
//        //foreach (Collider collider in colliders)
//        //{
//        //    Vector3 myPos = transform.position;
//        //    Vector3 targetPos = collider.transform.position;
//        //    float curDiff = Vector3.Distance(myPos, targetPos);
//        //
//        //    if (curDiff < diff)
//        //    {
//        //        diff = curDiff;
//        //        target = collider.transform;
//        //    }
//        //}
//    }
//
//    void FollowToPlayer()
//    {
//        Vector3 targetPosition = player.position - (player.forward * distance) + offSet_y;
//        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 4.0f);
//    }
//
//    IEnumerator AttackToEnemy()
//    {
//        transform.position = Vector3.MoveTowards(transform.position, target.position, attackSpeed);
//
//        yield return new WaitForSeconds(attackSpeed);
//
//        transform.position = Vector3.MoveTowards(transform.position, originalPosition, attackSpeed);
//
//        yield return new WaitForSeconds(attackSpeed);
//    }
//}
