using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange_First : MonoBehaviour
{
    public void OnButtonClick()
    {
        Loading.LoadScene("INGAME");
    }
}
