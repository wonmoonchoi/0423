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
        //���� ������ ������ slot �ȿ��� �־����.
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
            Debug.Log("�÷��̾ ã�� �� �����ϴ�. ��õ� ��...");

            WaitForSeconds wait = new WaitForSeconds(1f);
            StartCoroutine(WaitAndFindPlayer(wait));
        }

        Debug.Log("�÷��̾ ã�ҽ��ϴ�!");
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
//    // �Է� �ޱ�
//    float moveX = Input.GetAxis("Horizontal");
//    float moveY = Input.GetAxis("Vertical");
//
//    // ���� ���� ������ ���
//    Vector3 localPosition = transform.localPosition;
//
//    // �̵��� ���
//    Vector3 movement = new Vector3(moveX, moveY, 0f) * speed * Time.deltaTime;
//
//    // ���ѵ� ���� ���������� �̵�
//    float clampedX = Mathf.Clamp(localPosition.x + movement.x, minX, maxX);
//    float clampedY = Mathf.Clamp(localPosition.y + movement.y, minY, maxY);
//
//    // ���ο� ���� ������ ����
//    transform.localPosition = new Vector3(clampedX, clampedY, localPosition.z);
//}