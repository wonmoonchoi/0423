using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    private float halfwidth;
    RectTransform rt;
    public bool Stop = true;

    public bool UIstop=false;
    private void Start()
    {
        halfwidth = GetComponentInParent<CanvasScaler>().referenceResolution.x * 0.8f;
        rt = GetComponent<RectTransform>();
        gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Stop)
        {
            transform.position = Input.mousePosition;

            if (rt.anchoredPosition.y + rt.sizeDelta.y > halfwidth)
                rt.pivot = new Vector2(0, 1);
            else
                rt.pivot = new Vector2(0, 0);
        }
    }
}
