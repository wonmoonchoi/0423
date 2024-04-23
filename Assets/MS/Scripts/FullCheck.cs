using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class FullCheck : MonoBehaviour
{
    public bool ChildCheck;
    SpriteRenderer UnFull;
    SpriteRenderer Full;
    SpriteRenderer Me;
    private void Start()
    {
        GameObject[] Slot = GameObject.FindObjectsOfType<GameObject>().Where(obj => obj.layer == LayerMask.NameToLayer("Slot")).ToArray();
        List<GameObject> listSlot = new List<GameObject>();
        foreach (GameObject slot in Slot)
        {
            listSlot.Add(slot);
        }
        listSlot.Remove(gameObject);
        foreach (GameObject slot in listSlot)
        {
            if (transform.position == slot.transform.position)
            {
                Destroy(gameObject);
            }
        }
        UnFull = GameObject.Find("SlotImage").GetComponent<SpriteRenderer>();
        Full = GameObject.Find("SlotFullImage").GetComponent<SpriteRenderer>();
        Me = gameObject.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (transform.childCount > 0 && ChildCheck)
        {
            Me.sprite = Full.sprite;
            ChildCheck = false;
        }
        if (transform.childCount == 0 && ChildCheck == false)
        {
            Me.sprite = UnFull.sprite;
            ChildCheck = true;
        }
    }
}