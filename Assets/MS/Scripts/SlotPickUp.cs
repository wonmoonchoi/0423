using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotPickUp : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject MainSlot; // 인스펙터에서 꼭 메인슬롯 넣어야함

    private void Start()
    {
        
    }
    // 마우스 버튼을 누를 때 호출되는 메서드
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
