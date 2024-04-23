using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public TextMeshProUGUI textField;
    public int Money;
    // Start is called before the first frame update
    public void Start()
    {
        textField.text = Money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
