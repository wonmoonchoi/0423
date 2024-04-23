using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesChange : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene("INVENTORY");
        }
    }
    private void Start()
    {
        // WeaponData 오브젝트의 WeaponData 스크립트에 접근
        WeaponData weaponData = FindObjectOfType<WeaponData>();

        // 스크립트가 존재하는지 확인 후 작업 수행
        if (weaponData != null)
        {
         //   foreach(GameObject weapon in weaponData.WeaponList)
        }
    }
}
