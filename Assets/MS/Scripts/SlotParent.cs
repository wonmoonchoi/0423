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

    private List<GameObject> FoundObjects; // 거리 계산할 오브젝트들 배열에 넣는 용도
    public GameObject Slot; // 가장 가까운 오브젝트명
    public GameObject Slot2;
    public string TagName; // 거리 계산할 오브젝트 태그 입력
    private float shortDis; // 가장 가까운 오브젝트와의 거리

    public int SlotCount;
    public Save save;

    Vector3 ItemPos;

    // 가로 및 세로 거리를 조절할 변수
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

            if (RotateS) // Tag에 입력한 오브젝트종류중에 가장 가까운 오브젝트 거리 계산
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
                } // 해당 오브젝트와 가장 가까운 TagName 입력한 오브젝트를 찾아주고 그 거리수치가 shortDis
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

                transform.parent = ParentItem.transform; // 아이템의 자식으로 돌아감 부모랑 거리조절

                // 부모 오브젝트의 월드 좌표를 가져옴
                Vector3 parentWorldPosition = transform.parent.position;

                // 부모 오브젝트의 월드 좌표를 기준으로 한 자식 오브젝트의 로컬 좌표를 변경
                Vector3 localPosition = transform.parent.InverseTransformPoint(parentWorldPosition);
                localPosition.x += distanceX;
                localPosition.y += distanceY;

                // 자식 오브젝트의 위치를 변경
                transform.localPosition = localPosition;
                //********************************************************************************************************************************************

                if (pickupdown != null)
                {
                    if ((SlotCount == 0) && (shortDis <= 1.1)) // 인벤토리 슬롯의 자식오브젝트가 0 이며 거리가 1.1 이하일때
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

            if (PickDownCheck) // 부모가 내려놨을시
            {
                if (Exact) // 부모가 정확하게 내려놨을때 트루인거
                {
                    transform.position = Slot.transform.position; // 가장 가까운 오브젝트 변수(Slot)의 좌표로 이동
                    ItemPos = Slot.transform.position; // 이동한 좌표 ItemPos 에 저장
                    transform.parent = Slot.transform; // 해당 슬롯의 자식으로 들어감
                    Slot2 = Slot;
                }
                else // 아닐시
                {
                    transform.position = ItemPos; // 먼 거리일시 원래 저장된 좌표로 복귀
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
