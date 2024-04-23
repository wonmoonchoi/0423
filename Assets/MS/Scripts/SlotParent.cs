using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class SlotParent : MonoBehaviour
{
    public GameObject ParentItem;
    public PickUpDown pickupdown;
    public bool PickDownCheck;

    private List<GameObject> FoundObjects; // �Ÿ� ����� ������Ʈ�� �迭�� �ִ� �뵵
    public GameObject Slot; // ���� ����� ������Ʈ��
    public GameObject Slot2;
    public string TagName; // �Ÿ� ����� ������Ʈ �±� �Է�
    private float shortDis; // ���� ����� ������Ʈ���� �Ÿ�

    public int SlotCount;
    public Save save;

    Vector3 ItemPos;

    // ���� �� ���� �Ÿ��� ������ ����
    public float distanceX = 0f;
    public float distanceY = 0f;

    public bool RotateS;
    public bool DisCheckS;
    public bool Exact;

    public GameObject Highlight;
    public GameObject HighlightNull;

    void Start()
    {

    }

    void Update()
    {
        if (ParentItem != null)
        {
            RotateS = pickupdown.Rotate;

            if (RotateS) // Tag�� �Է��� ������Ʈ�����߿� ���� ����� ������Ʈ �Ÿ� ���
            {
                FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag(TagName));
                shortDis = Vector3.Distance(gameObject.transform.position, FoundObjects[0].transform.position);

                Slot = FoundObjects[0];

                foreach (GameObject found in FoundObjects)
                {
                    float Distance = Vector3.Distance(gameObject.transform.position, found.transform.position);

                    if (Distance < shortDis)
                    {
                        Slot = found;
                        shortDis = Distance;
                    }
                } // �ش� ������Ʈ�� ���� ����� TagName �Է��� ������Ʈ�� ã���ְ� �� �Ÿ���ġ�� shortDis
                    SlotCount = Slot.transform.childCount;
                if (Slot != null)
                {
                    if (Slot.layer == LayerMask.NameToLayer("Save"))
                    {
                        save = Slot.GetComponent<Save>();
                        if (save != null)
                        {
                            save.Item = gameObject;
                        }
                    }
                }
                //********************************************************************************************************************************************

                transform.parent = ParentItem.transform; // �������� �ڽ����� ���ư� �θ�� �Ÿ�����

                // �θ� ������Ʈ�� ���� ��ǥ�� ������
                Vector3 parentWorldPosition = transform.parent.position;

                // �θ� ������Ʈ�� ���� ��ǥ�� �������� �� �ڽ� ������Ʈ�� ���� ��ǥ�� ����
                Vector3 localPosition = transform.parent.InverseTransformPoint(parentWorldPosition);
                localPosition.x += distanceX;
                localPosition.y += distanceY;

                // �ڽ� ������Ʈ�� ��ġ�� ����
                transform.localPosition = localPosition;
                //********************************************************************************************************************************************

                if (pickupdown != null)
                {
                    if ((SlotCount == 0) && (shortDis <= 1.1)) // �κ��丮 ������ �ڽĿ�����Ʈ�� 0 �̸� �Ÿ��� 1.1 �����϶�
                    {
                        DisCheckS = true;
                    }
                }
                else
                {
                    DisCheckS = false;
                }
                //********************************************************************************************************************************************

                if ((Highlight != null) && (HighlightNull == null))
                {
                    HighlightNull = Instantiate(Highlight);
                }
                if (shortDis <= 1.1)
                {
                    if (!HighlightNull.activeSelf)
                    {
                        HighlightNull.SetActive(true);
                    }
                    HighlightNull.transform.position = Slot.transform.position;
                }
                else if (shortDis > 1.1)
                {
                    HighlightNull.SetActive(false);
                }
            }

            //********************************************************************************************************************************************
            PickDownCheck = pickupdown.Equip;
            Exact = pickupdown.SlotYes;

            if (PickDownCheck) // �θ� ����������
            {
                if (Exact) // �θ� ��Ȯ�ϰ� ���������� Ʈ���ΰ�
                {
                    transform.position = Slot.transform.position; // ���� ����� ������Ʈ ����(Slot)�� ��ǥ�� �̵�
                    ItemPos = Slot.transform.position; // �̵��� ��ǥ ItemPos �� ����
                    transform.parent = Slot.transform; // �ش� ������ �ڽ����� ��
                    Slot2 = Slot;
                }
                else // �ƴҽ�
                {
                    transform.position = ItemPos; // �� �Ÿ��Ͻ� ���� ����� ��ǥ�� ����
                    if (Slot2 != null)
                    {
                        transform.parent = Slot2.transform;
                    }
                }
                if (HighlightNull != null)
                {
                    HighlightNull.transform.position = transform.position;
                    Destroy(HighlightNull);
                }
            }
        }
        if (ParentItem == null)
        {
            Destroy(gameObject);
        }
    }
    public float Pos()
    {
        float itemXY = Mathf.RoundToInt((Mathf.Abs(transform.position.x - ParentItem.transform.position.x) + Mathf.Abs(transform.position.y - ParentItem.transform.position.y)) / 0.44f * 1000f) / 1000f;
        float slotXY = Mathf.RoundToInt((Mathf.Abs(Slot.transform.position.x - pickupdown.Slot.transform.position.x) + Mathf.Abs(Slot.transform.position.y - pickupdown.Slot.transform.position.y)) / 0.45f * 1000f) / 1000f;
        return itemXY - slotXY;
    }
}
