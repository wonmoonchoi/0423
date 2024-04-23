using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
//using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
//using static UnityEditor.Progress;
using static UnityEngine.UI.Image;
using Random = UnityEngine.Random;

public class AddButton : MonoBehaviour
{
    public GameObject prefabToInstantiate; // ������ ������ ������Ʈ
    public GameObject Add; // �����߰���ư
    public List<GameObject> AddList = new List<GameObject>(); // �����߰���ư ���� 
    public Vector3[] transforms;
    public int AddListint;
    // public GameObject[] slotObjects;
    public List<GameObject> slotObjects = new List<GameObject>();
    public GameObject randomSlotObject; // �ʵ��� ������ �����ϰ� ����ĳ��Ʈ ��
    public int Fight; // �����ϰ� �ε���
    public Vector3 AddPosition; // ����ĳ��Ʈ �� ����*�Ÿ�
    public bool AddCheck; // ������ �����߰���ư�� ������ true
    public bool AddCheck2;
    public GameObject ButtonClone;
    public int Count = 0; // �����߰��� Count++
    public int Slot = 0;
    public int SlotAdd = 2;

    public SlotReroll slotReroll;
    public Reroll reroll;
    public Start start;
    public bool PickUp;

    private List<Vector2> directions = new List<Vector2>
    {
        Vector2.up,
        Vector2.down,
        Vector2.left,
        Vector2.right
    };

    void Start()
    {
        foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>()) // ������ ���� ���̾� ���� ������Ʈ ������ŭ ���� Slot+1
        {
            if (obj.layer == LayerMask.NameToLayer("Slot"))
            {
                Slot++;
            }
        }
        if (Slot < 120) // ������ ������ 120 �����Ͻ� ��ư ����, ������ �Ⱦ��Ұ�, �����߰���ư���ѹ�ư Ȱ��ȭ, ���۹�ư ��Ȱ��ȭ, �������ѹ�ư ��Ȱ��ȭ
        {
            AddButtonCreate();
            PickUp = false;
            slotReroll.gameObject.SetActive(true);
            reroll.gameObject.SetActive(false);
            start.gameObject.SetActive(false);
        }
    }
    void Update()
    {
        if (Slot < 120) // ������ 120 �����ϰ��
        {
            if (Input.GetKeyDown(KeyCode.Q)) // �� ��ȯ������ �߻�
            {
                Count = 0;
                AddButtonCreate();
                PickUp = false;
                slotReroll.gameObject.SetActive(true);
                reroll.gameObject.SetActive(false);
                start.gameObject.SetActive(false);
            }
        }
    }


    void AddFunction3()
    {
        if (Slot < 120)
        {
            // "Slot" ���̾ ���ϴ� ��� GameObject�� ã�� ����Ʈ�� �߰��ϰ� ������ �����ϴ�.
            slotObjects.Clear();
            foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>())
            {
                if (obj.layer == LayerMask.NameToLayer("Slot"))
                {
                    slotObjects.Add(obj);
                }
            }
            Slot = slotObjects.Count;
            ShuffleList(slotObjects);
            ShuffleDirections(directions);
            // �� ���� ������Ʈ���� �� ���� ���⿡ ���� ����ĳ��Ʈ�� �����Ͽ� �浹�� ������ ã���ϴ�.
            foreach (GameObject obj in slotObjects)
            {
                foreach (Vector2 dir in directions)
                {
                    Vector3 randomSlotPosition = obj.transform.position;
                    RaycastHit2D[] hits = Physics2D.RaycastAll(randomSlotPosition, dir, 0.45f);

                    // �̹� 5�� �̻��� ������ �߰��Ǿ��ų� ������ 120�� �̻��̶�� �����մϴ�.
                    if (AddList.Count >= 5 || Slot + AddList.Count >= 120)
                    {
                        return;
                    }

                    foreach (RaycastHit2D hit in hits)
                    {
                        if (hit.collider.CompareTag("Slot"))
                        {
                            Debug.DrawRay(randomSlotPosition, dir * 0.45f, UnityEngine.Color.red, 3);
                            Fight++;
                        }
                    }

                    if (Fight == 1)
                    {
                        AddPosition = dir * 0.45f;
                        Vector3 AddPos = randomSlotPosition + AddPosition;
                        if (AddPos.x > 607.99 && 613 > AddPos.x && AddPos.y > 284.5 && 288.6 > AddPos.y)
                        {
                            // AddList�� ��� �ִ��� Ȯ���Ͽ� null �˻縦 �����մϴ�.
                            if (AddList.Count == 0)
                            {
                                AddList = new List<GameObject>();
                            }

                            bool isClose = false;
                            foreach (GameObject addlist in AddList)
                            {
                                // �Ÿ��� ������ ���Ͽ� ��Ȯ���� ���Դϴ�.
                                if ((addlist.transform.position - (hits[0].transform.position + AddPosition)).sqrMagnitude < 0.000001f)
                                {
                                    isClose = true;
                                    break;
                                }
                            }

                            if (!isClose)
                            {
                                Add = Instantiate(prefabToInstantiate);
                                AddList.Add(Add);
                                Add.transform.position = hits[0].transform.position + AddPosition;
                            }
                        }
                    }
                    else
                    {
                        Fight = 0;
                    }
                }
            }
        }
    }

    // Fisher-Yates �˰����� ����Ͽ� List�� ���� �Լ�
    private void ShuffleList(List<GameObject> list)
    {
        System.Random random = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            GameObject temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
    }

    private void ShuffleDirections(List<Vector2> list)
    {
        System.Random random = new System.Random();
        int n = directions.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            Vector2 temp = directions[k];
            directions[k] = directions[n];
            directions[n] = temp;
        }
    }
    public void AddButtonReroll() // �����߰���ư ����
    {
        if (AddList.Count > 0)
        {
            foreach (GameObject obj in AddList)
            {
                Destroy(obj);
            }
            AddList.Clear();
            AddButtonCreate();
        }
    }
    public void AddButtonCreate()
    {
        while (AddList.Count < 5 && Slot + AddList.Count < 120) // �����߰� ��ư ���� 5�� ����
        {
            AddFunction3();
        }
    }

    public void addbtn()
    {
        if (Slot < 120) // ������ 120 �����ϰ��
        {
            Count = 0;
            AddButtonCreate();
            PickUp = false;
            slotReroll.gameObject.SetActive(true);
            reroll.gameObject.SetActive(false);
            start.gameObject.SetActive(false);
        }
    }
}