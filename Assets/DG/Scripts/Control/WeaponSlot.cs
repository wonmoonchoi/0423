using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    public Transform player;
    public GameObject[] slot;
    public float radius = 1.0f;
    public Vector3 offSet;

    void Start()
    {
        offSet = new Vector3(0, 1, -0.5f);

        TakeWeapon();
        ArrangeMent();
    }

    void Update()
    {
        FindPlayer();

        transform.position = player.position + offSet;
    }

    void TakeWeapon()
    {
        //무기 정보를 가져와 slot 안에다 넣어줘라.
    }

    void ArrangeMent()
    {
        for (int index = 0; index < slot.Length; index++)
        {
            float angle = index * 180f / slot.Length;
            Vector3 position = transform.position + Quaternion.Euler(0f, angle, 0f) * Vector3.back * radius;

            GameObject weapon = Instantiate(slot[index], position, Quaternion.identity);
            weapon.transform.parent = transform;
        }
    }

    void FindPlayer()
    {
        player = GameObject.Find("Player").transform;

        while (player == null)
        {
            Debug.Log("플레이어를 찾을 수 없습니다. 재시도 중...");

            WaitForSeconds wait = new WaitForSeconds(1f);
            StartCoroutine(WaitAndFindPlayer(wait));
        }

        Debug.Log("플레이어를 찾았습니다!");
    }

    IEnumerator WaitAndFindPlayer(WaitForSeconds wait)
    {
        yield return wait;
        player = GameObject.Find("Player").transform;
    }
}


//public float minX = -5f;
//public float maxX = 5f;
//public float minY = 0f;
//public float maxY = 10f;
//public float speed = 5f;
//
//void Update()
//{
//    // 입력 받기
//    float moveX = Input.GetAxis("Horizontal");
//    float moveY = Input.GetAxis("Vertical");
//
//    // 현재 로컬 포지션 얻기
//    Vector3 localPosition = transform.localPosition;
//
//    // 이동량 계산
//    Vector3 movement = new Vector3(moveX, moveY, 0f) * speed * Time.deltaTime;
//
//    // 제한된 로컬 포지션으로 이동
//    float clampedX = Mathf.Clamp(localPosition.x + movement.x, minX, maxX);
//    float clampedY = Mathf.Clamp(localPosition.y + movement.y, minY, maxY);
//
//    // 새로운 로컬 포지션 설정
//    transform.localPosition = new Vector3(clampedX, clampedY, localPosition.z);
//}