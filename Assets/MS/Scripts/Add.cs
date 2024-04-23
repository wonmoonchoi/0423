using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Add : MonoBehaviour, IPointerDownHandler
{
    public GameObject Slot;
    public AddButton AddButton;
    public void OnPointerDown(PointerEventData eventData)
    {
        GameObject Add = Instantiate(Slot, transform.position, transform.rotation);
        AddButton.Count++;
        AddButton.Slot++;
        if (AddButton.Slot < 120 && AddButton.Count < AddButton.SlotAdd)
        {
            AddButton.AddButtonReroll();
        }
        else if (AddButton.Slot >= 120 || AddButton.Count >= AddButton.SlotAdd) // ¿Œ∫• ∏∆Ω∫ΩΩ∑‘¿œΩ√ πﬂª˝
        {
            foreach (GameObject obj in AddButton.AddList)
            {
                Destroy(obj);
            }
            AddButton.AddList.Clear();
            AddButton.PickUp = true;
            AddButton.slotReroll.gameObject.SetActive(false);
            AddButton.reroll.gameObject.SetActive(true);
            AddButton.start.gameObject.SetActive(true);
        }
        Destroy(gameObject);
    }
    void Start()
    {
        if (AddButton == null)
        {
            AddButton = GameObject.Find("AddButton").GetComponent<AddButton>();
        }
    }
    void Update()
    {

    }
}
