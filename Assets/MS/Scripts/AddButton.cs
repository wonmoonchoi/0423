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
    public GameObject prefabToInstantiate; // 생성할 프리팹 오브젝트
    public GameObject Add; // 슬롯추가버튼
    public List<GameObject> AddList = new List<GameObject>(); // 슬롯추가버튼 갯수 
    public Vector3[] transforms;
    public int AddListint;
    // public GameObject[] slotObjects;
    public List<GameObject> slotObjects = new List<GameObject>();
    public GameObject randomSlotObject; // 필드위 슬롯중 랜덤하게 레이캐스트 쏨
    public int Fight; // 슬롯하고 부딪힘
    public Vector3 AddPosition; // 레이캐스트 쏜 방향*거리
    public bool AddCheck; // 생성한 슬롯추가버튼을 누를시 true
    public bool AddCheck2;
    public GameObject ButtonClone;
    public int Count = 0; // 슬롯추가시 Count++
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
        foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>()) // 씬에서 슬롯 레이어 가진 오브젝트 갯수만큼 변수 Slot+1
        {
            if (obj.layer == LayerMask.NameToLayer("Slot"))
            {
                Slot++;
            }
        }
        if (Slot < 120) // 슬롯의 개수가 120 이하일시 버튼 생성, 아이템 픽업불가, 슬롯추가버튼리롤버튼 활성화, 시작버튼 비활성화, 상점리롤버튼 비활성화
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
        if (Slot < 120) // 슬롯이 120 이하일경우
        {
            if (Input.GetKeyDown(KeyCode.Q)) // 씬 전환때마다 발생
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
            // "Slot" 레이어에 속하는 모든 GameObject를 찾아 리스트에 추가하고 순서를 섞습니다.
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
            // 각 슬롯 오브젝트마다 네 가지 방향에 대해 레이캐스트를 실행하여 충돌한 슬롯을 찾습니다.
            foreach (GameObject obj in slotObjects)
            {
                foreach (Vector2 dir in directions)
                {
                    Vector3 randomSlotPosition = obj.transform.position;
                    RaycastHit2D[] hits = Physics2D.RaycastAll(randomSlotPosition, dir, 0.45f);

                    // 이미 5개 이상의 슬롯이 추가되었거나 슬롯이 120개 이상이라면 종료합니다.
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
                            // AddList가 비어 있는지 확인하여 null 검사를 제거합니다.
                            if (AddList.Count == 0)
                            {
                                AddList = new List<GameObject>();
                            }

                            bool isClose = false;
                            foreach (GameObject addlist in AddList)
                            {
                                // 거리의 제곱을 비교하여 정확성을 높입니다.
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

    // Fisher-Yates 알고리즘을 사용하여 List를 섞는 함수
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
    public void AddButtonReroll() // 슬롯추가버튼 리롤
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
        while (AddList.Count < 5 && Slot + AddList.Count < 120) // 슬롯추가 버튼 랜덤 5개 생성
        {
            AddFunction3();
        }
    }

    public void addbtn()
    {
        if (Slot < 120) // 슬롯이 120 이하일경우
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