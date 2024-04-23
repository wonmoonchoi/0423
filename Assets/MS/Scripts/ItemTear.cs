using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemTear : MonoBehaviour
{
    public TextMeshProUGUI textField;
    public void Itemtear(int Upgrade)
    {
        if (Upgrade > 0)
        {
            textField.text = Upgrade.ToString() + "Æ¼¾î";
        }
        else
        {
            textField.text = "";
        }
    }
}
