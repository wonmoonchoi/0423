using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Progress;

public class Store : MonoBehaviour
{
    public GameObject[] Prefabs; // 생성할 프리팹 배열
    public GameObject[] Stores; // 상점 배열
    public List<GameObject> CreateItem = new List<GameObject>();
    public bool[] Reset = new bool[5];

    public int RandomItemIndex;
    public PickUpDown pickUpDownScript;
    public List<GameObject> itemsToRemove = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            RandomItemIndex = Random.Range(0, Prefabs.Length); // 프리펩 범위 랜덤 선택
            GameObject instance = Instantiate(Prefabs[RandomItemIndex], Stores[i].transform.position, Quaternion.identity);
            CreateItem.Add(instance); // 만든거 CreateItem 리스트에 넣음
            instance.transform.parent = Stores[i].transform; // 만든걸 상점 자식으로 넣음
            pickUpDownScript = instance.GetComponent<PickUpDown>(); // pickUpDownScript 변수에 만든거의 스크립트 픽업다운 넣음
            if (pickUpDownScript != null) // 픽업다운이 존재할시
            {
                pickUpDownScript.Equip = true; // 픽업다운 Equip 변수 true
                pickUpDownScript.Store = Stores[i].transform; // 픽업다운 스크립트에 오브젝트 위치 변수 Store에 저장 (상점의 자식)
                pickUpDownScript.SubSlot.Add(pickUpDownScript.gameObject);
                for(int j = 1; j < pickUpDownScript.gameObject.transform.childCount; j++)
                {
                    pickUpDownScript.SubSlot.Add(pickUpDownScript.gameObject.transform.GetChild(j).gameObject);
                }
            }
        }
    }
    public void StoreReset()
    {
        for (int i = 0; i < Stores.Length; i++)
        {
            if (Stores[i].transform.childCount == 1)
            {
                pickUpDownScript = Stores[i].transform.GetChild(0).GetComponent<PickUpDown>();
                if (pickUpDownScript != null && pickUpDownScript.Lock)
                {
                    Reset[i] = true;
                }
                if (pickUpDownScript != null && pickUpDownScript.Lock == false)
                {
                    Reset[i] = false;
                }
            }
        }
        foreach (GameObject item in CreateItem)
        {
            pickUpDownScript = item.GetComponent<PickUpDown>();
            if (pickUpDownScript != null && pickUpDownScript.Lock == false)
            {
                Destroy(item);
                itemsToRemove.Add(item);
            }
        }

        foreach (GameObject itemToRemove in itemsToRemove)
        {
            CreateItem.Remove(itemToRemove);
        }
        for (int i = 0; i < Stores.Length; i++)
        {
            if (Reset[i] == false)
            {
                RandomItemIndex = Random.Range(0, Prefabs.Length); // 프리펩 범위 랜덤 선택
                GameObject instance = Instantiate(Prefabs[RandomItemIndex], Stores[i].transform.position, Quaternion.identity);
                CreateItem.Add(instance); // 만든거 CreateItem 리스트에 넣음
                instance.transform.parent = Stores[i].transform; // 만든걸 상점 자식으로 넣음
                pickUpDownScript = instance.GetComponent<PickUpDown>(); // pickUpDownScript 변수에 만든거의 스크립트 픽업다운 넣음
                if (pickUpDownScript != null) // 픽업다운이 존재할시
                {
                    pickUpDownScript.Equip = true; // 픽업다운 Equip 변수 true
                    pickUpDownScript.Store = Stores[i].transform; // 픽업다운 스크립트에 오브젝트 위치 변수 Store에 저장 (상점의 자식)
                }
            }
        }
    }
}
