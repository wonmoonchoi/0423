using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Progress;

public class Store : MonoBehaviour
{
    public GameObject[] Prefabs; // ������ ������ �迭
    public GameObject[] Stores; // ���� �迭
    public List<GameObject> CreateItem = new List<GameObject>();
    public bool[] Reset = new bool[5];

    public int RandomItemIndex;
    public PickUpDown pickUpDownScript;
    public List<GameObject> itemsToRemove = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            RandomItemIndex = Random.Range(0, Prefabs.Length); // ������ ���� ���� ����
            GameObject instance = Instantiate(Prefabs[RandomItemIndex], Stores[i].transform.position, Quaternion.identity);
            CreateItem.Add(instance); // ����� CreateItem ����Ʈ�� ����
            instance.transform.parent = Stores[i].transform; // ����� ���� �ڽ����� ����
            pickUpDownScript = instance.GetComponent<PickUpDown>(); // pickUpDownScript ������ ������� ��ũ��Ʈ �Ⱦ��ٿ� ����
            if (pickUpDownScript != null) // �Ⱦ��ٿ��� �����ҽ�
            {
                pickUpDownScript.Equip = true; // �Ⱦ��ٿ� Equip ���� true
                pickUpDownScript.Store = Stores[i].transform; // �Ⱦ��ٿ� ��ũ��Ʈ�� ������Ʈ ��ġ ���� Store�� ���� (������ �ڽ�)
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
                RandomItemIndex = Random.Range(0, Prefabs.Length); // ������ ���� ���� ����
                GameObject instance = Instantiate(Prefabs[RandomItemIndex], Stores[i].transform.position, Quaternion.identity);
                CreateItem.Add(instance); // ����� CreateItem ����Ʈ�� ����
                instance.transform.parent = Stores[i].transform; // ����� ���� �ڽ����� ����
                pickUpDownScript = instance.GetComponent<PickUpDown>(); // pickUpDownScript ������ ������� ��ũ��Ʈ �Ⱦ��ٿ� ����
                if (pickUpDownScript != null) // �Ⱦ��ٿ��� �����ҽ�
                {
                    pickUpDownScript.Equip = true; // �Ⱦ��ٿ� Equip ���� true
                    pickUpDownScript.Store = Stores[i].transform; // �Ⱦ��ٿ� ��ũ��Ʈ�� ������Ʈ ��ġ ���� Store�� ���� (������ �ڽ�)
                }
            }
        }
    }
}
