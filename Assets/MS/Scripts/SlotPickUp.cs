using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotPickUp : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject MainSlot; // �ν����Ϳ��� �� ���ν��� �־����

    private void Start()
    {
        
    }
    // ���콺 ��ư�� ���� �� ȣ��Ǵ� �޼���
    public void OnPointerDown(PointerEventData eventData)
    {
        if (MainSlot != null)
        {
            MainSlot.GetComponent<PickUpDown>().OnPointerDown(eventData);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (MainSlot != null)
        {
            MainSlot.GetComponent<PickUpDown>().OnPointerExit(eventData);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (MainSlot != null)
        {
            MainSlot.GetComponent<PickUpDown>().OnPointerEnter(eventData);
        }
    }
}
